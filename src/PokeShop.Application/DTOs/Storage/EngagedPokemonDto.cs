namespace PokeShop.Application.DTOs.Storage
{
    public record class EngagedPokemonDto(Guid UserPokemonId, string Name, 
        IReadOnlyList<Elements> Elements, 
        int MarketValue, Rarities Rarity);
}