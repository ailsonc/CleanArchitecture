using CleanArchitecture.Domain.Models;
using CleanArchitecture.Domain.Repositories.Interfaces;
using CleanArchitecture.Infraestructure.Data;
using CleanArchitecture.Infraestructure.Repositories.Basic;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infraestructure.Repositories
{
    public class CategoryRepository : BasicRepository<Category>, ICategoryRepository
    {
        private readonly CleanArchitectureContext _context;

        public CategoryRepository(CleanArchitectureContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Category> getByDescription(string description)
        {
            return await _context.Categories
                .Where(c => c.Description.ToLower() == description.ToLower())
                .FirstOrDefaultAsync();
        }
    }
}
