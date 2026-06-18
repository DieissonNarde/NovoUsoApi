using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovoUsoApi.Models;

namespace NovoUsoApi.Data.Configurations
{
    public class ItemAgreementConfiguration : IEntityTypeConfiguration<ItemAgreement>
    {
        public void Configure(EntityTypeBuilder<ItemAgreement> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Status);
            builder.Property(i => i.OwnerAcceptedAtUtc);
            builder.Property(i => i.WinnerAcceptedAtUtc);
            builder.Property(i => i.ClosedAtUtc);
            builder.Property(i => i.RejectionReason);

            builder.HasOne(i => i.Item)
                .WithMany()
                .HasForeignKey(i => i.ItemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.Bid)
                .WithMany()
                .HasForeignKey(i => i.BidId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
