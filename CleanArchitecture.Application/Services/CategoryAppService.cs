using CleanArchitecture.Application.ViewModels;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Domain.Services;

namespace CleanArchitecture.Application.Services
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly ICategoryService _categoryService;
        public CategoryAppService(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task AddCategory(CategoryViewModel category)
        {
            var categoryAux = new Category
            {
                Description = category.Description,
                RegistrationDate = DateTime.Now
            };

            await _categoryService.add(categoryAux);
        }
    }
}
