using Moq;
using PokeShop.Application.Services;
using PokeShop.Domain.Enums;
using PokeShop.Domain.Interfaces;
using PokeShop.Domain.Models;

using Xunit;

namespace PokeShop.Tests.Services
{
    public class CenterServiceTests
    {
        private readonly Mock<ICenterRepository> _repoMock;
        private readonly CenterService _service;

        public CenterServiceTests()
        {
            _repoMock = new Mock<ICenterRepository>();
            _service = new CenterService(_repoMock.Object);
        }

        public static IEnumerable<Object[]> CoinsAdjustmentData => new List<Object[]>
        {   
            new Object[] {100, 50, 50},
            new Object[] {100, 90, 10},
        };

        [Theory]
        [MemberData(nameof(CoinsAdjustmentData))]
        public async Task BuyPokemonAsync_ShouldAdjustCoinsCorrectly(int startCoins, int pokemonPrice, int finalCoins)
        {
            //Arrange
            PokemonCenter pokemonCenter = new PokemonCenter
            {
                PokemonId = 1,
                MarketPrice = pokemonPrice,
                Pokemon = new Pokemon
                {
                    OwnerId = null,
                    Name = "Pikachu",
                    Nature = "Brave",
                    Elements = new List<Element>(), 
                    Rarity = new Rarity { Name = Rarities.Rare } 
                }
            };

            User user = new User
            {
              Id = 1,
              Coins = startCoins
            };

            _repoMock.Setup(r => r.GetPokemonCenterByIdAsync(pokemonCenter.PokemonId)).ReturnsAsync(pokemonCenter);
            _repoMock.Setup(r => r.GetUserByIdAsync(user.Id)).ReturnsAsync(user);

            //Act & verify
            var result = await _service.BuyPokemonAsync(pokemonCenter.PokemonId, user.Id);
            Assert.Equal(finalCoins, user.Coins);

            _repoMock.Verify(r => r.SavePurchaseAsync(It.IsAny<Transaction>(), pokemonCenter), Times.Once);
        }
    }
}