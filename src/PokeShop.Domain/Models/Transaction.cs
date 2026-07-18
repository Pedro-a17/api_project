namespace PokeShop.Domain.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        
        public User User { get; set; } 

        public Guid? PokemonId { get; set; }

        public Pokemon? Pokemon { get; set; }

        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;

        public TransactionStatus Status { get; set; }

        public string CoinsAdjustment { get; set; }
    }
}