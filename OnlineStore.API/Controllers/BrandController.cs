using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Repository;
using OnlineStore.Service.DTOs;
using OnlineStore.Service.Services.BrandService;


namespace OnlineStore.API.Controllers
{
    [Route("api/brand")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllBrands()
        {
            return Ok(await _brandService.GetAllBrands());
        }

    }
}