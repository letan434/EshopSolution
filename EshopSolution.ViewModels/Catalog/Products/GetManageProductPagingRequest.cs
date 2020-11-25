using System;
using System.Collections.Generic;
using EshopSolution.ViewModels.Common;

namespace EshopSolution.ViewModels.Catalog.Products
{
    public class GetManageProductPagingRequest : PagingRequestBase
    {
       public string Keyword { get; set; }
       public int? CategoryId { get; set; }
       public string LanguageId { get; set; }
    }
}
