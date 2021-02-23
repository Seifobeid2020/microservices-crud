using microservices_crud.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace microservices_crud.Infrastructure.EntityConfigurations
{
    public class CatalogItemEntityTypeConfiguration : IEntityTypeConfiguration<CatalogItem>
    {
        public void Configure(EntityTypeBuilder<CatalogItem> builder)
        {
            builder.ToTable("Catalog");

            builder.Property(item => item.Id)
                .UseHiLo("catalog_hilo")
                .IsRequired();

            builder.Property(item => item.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(item => item.Price)
                .IsRequired();

            builder.Property(item => item.PictureFileName)
                .IsRequired(false);

            builder.Ignore(item => item.PictureUri);

            builder.HasOne(item => item.CatalogBrand)
                .WithMany()
                .HasForeignKey(item => item.CatalogBrandId);

            builder.HasOne(item => item.CatalogType)
                .WithMany()
                .HasForeignKey(item => item.CatalogTypeId);
        }
    }
}