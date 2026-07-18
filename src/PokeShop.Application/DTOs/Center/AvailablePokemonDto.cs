namespace PokeShop.Application.DTOs.Center
{
    public record class AvailablePokemonDto (Guid PokemonCenterId, string Name, 
        IEnumerable<Elements> Elements, int MarketValue, Rarities Rarity);
}