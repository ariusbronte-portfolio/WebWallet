using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebWallet.Domain.Entites;

namespace WebWallet.DataAccess.Configurations
{
    public class WalletEntityConfiguration : IEntityTypeConfiguration<WalletEntity>
    {
        public void Configure(EntityTypeBuilder<WalletEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Balance).IsRequired();
            builder.Property(x => x.Currency).IsRequired();
            builder.Property(x => x.CreationHistory).IsRequired();

            builder.HasOne(x => x.UserEntity)
                .WithMany(x => x.Wallets)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}