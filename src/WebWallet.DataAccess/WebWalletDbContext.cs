using Microsoft.EntityFrameworkCore;
using WebWallet.DataAccess.Configurations;
using WebWallet.Domain.Entites;

namespace WebWallet.DataAccess
{
    public class WebWalletDbContext : DbContext
    {
        public WebWalletDbContext(DbContextOptions<WebWalletDbContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        
        public DbSet<WalletEntity> Wallets { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new UserEntityConfiguration());
            builder.ApplyConfiguration(new WalletEntityConfiguration());
        }
    }
}