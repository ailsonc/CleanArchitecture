using CleanArchitecture.Domain.Models;
using CleanArchitecture.Domain.Repositories.Interfaces;
using CleanArchitecture.Domain.Services;

namespace CleanArchitecture.DomainServices.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task add(Category category)
        {
            var categoryAux = await _repository.getByDescription(category.Description);

            if (categoryAux != null)
                throw new ArgumentException("Category already exists");

            await _repository.add(category);
        }

        public async Task delete(long id)
        {
            var categoryAux = await _repository.getById(id);

            if (categoryAux == null)
                throw new ArgumentException("Category not found");

            await _repository.delete(id);
        }

        public async Task<IEnumerable<Category>> getAll()
        {
            return await _repository.getAll();
        }

        public async Task<Category> getById(long id)
        {
            return await _repository.getById(id);
        }

        public async Task update(Category category)
        {
            var categoryAux = await _repository.getById(category.IdCategory);

            if (categoryAux == null) 
                throw new ArgumentException("Category not found");

            categoryAux.Update(category.Description);

            await _repository.update(categoryAux);
        }
    }
}
