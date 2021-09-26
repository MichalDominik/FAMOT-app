using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Fridge.Service.Models;

namespace Fridge.Repository.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(product => product.Id);

            builder.Property(product => product.Name)
                .IsRequired()
                .HasColumnType("nvarchar(150)");

            builder.Property(product => product.Description)
                .IsRequired(false)
                .HasColumnType("nvarchar(300)");

            builder.Property(product => product.CategoryId)
                .IsRequired();

            builder.ToTable("Products");
        }
    }
}
