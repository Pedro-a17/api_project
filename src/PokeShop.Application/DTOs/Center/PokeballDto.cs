namespace PokeShop.Application.DTOs.Center
{
    public record class PokeballDto(string Pokeball, Rarities Rarity, 
        string PokemonName, IReadOnlyList<Elements> 
        Elements, int MarketValue,
        Guid ? OwnerId, string CoinsAdjustment);
}