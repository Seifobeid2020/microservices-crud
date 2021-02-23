using microservices_crud.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace microservices_crud.Infrastructure.EntityConfigurations
{
    public class CatalogBrandEntityTypeConfiguration : IEntityTypeConfiguration<CatalogBrand>
    {
        public void Configure(EntityTypeBuilder<CatalogBrand> builder)
        {
            builder.ToTable("CatalogBrand");

            builder.HasKey(brand => brand.Id);

            builder.Property(brand => brand.Id)
                .UseHiLo("catalog_brand_hilo")
                .IsRequired();

            builder.Property(brand => brand.Brand)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}