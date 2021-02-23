using microservices_crud.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace microservices_crud.Infrastructure.EntityConfigurations
{
    public class CatalogTypeEntityTypeConfiguration : IEntityTypeConfiguration<CatalogType>
    {
        public void Configure(EntityTypeBuilder<CatalogType> builder)
        {
            builder.ToTable("CatalogType");

            builder.HasKey(type => type.Id);

            builder.Property(type => type.Id)
                .UseHiLo("catalog_type_hilo")
                .IsRequired();

            builder.Property(type => type.Type)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}