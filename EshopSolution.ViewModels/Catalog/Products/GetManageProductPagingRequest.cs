using System;
using System.Collections.Generic;
using EshopSolution.ViewModels.Common;

namespace EshopSolution.ViewModels.Catalog.Products
{
    public class GetManageProductPagingRequest : PagingRequestBase
    {
       public string Keyword { get; set; }
       public List<int> CategoryIds { get; set; }
       
    }
}
