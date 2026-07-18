using PokeShop.Application.DTOs.Storage;

namespace PokeShop.Application.Interfaces
{
    public interface IStorageService
    {
        Task<IEnumerable<EngagedPokemonDto>> GetInventoryAsync(Guid userId);

        Task<IEnumerable<TransactionSummaryDto>> GetTransactionsAsync(Guid userId);

        Task<SellResultDto> SellPokemonAsync(Guid pokemonId, Guid userId);
    }
}