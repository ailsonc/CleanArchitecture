
using CleanArchitecture.Application.ViewModels;

namespace CleanArchitecture.Application.Interfaces
{
    public interface ICategoryAppService
    {
        Task AddCategory(CategoryBasicViewModel category);
        Task UpdateCategory(long idCategory, CategoryBasicViewModel category);
        Task DeleteCategory(long idCategory);
        Task<CategoryFullViewModel> GetCategoryById(long idCategory);
        Task<IEnumerable<CategoryFullViewModel>> GetCategoryAll();
    }
}
