using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryAppService _categoryAppService;
        public CategoryController(ICategoryAppService categoryAppService)
        {
            this._categoryAppService = categoryAppService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryAppService.GetCategoryAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(long id)
        {
            var category = await _categoryAppService.GetCategoryById(id);
            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(long id, CategoryBasicViewModel category)
        {
            await _categoryAppService.UpdateCategory(id, category);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(long id)
        {
            await _categoryAppService.DeleteCategory(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryBasicViewModel category)
        {
            await _categoryAppService.AddCategory(category);
            return Ok();
        }
    }
}
