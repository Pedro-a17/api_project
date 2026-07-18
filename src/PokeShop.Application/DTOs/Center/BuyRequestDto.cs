namespace PokeShop.Application.DTOs.Center
{
    public class BuyRequestDto
    {
        public Guid PokemonCenterId { get; set; }

        public Guid UserId { get; set; }
    }
}