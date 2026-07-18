namespace PokeShop.Application.DTOs.Management
{
    public record class PokemonManagementResponseDto(Guid Id, string Name,
        IEnumerable<Element> Elements,
        int RarityId, Guid? OwnerId);
}