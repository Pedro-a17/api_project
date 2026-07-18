namespace PokeShop.Application.DTOs.Storage
{
    public class SellRequestDto
    {
        public Guid UserId { get; set; }

        public Guid PokemonId { get; set; }
    }
}