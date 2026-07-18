namespace PokeShop.Application.DTOs.Management
{
    public record class TransactionManagementResponseDto(Guid Id, Guid UserId,
        Guid? PokemonId, DateTime TransactionDate, TransactionStatus status);
}