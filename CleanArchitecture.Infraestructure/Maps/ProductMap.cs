using CleanArchitecture.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infraestructure.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x => x.IdProduct);
            builder.Property(x => x.IdProduct).HasColumnName("idProduct").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.IdCategory).HasColumnName("idCategory");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.Price).HasColumnName("price");
            builder.Property(x => x.RegistrationDate).HasColumnName("registrationDate").HasColumnType("DATETIME");

            // Many-to-one relationship with Category
            builder.HasOne(x => x.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.IdCategory);

        }
    }
}
