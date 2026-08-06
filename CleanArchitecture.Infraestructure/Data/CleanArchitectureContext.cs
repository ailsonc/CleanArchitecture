using CleanArchitecture.Domain.Models;
using CleanArchitecture.Infraestructure.Maps;
using CleanArchitecture.InfraStreucture.Maps;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infraestructure.Data
{
    public class CleanArchitectureContext : DbContext
    {
        public CleanArchitectureContext(DbContextOptions<CleanArchitectureContext> options) : base(options) 
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
        }
    }
}
