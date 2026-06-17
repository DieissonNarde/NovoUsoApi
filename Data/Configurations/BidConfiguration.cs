using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NovoUsoApi.Models;

namespace NovoUsoApi.Data.Configurations
{
    public class BidConfiguration : IEntityTypeConfiguration<Bid>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Bid> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Date).IsRequired().HasMaxLength(100);
            builder.Property(b => b.Value).IsRequired().HasMaxLength(50);
            builder.Property(b => b.Description).IsRequired().HasMaxLength(250);
            builder.Property(b => b.Status);
            builder.Property(b => b.ProposalType);
            
            builder.HasOne(b => b.Item).WithMany(b => b.Bids)
                                        .HasForeignKey(i => i.ItemId)
                                        .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(b => b.User).WithMany(b => b.Bids)
                                        .HasForeignKey(i => i.UserId)
                                        .OnDelete(DeleteBehavior.NoAction);
        }
    }
}