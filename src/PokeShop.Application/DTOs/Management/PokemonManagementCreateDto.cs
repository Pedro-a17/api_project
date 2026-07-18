using System.ComponentModel.DataAnnotations;

namespace PokeShop.Application.DTOs.Management
{
    public class PokemonManagementCreateDto
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        public List<Elements> Elements { get; set; }

        public int RarityId { get; set; }
        
        public Guid? OwnerId { get; set; }
    }
}