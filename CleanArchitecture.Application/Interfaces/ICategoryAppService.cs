
using CleanArchitecture.Application.ViewModels;

namespace CleanArchitecture.Application.Services
{
    public interface ICategoryAppService
    {
        Task AddCategory(CategoryViewModel category);
    }
}
