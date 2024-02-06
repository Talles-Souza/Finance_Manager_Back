using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CrossCutting.Maps
{
    public class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("account");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("idAccount")
                .UseIdentityColumn();

            builder.Property(x => x.Number)
                .HasColumnName("number");


            builder.Property(x => x.Value)
                .HasColumnName("value");


            builder.Property(x => x.CreateAccount)
                .HasColumnName("create_account");
                

            builder.Property(x => x.UpdateAccount)
                .HasColumnName("update_account");
                      
            builder.Property(x=> x.User.Id).HasColumnName("userId");

            builder.HasMany(x => x.Spends)
                .WithOne(s => s.Account)
                .HasForeignKey(s => s.Account.Id);
         
            builder.Property(x => x.Type)
                .HasColumnName("account_type")
                .HasConversion<string>(); 
        }
    }
}
