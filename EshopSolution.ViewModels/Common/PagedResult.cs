using System;
using System.Collections.Generic;

namespace EshopSolution.ViewModels.Common
{
    public class PagedResult<T>: PagedResultBase
    {
        public List<T> Items { get; set; }
    }
}
