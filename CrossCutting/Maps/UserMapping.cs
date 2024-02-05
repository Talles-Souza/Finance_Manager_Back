using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CrossCutting.Maps
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("idUser")
                .UseIdentityColumn();

            builder.Property(x => x.FirstName)
                .HasColumnName("first_name");

            builder.Property(x => x.Password)
                .HasColumnName("password");

            builder.Property(x => x.FullName)
                .HasColumnName("full_name");

            builder.Property(x => x.Email)
                .HasColumnName("email");

            builder.HasMany(x => x.Account)
              .WithOne(s => s.User)
              .HasForeignKey(s => s.User.Id);

        }
    }
}
