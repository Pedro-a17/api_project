namespace PokeShop.Application.DTOs.Management
{
    public record class UserManagementResponseDto(Guid Id, string UserName,
        int Coins, bool FirstLogin, bool IsActive);
}