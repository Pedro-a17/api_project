using System.Linq.Expressions;

namespace PokeShop.Domain.Interfaces
{
    public interface IAdminRepository
    {
        // User management
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User?> GetUserByIdAsync(Guid id);
        Task<bool> UserExistsByIdAsync(Guid id);
        Task<bool> UserExistsByNameAsync(string username);
        Task<User> CreateUserAsync(User user);
        Task <User> UpdateUserAsync(User user); 
        Task SoftDeleteUserAsync(User user);
        Task DeleteUserAsync(User user);

        // Pokemon management
        Task<IEnumerable<Pokemon>> GetPokemonsAsync();
        Task<Pokemon?> GetPokemonByIdAsync(Guid id);
        Task<List<Element>> GetElementsByNames(List<Elements> elementsNames);
        Task<bool> PokemonExistsByIdAsync(Guid id);
        Task<Pokemon> CreatePokemonAsync(Pokemon pokemon);
        Task <Pokemon> UpdatePokemonAsync(Pokemon pokemon);
        Task DeletePokemonAsync(Pokemon pokemon);

        // Pokemon Center management
        Task<PokemonCenter?> GetPokemonCenterByIdAsync(Guid id);
        Task<bool> PokemonCenterExistsById(Guid id);
        Task<PokemonCenter> CreatePokemonCenterAsync(PokemonCenter pokemonCenter);
        Task <PokemonCenter> UpdatePokemonCenterAsync(PokemonCenter pokemonCenter);
        Task DeletePokemonCenterAsync(PokemonCenter pokemonCenter);

        // Transaction management
        Task<IEnumerable<Transaction>> GetTransactionsAsync();
        Task<Transaction?> GetTransactionByIdAsync(Guid id);
        Task<IEnumerable<Transaction>> GetTransactionsByUserIdAsync(Guid id);
        Task<IEnumerable<Transaction>> GetTransactionsByPokemonIdAsync(Guid id);
        Task<IEnumerable<Transaction>> GetTransactionsHistoryAsync(Expression<Func<Transaction, bool>> filter); // Para permitir filtros no Service
        Task CreateTransactionAsync(Transaction transaction);
    }
}