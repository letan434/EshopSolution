using System;
using System.Collections.Generic;
using EshopSolution.ViewModels.Common;

namespace EshopSolution.ViewModels.Catalog.Products
{
    public class CategoryAssignRequest
    {
        public int Id { get; set; }
        public List<SelectItem> Categories { get; set; } = new List<SelectItem>();
    }
}
