namespace PokeShop.Application.DTOs.Center
{
    public record class BuyResultDto(Guid ? OwnerId, string PokemonName, 
        IReadOnlyList<Elements> Elements, 
        Rarities Rarity, int MarketValue, string CoinsAdjustment);
}