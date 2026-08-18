using AutoMapper;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.ViewModels;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Domain.Services;
using CleanArchitecture.Domain.Validators;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            var validator = new ProductValidator();
            var validationError = new List<string>();

            var productAux = _mapper.Map<Product>(product);

            var results = validator.Validate(productAux);
            
            if (!results.IsValid)
            {
                validationError.AddRange(results.Errors.Select(e => e.ErrorMessage));
                throw new InvalidOperationException("The following errors were found:" + string.Join(",", validationError));
            }

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
            var validator = new ProductValidator();
            var validationError = new List<string>();

            var productAux = _mapper.Map<Product>(product);
            productAux.IdProduct = idProduct;

            var results = validator.Validate(productAux);

            if (!results.IsValid)
            {
                validationError.AddRange(results.Errors.Select(e => e.ErrorMessage));
                throw new InvalidOperationException("The following errors were found:" + string.Join(",", validationError));
            }
            await _productService.update(productAux);
        }
    }
}
