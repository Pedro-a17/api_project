using PokeShop.Application.DTOs.Management;

namespace PokeShop.Application.Interfaces
{
    public interface IAdminService
    {
        //User management
        Task<ResultDto<IEnumerable<UserManagementResponseDto>>> GetUsersAsync();
        Task<ResultDto<UserManagementResponseDto>> GetUserByIdAsync(Guid targetId);
        Task<ResultDto<UserManagementResponseDto>> CreateUserAsync(UserManagementCreateDto dto);
        Task<ResultDto<UserManagementResponseDto>> UpdateUserAsync(Guid targetId, UserManagementUpdateDto dto);
        Task<ResultDto<UserManagementResponseDto>> SoftDeleteUserAsync(Guid targetId);
        Task<ResultDto<UserManagementResponseDto>> DeleteUserAsync(Guid targetId);

        //Pokemon management
        Task<ResultDto<IEnumerable<PokemonManagementResponseDto>>> GetAllPokemonsAsync();
        Task<ResultDto<PokemonManagementResponseDto>> GetPokemonByIdAsync(Guid targetId);
        Task<ResultDto<PokemonManagementResponseDto>> CreatePokemonAsync(PokemonManagementCreateDto dto);
        Task<ResultDto<PokemonManagementResponseDto>> UpdatePokemonAsync(Guid targetId, PokemonManagementUpdateDto dto);
        Task<ResultDto<PokemonManagementResponseDto>> DeletePokemonAsync(Guid targetId);
        
        //PokemonCenter management
        Task<ResultDto<PokemonCenterManagementResponseDto>> CreatePokemonCenterAsync(PokemonCenterManagementCreateDto dto);
        Task<ResultDto<PokemonCenterManagementResponseDto>> UpdatePokemonCenterMarketPriceAsync(Guid targetId, PokemonCenterManagementUpdateDto dto);
        Task<ResultDto<PokemonCenterManagementResponseDto>> DeletePokemonCenterAsync(Guid targetId);
        
        //Transaction management
        Task<ResultDto<IEnumerable<TransactionManagementResponseDto>>> GetAllTransactionsAsync();
        Task<ResultDto<IEnumerable<TransactionManagementResponseDto>>> GetTransactionsHistoryAsync(int? year = null, int? month = null, int? day = null);
        Task<ResultDto<TransactionManagementResponseDto>> GetTransactionByIdAsync(Guid targetId);
        Task<ResultDto<IEnumerable<TransactionManagementResponseDto>>> GetTransactionsByUserIdAsync(Guid targetId);
        Task<ResultDto<IEnumerable<TransactionManagementResponseDto>>> GetTransactionsByPokemonIdAsync(Guid targetId);
    }
}