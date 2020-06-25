﻿using System;
using Microsoft.AspNetCore.Http;

namespace EshopSolution.ViewModels.Catalog.Products
{
    public class ProductCreateRequest
    {

        public int Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public int Stock { get; set; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Details { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }

        public string SeoAlias { get; set; }
        public string LanguageId { set; get; }
        public IFormFile ThumbnailImage { get; set; }

    }
}
