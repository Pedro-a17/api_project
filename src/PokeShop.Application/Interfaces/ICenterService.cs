using PokeShop.Application.DTOs.Center;

namespace PokeShop.Application.Interfaces
{
    public interface ICenterService
    {
        Task<IEnumerable<AvailablePokemonDto>> GetAvailablePokemonsAsync();

        Task<BuyResultDto> BuyPokemonAsync(Guid pokemonCenterId, Guid userId);

        Task<PokeballDto> BuyPokeballAsync(Guid userId);
    }
}