using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Domain.Services
{
    public interface ICategoryService
    {
        Task<Category> getById(long id);
        Task<IEnumerable<Category>> getAll();
        Task add(Category category);
        Task update(Category category);
        Task delete(long id);
    }
}
