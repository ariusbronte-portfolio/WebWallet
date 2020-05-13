using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebWallet.Domain.Entites;

namespace WebWallet.DataAccess.Configurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.CreationHistory).IsRequired();

            builder.HasMany(x => x.Wallets)
                .WithOne(x => x.UserEntity)
                .HasForeignKey(x => x.UserEntityId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}