namespace PokeShop.Domain.Interfaces
{
    public interface ICenterRepository
    {
        Task<IEnumerable<PokemonCenter>> GetAvailablePokemonsAsync();
        Task<PokemonCenter?> GetPokemonCenterByIdAsync(Guid id);
        Task<User?> GetUserByIdAsync(Guid id);
        Task<List<Pokemon>> GetAvailablePokemonsByRarityAsync(Rarities rarity);
        Task SavePurchaseAsync(Transaction transaction, PokemonCenter? centerToRemove = null);
    }
}