using AutoMapper;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.ViewModels;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Domain.Services;
using CleanArchitecture.Domain.Validators;

namespace CleanArchitecture.Application.Services
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryAppService(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public async Task AddCategory(CategoryBasicViewModel category)
        {
            var validator = new CategoryValidator();
            var validationError = new List<string>();

            var categoryAux = _mapper.Map<Category>(category);

            var results = validator.Validate(categoryAux);

            if (!results.IsValid)
            {
                validationError.AddRange(results.Errors.Select(e => e.ErrorMessage));
                throw new InvalidOperationException("The following errors were found:" + string.Join(",", validationError));
            }

            await _categoryService.add(categoryAux);
        }

        public async Task DeleteCategory(long idCategory)
        {
            await _categoryService.delete(idCategory);
        }

        public async Task<IEnumerable<CategoryFullViewModel>> GetCategoryAll()
        {
            return _mapper.Map<IEnumerable<CategoryFullViewModel>>(await _categoryService.getAll());
        }

        public async Task<CategoryFullViewModel> GetCategoryById(long idCategory)
        {
            return _mapper.Map<CategoryFullViewModel>( await _categoryService.getById(idCategory));
        }

        public async Task UpdateCategory(long idCategory, CategoryBasicViewModel category)
        {
            var validator = new CategoryValidator();
            var validationError = new List<string>();

            var categoryAux = _mapper.Map<Category>(category);
            categoryAux.IdCategory = idCategory;

            var results = validator.Validate(categoryAux);

            if (!results.IsValid)
            {
                validationError.AddRange(results.Errors.Select(e => e.ErrorMessage));
                throw new InvalidOperationException("The following errors were found:" + string.Join(",", validationError));
            }
            await _categoryService.update(categoryAux);
        }
    }
}
