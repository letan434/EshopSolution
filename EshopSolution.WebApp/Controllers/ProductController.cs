using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshopSolution.Application.Catalog.Products;
using EshopSolution.Data.EF;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EshopSolution.WebApp.Controllers
{
    public class ProductController : Controller
    {
        // GET: /<controller>/
        private readonly EShopDbContext _context;
         //IPublicProductService _publicProductService;
        public ProductController( EShopDbContext context )
        {
            //_publicProductService = publicProductService;
            _context = context;
        }

        //[Route("products.html")]
        public IActionResult Index()
        {
            var productTranslations = _context.ProductTranslations;

            return View(productTranslations);
        }
        //[ChildActionOnly]
        //public PartialViewResult ProductCategory()
        //{
        //   var model = _publicProductService.GetAll();

        //}
    }
}
