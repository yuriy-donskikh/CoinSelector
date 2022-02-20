namespace CoinSelector.Data
{
    public class CoinDbContext : DbContext
    {
        protected CoinDbContext()
        {
        }

        public CoinDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Price> Prices => Set<Price>();
        public virtual DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>(entity =>
            {
                entity.ToTable("users");
                entity.HasKey(e => e.Id);
                entity.HasOne(a => a.Price);
            });
            builder.Entity<Price>(entity =>
            {
                entity.ToTable("prices");
                entity.HasKey(e => e.UserId);
            });
        }
    }
}
