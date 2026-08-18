using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Domain.Repositories.Interfaces
{
    public interface ICategoryRepository : IBasicRepository<Category>
    {
        Task<Category> getByDescription(string description);
    }
}
