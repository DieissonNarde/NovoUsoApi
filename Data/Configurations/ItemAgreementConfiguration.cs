using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovoUsoApi.Models;

namespace NovoUsoApi.Data.Configurations
{
    public class ItemAgreementConfiguration : IEntityTypeConfiguration<ItemAgreement>
    {
        public void Configure(EntityTypeBuilder<ItemAgreement> builder)
        {
            builder.HasKey(x => x.ItemId);

            builder.HasOne(x => x.Item)
                .WithOne(i => i.Agreement)
                .HasForeignKey<ItemAgreement>(x => x.ItemId);

            builder.HasOne(x => x.WinningBid)
                .WithMany()
                .HasForeignKey(x => x.WinningBidId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
