using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshopSolution.Application.Catalog.Products;
using EshopSolution.ViewModels.Catalog.ProductImages;
using EshopSolution.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EshopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {

            _productService = productService;

        }
        [Authorize]
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetManageProductPagingRequest request)
        {
            var products = await _productService.GetAllPaging(request);
            return Ok(products);
        }
        //http://localhost:port/products/public-paging
        //[HttpGet("public-paging")]
        //public async Task<IActionResult> Get(string languageId, [FromQuery]GetPublicProductPagingRequest request)
        //{
        //    var products = await _publicProductService.GetAllByCategoryId(languageId, request);
        //    return Ok(products);

        //}
        //http://localhost:port/products/1
        
        [HttpGet("{productId}/{languageId}")]
        public async Task<IActionResult> GetById(int productId, string languageId)
        {
            var product = await _productService.GetById(productId, languageId);
            if (product == null)
                return BadRequest("Cannot find product");
            return Ok(product);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productId = await _productService.Create(request);
            if (productId == 0)
                return BadRequest();

            var product = await _productService.GetById(productId, request.LanguageId);

            return CreatedAtAction(nameof(GetById), new { id = productId }, product);
        }
        [Authorize]
        [HttpPut("{productId}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update([FromRoute]int productId, [FromForm] ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.Id = productId;
            var affectedResult = await _productService.Update(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
        [Authorize]
        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(int productId)
        {
            var affectedResult = await _productService.Delete(productId);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
        [Authorize]
        [HttpPatch("{productId}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice(int productId, decimal newPrice)
        {
            var isSuccessful = await _productService.UpdatePrice(productId, newPrice);
            if (isSuccessful)
                return Ok();

            return BadRequest();
        }
        [Authorize]
        [HttpPost("{productId}/images")]
        public async Task<IActionResult> CreateImage(int productId, [FromForm] ProductImageCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var imageId = await _productService.AddImage(productId, request);
            if (imageId == 0)
                return BadRequest();

            var image = await _productService.GetImageById(imageId);

            return CreatedAtAction(nameof(GetImageById), new { id = imageId }, image);
        }
        [Authorize]
        [HttpPut("{productId}/mages/{imageId}")]
        public async Task<IActionResult> UpdateImage(int imageId, [FromForm] ProductImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productService.UpdateImage(imageId, request);
            if (result == 0)
                return BadRequest();


            return Ok();
        }
        [Authorize]
        [HttpDelete("{productId}/images/{imageId}")]
        public async Task<IActionResult> RemoveImage(int imageId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productService.RemoveImage(imageId);
            if (result == 0)
                return BadRequest();


            return Ok();
        }
        [HttpGet("{productId}/images/{imageId}")]
        public async Task<IActionResult> GetImageById(int imageId)
        {
            var image = await _productService.GetImageById(imageId);
            if (image == null)
                return BadRequest("Cannot find product");
            return Ok(image);
        }
        [HttpGet("{productId}/images")]
        public async Task<IActionResult> GetImagesById(int productId)
        {
            var images = await _productService.GetListImages(productId);
            if (images == null)
                return BadRequest("Cannot find product");
            return Ok(images);
        }
        [Authorize]
        [HttpPost("{productId}/productTranslations")]
        public async Task<IActionResult> UpdateProductTranslation(int productId, [FromQuery]AddProductTranslationRequest request)
        {
            var result =  await _productService.AddProductTranslation(productId, request);
            if (result ==0) return BadRequest();
            return Ok();
        }
        [Authorize]
        [HttpDelete("{productId}/productTranslations/{productTranslationId}")]
        public async Task<IActionResult> RemoveProductTranslation(int productTranslationId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _productService.RemoveProductTranslation(productTranslationId);
            if (result == 0) return BadRequest();
            return Ok();
        }
        [HttpGet("{productId}/productTranslations")]
        public async Task<IActionResult> GetProductTranslationByProductId(int productId)
        {
            var productTranslations = await _productService.GetListProductTranslations(productId);
            if (productTranslations == null) return BadRequest("can not find productTranslation by productId");
            return Ok(productTranslations);
        }
        [HttpPost("{productId}/productInCategoryId")]
        public async Task<IActionResult> AddProductInCatgory(int productId, int categoryId)
        {
            var result = await _productService.AddProductInCategory(productId, categoryId);
            if (result == 0) return BadRequest();
            return Ok(result);
        }
        [HttpDelete("{productId}/productInCategory/{categoryId}")]
        public async Task<IActionResult> RemoveProductInCategoryId(int productId, int categoryId)
        {
            var result = await _productService.RemoveProductInCategory(productId, categoryId);
            if (result == 0) return BadRequest();
            return Ok();
        }
        [HttpPut("{id}/categories")]
        public async Task<IActionResult> CategoryAssign(int id, [FromBody] CategoryAssignRequest request){
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productService.CategoryAssign(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}