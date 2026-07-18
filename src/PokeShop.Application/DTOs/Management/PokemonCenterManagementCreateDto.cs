namespace PokeShop.Application.DTOs.Management
{
    public class PokemonCenterManagementCreateDto
    {
        public Guid PokemonId {get; set; }

        public int? MarketPrice {get; set; }
    }
}