using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NovoUsoApi.Models;

namespace NovoUsoApi.Data.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Title).IsRequired().HasMaxLength(200);
            builder.Property(i => i.Description).IsRequired().HasMaxLength(400);
            builder.Property(i => i.Quantity).IsRequired().HasMaxLength(50);
            builder.Property(i => i.Duration).IsRequired().HasMaxLength(50);
            builder.Property(i => i.Value).IsRequired().HasMaxLength(20);
            builder.Property(i => i.TypeOffer).IsRequired();
            builder.Property(i => i.Status);
            builder.Property(i => i.CancellationReason).HasMaxLength(100);

            builder.HasOne(i => i.User).WithMany(i => i.Items)
                                        .HasForeignKey(i => i.UserId)
                                        .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(i => i.Category).WithMany(i => i.Items)
                                        .HasForeignKey(i => i.CategoryId)
                                        .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(i => i.Address).WithMany(i => i.Items)
                                        .HasForeignKey(i => i.AddressId)
                                        .OnDelete(DeleteBehavior.NoAction);
        }
    }
}