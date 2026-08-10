using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Domain.Repositories.Interfaces
{
    public interface IProductRepository : IBasicRepository<Product>
    {
        Task<Product> getByName(string name);
    }
}
