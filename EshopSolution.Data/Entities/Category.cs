﻿using System;
using System.Collections.Generic;
using EshopSolution.Data.Enums;

namespace EshopSolution.Data.Entities
{
    public class Category
    {
       public int Id { get; set; }
       public int SortOrder { get; set; }
        public bool IsShowOnHome { get; set; }
        public int? ParenId { get; set; }
        public Status Status { get; set; }
        public List<ProductInCategory> ProductInCategories { get; set; }
        public List<CategoryTranslation> CategoryTranslations { get; set; }

    }
}
