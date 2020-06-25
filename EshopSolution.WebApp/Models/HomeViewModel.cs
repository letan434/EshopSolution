using System;
using System.Collections.Generic;
using EshopSolution.ViewModels.Catalog.Products;

namespace EshopSolution.WebApp.Models
{
    public class HomeViewModel
    {
        public List<ProductViewModel> HotProduct { get; set; }
        public string Title { set; get; }
        public string MetaKeyword { set; get; }
        public string MetaDescription { set; get; }

    }
}
