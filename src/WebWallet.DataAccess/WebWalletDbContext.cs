using Microsoft.EntityFrameworkCore;

namespace WebWallet.DataAccess
{
    public class WebWalletDbContext : DbContext
    {
        public WebWalletDbContext(DbContextOptions<WebWalletDbContext> options) : base(options)
        {
        }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}