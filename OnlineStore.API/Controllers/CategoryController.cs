using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Repository;
using OnlineStore.Service.DTOs;
using OnlineStore.Service.Services.CategoryService;


namespace OnlineStore.API.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCategories()
        {
            return Ok(await _categoryService.GetAllCategories());
        }
    }
}
