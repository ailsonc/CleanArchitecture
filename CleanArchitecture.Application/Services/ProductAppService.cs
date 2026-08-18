using AutoMapper;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.ViewModels;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Domain.Services;

namespace CleanArchitecture.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductAppService(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task AddProduct(ProductBasicViewModel product)
        {
            var productAux = _mapper.Map<Product>(product);

            await _productService.add(productAux);
        }

        public async Task DeleteProduct(long idProduct)
        {
            await _productService.delete(idProduct);
        }

        public async Task<IEnumerable<ProductFullViewModel>> GetProductAll()
        {
            return _mapper.Map<IEnumerable<ProductFullViewModel>>(await _productService.getAll());
        }

        public async Task<ProductFullViewModel> GetProductById(long idProduct)
        {
            return _mapper.Map<ProductFullViewModel>(await _productService.getById(idProduct));
        }

        public async Task UpdateProduct(long idProduct, ProductBasicViewModel product)
        {
            var productAux = _mapper.Map<Product>(product);
            productAux.IdProduct = idProduct;
            await _productService.update(productAux);
        }
    }
}
