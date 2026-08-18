
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Domain.Repositories.Interfaces;
using CleanArchitecture.Domain.Services;

namespace CleanArchitecture.DomainServices.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task add(Product product)
        {
            await _repository.add(product);
        }

        public async Task delete(long id)
        {
            var productAux = await _repository.getById(id);

            if (productAux == null)
                throw new ArgumentException("Product not found");

            await _repository.delete(id);
        }

        public async Task<IEnumerable<Product>> getAll()
        {
            return await _repository.getAll();
        }

        public async Task<Product> getById(long id)
        {
            return await _repository.getById(id);
        }

        public async Task update(Product product)
        {
            var productAux = await _repository.getById(product.IdProduct);

            if (productAux == null)
                throw new ArgumentException("Product not found");

            productAux.Update(product.Name, product.Description, product.Price);

            await _repository.update(productAux);
        }
    }
}
