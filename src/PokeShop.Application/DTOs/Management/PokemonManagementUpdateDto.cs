using System.ComponentModel.DataAnnotations;

namespace PokeShop.Application.DTOs.Management
{
    public class PokemonManagementUpdateDto
    {
        [Required]
        [MinLength(3)]
        public string? UpName { get; set; }
        
        [Required]
        [MinLength(3)]
        public List<Elements>? UpElements { get; set; }

        public int? UpRarityId { get; set; }

        public Guid? UpOwnerId { get; set; }
    }
}