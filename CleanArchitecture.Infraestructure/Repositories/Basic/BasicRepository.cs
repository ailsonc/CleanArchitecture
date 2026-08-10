
using CleanArchitecture.Domain.Repositories.Interfaces;
using CleanArchitecture.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infraestructure.Repositories.Basic
{
    public class BasicRepository <T> : IBasicRepository<T> where T : class
    {
        private readonly CleanArchitectureContext _context;
        private readonly DbSet<T> _dbSet;


        public BasicRepository(CleanArchitectureContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();    
        }
        public async Task add(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task delete(long id)
        {
            var entity = await getById(id);

            if(entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> getAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> getById(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task update(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
