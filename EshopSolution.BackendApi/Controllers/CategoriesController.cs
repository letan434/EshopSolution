using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshopSolution.Application.Catalog.Categories;
using EshopSolution.ViewModels.Catalog.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EshopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(string languageId)
        {
            var result = await _categoryService.GetAll(languageId);
            return Ok(result);
        }
        [HttpGet("{categoryId}/{languageId}")]
        public async Task<IActionResult> GetById(int categoryId, string languageId)
        {
            var category = await _categoryService.GetById(categoryId, languageId);
            if (category == null)
                return BadRequest("Cannot find c");
            return Ok(category);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CategoryCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var categoryId =  await _categoryService.Create(request);
            if (categoryId == 0)
            {
                return BadRequest();
            }
            var category =  await _categoryService.GetById(categoryId, request.LanguageId);
            return CreatedAtAction(nameof(GetById), new { id =categoryId}, category);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] CategoryUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var categoryId = await _categoryService.Update(request);
            if (categoryId == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
