namespace PokeShop.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public bool SoftDelete {get; set; } = true;
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Transaction> Transactions { get; set; } // relação de histórico
        public DbSet<PokemonCenter> PokemonCenter { get; set; } // loja
        public DbSet<Element> Elements { get; set; }
        public DbSet<Rarity> Rarities { get; set; }


        //configuração de modelo e relacionamentos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .ToTable(t => t.HasCheckConstraint(
                    "CK_User_Coins_NotNegative",
                    "`Coins` >= 0"      
                ));

            modelBuilder.Entity<PokemonCenter>(entity =>
            {
                entity.ToTable(t => t.HasCheckConstraint("CK_PokemonCenter_MarketPrice_Min", "`MarketPrice` >= 0"));
            });

            modelBuilder.Entity<User>()
                .HasQueryFilter(u => u.IsActive);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Pokemon)
                .WithMany()
                .HasForeignKey(p => p.PokemonId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Pokemon>()
                .HasOne(p => p.Owner)
                .WithMany()
                .HasForeignKey(p => p.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pokemon>()
                .HasOne(p => p.Rarity)
                .WithMany()
                .HasForeignKey(p => p.RarityId);

            modelBuilder.Entity<Pokemon>()
                .HasMany(p => p.Elements)
                .WithMany()
                .UsingEntity(j => j.ToTable("PokemonElement"));

            modelBuilder.Entity<PokemonCenter>()
                .HasKey(pc => pc.PokemonId);
            
            modelBuilder.Entity<PokemonCenter>()
                .HasOne(pc => pc.Pokemon)
                .WithOne()
                .HasForeignKey<PokemonCenter>(pc => pc.PokemonId)
                .OnDelete(DeleteBehavior.Cascade);

            //properties
            modelBuilder.Entity<User>()
                .Property(u => u.IsActive)
                .HasDefaultValue(true);

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Status)
                .HasConversion<string>();
            
            modelBuilder.Entity<Element>()
                .Property(e => e.Name)
                .HasConversion<string>();

            modelBuilder.Entity<Rarity>()
                .Property(r => r.Name)
                .HasConversion<string>();

            //indices
            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();

            modelBuilder.Entity<Element>()
                .HasIndex(e => e.Name)
                .IsUnique();

            modelBuilder.Entity<Transaction>()
                .HasIndex(t => t.TransactionDate);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ProcessUserLifecycle();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void ProcessUserLifecycle()
        {
            var deletedEntities = ChangeTracker.Entries<User>()
                .Where(e => e.State == EntityState.Deleted).ToList();

            if (SoftDelete)
            {
                foreach (var entry in deletedEntities)
                {
                    entry.State = EntityState.Modified;

                    entry.Entity.IsActive = false;

                    clearUserPokemons(entry.Entity.Id);
                }
            } 
            else
            {
                foreach (var entry in deletedEntities)
                {
                    clearUserPokemons(entry.Entity.Id);
                }
            }

            var deactivatedUsers = ChangeTracker.Entries<User>()
                .Where(e => e.State == EntityState.Modified)
                .Where(e =>
                {
                    var oldDatabaseValue = e.OriginalValues.GetValue<bool>(nameof(User.IsActive));
                    var currentMemoryValue = e.Entity.IsActive;

                    return oldDatabaseValue && !currentMemoryValue;
                });

            foreach (var entry in deactivatedUsers)
            {
                clearUserPokemons(entry.Entity.Id);
            }
        }

        private void clearUserPokemons(Guid userId)
        {
            Pokemons
                .Where(p => p.OwnerId == userId)
                .ExecuteUpdate(setters => setters.SetProperty(p => p.OwnerId, (Guid?)null));
        }
    }
}