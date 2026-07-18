namespace PokeShop.Domain.Models
{
    public class Pokemon
    {
        public Guid Id { get; set; } // PK

        public string Name { get; set; }

        public ICollection<Element> Elements { get; set; } = new List<Element>(); // Para possível filter futuro por tipo

        public int RarityId { get; set; } 

        public Rarity Rarity {get; set; } // Common, Uncommon, Rare, Legendary

        public Guid? OwnerId { get; set; } // NULL = disponível

        public User? Owner { get; set; }
    }
}