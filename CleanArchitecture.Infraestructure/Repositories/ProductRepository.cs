using CleanArchitecture.Domain.Models;
using CleanArchitecture.Domain.Repositories.Interfaces;
using CleanArchitecture.Infraestructure.Data;
using CleanArchitecture.Infraestructure.Repositories.Basic;
using Microsoft.EntityFrameworkCore;


namespace CleanArchitecture.Infraestructure.Repositories
{
    public class ProductRepository : BasicRepository<Product>, IProductRepository   
    {
        private readonly CleanArchitectureContext _context;

        public ProductRepository(CleanArchitectureContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Product> getByName(string name)
        {
            return await _context.Products
                .Where(c => c.Name.ToLower() == name.ToLower())
                .FirstOrDefaultAsync();
        }
    }
}
