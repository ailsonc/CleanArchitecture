using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.InfraStreucture.Maps
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");

            builder.HasKey(x => x.IdCategory);
            builder.Property(x => x.IdCategory).HasColumnName("idCategory").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.RegistrationDate).HasColumnName("registrationDate").HasColumnType("DATETIME");

            // One-to-many relationship with Product
            builder.HasMany(x => x.Products)
                   .WithOne(p => p.Category)
                   .HasForeignKey(p => p.IdCategory);
        }
    }
}
