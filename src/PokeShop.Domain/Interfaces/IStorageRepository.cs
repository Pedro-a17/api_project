namespace PokeShop.Domain.Interfaces
{
    public interface IStorageRepository
    {
        Task<IEnumerable<Pokemon>> GetUserInventoryAsListAsync(Guid userId);
        Task<IEnumerable<Transaction>> GetTransactionsAsListAsync(Guid userId);
        Task<Pokemon?> GetPokemonById(Guid id);
        Task<User?> GetUserById(Guid id);
        Task<bool> UserExistsByIdAsync(Guid id);
        Task<bool> UserOwnsSomeInventary(Guid id);
        Task<PokemonCenter?> GetPokemonCenterByIdAsync(Guid id);
        Task SaveSellAsync(Transaction transaction, PokemonCenter? pokemonToReturn = null);
    }
}