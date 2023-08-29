using Code.API.Data;
using Code.API.Models.Domain;
using Code.API.Models.DTOs;
using Code.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Code.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    { 
        
        private readonly ICategoryRepository _categoryRepository;
       

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request)
        {
            // Map DTO to Domain Models
            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };
            
            await _categoryRepository.CreateAsync(category);

            // Map Domain to DTO

            var response = new CategoryDto 
            {
                Id = category.Id,
                Name = request.Name,
                UrlHandle = request.UrlHandle 
            };

            return Ok(response); // Resposta HTTP 
            
        }
    }
}
