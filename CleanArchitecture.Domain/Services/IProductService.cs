using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Domain.Services
{
    public interface IProductService
    {
        Task<Product> getById(long id);
        Task<IEnumerable<Product>> getAll();
        Task add(Product product);
        Task update(Product product);
        Task delete(long id);
    }
}
