using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.Maps
{
    public class SpendMapping : IEntityTypeConfiguration<Spend>
    {
        public void Configure(EntityTypeBuilder<Spend> builder)
        {
            builder.ToTable("spend");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("idSpend")
                .UseIdentityColumn();

            builder.Property(x => x.Date)
                .HasColumnName("date");


            builder.Property(x => x.Value)
                .HasColumnName("value");
               


            builder.Property(x => x.Type)
                .HasColumnName("spend_type")
                .HasConversion<string>(); 


            builder.Property(x => x.Account.Id).HasColumnName("idAccount");
        }
    }
}
