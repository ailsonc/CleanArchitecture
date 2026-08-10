using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Domain.Repositories.Interfaces
{
    public interface IBasicRepository<T> where T : class
    {
        Task<T> getById(long id);
        Task<IEnumerable<T>> getAll();
        Task add(T entity);
        Task update(T entity);
        Task delete(long id);
    }
}
