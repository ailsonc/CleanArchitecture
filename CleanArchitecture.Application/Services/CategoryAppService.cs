using AutoMapper;
using CleanArchitecture.Application.ViewModels;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Domain.Services;

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
        public async Task AddCategory(CategoryViewModel category)
        {
            var categoryAux = _mapper.Map<Category>(category);

            await _categoryService.add(categoryAux);
        }
    }
}
