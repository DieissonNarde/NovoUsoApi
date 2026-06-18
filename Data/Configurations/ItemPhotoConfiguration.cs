using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NovoUsoApi.Models;

namespace NovoUsoApi.Data.Configurations
{
    public class ItemPhotoConfiguration : IEntityTypeConfiguration<ItemPhoto>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ItemPhoto> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.FileName);
            builder.Property(i => i.ContentType);
            builder.Property(i => i.Url);

            builder.HasOne(i => i.Item).WithMany(i => i.Photos)
                                        .HasForeignKey(i => i.ItemId)
                                        .OnDelete(DeleteBehavior.NoAction);
        }
    }
}