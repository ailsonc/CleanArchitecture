using CleanArchitecture.Application.ViewModels;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IProductAppService
    {
        Task AddProduct(ProductBasicViewModel product);
        Task UpdateProduct(long idProduct, ProductBasicViewModel product);
        Task DeleteProduct(long idProduct);
        Task<ProductFullViewModel> GetProductById(long idProduct);
        Task<IEnumerable<ProductFullViewModel>> GetProductAll();
    }
}
