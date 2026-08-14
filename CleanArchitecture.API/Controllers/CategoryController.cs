using CleanArchitecture.Application.Services;
using CleanArchitecture.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryAppService categoryAppService;
        public CategoryController(ICategoryAppService categoryAppService)
        {
            this.categoryAppService = categoryAppService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryViewModel category)
        {
            await categoryAppService.AddCategory(category);
            return Ok();
        }
    }
}
