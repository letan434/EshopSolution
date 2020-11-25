using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EshopSolution.ViewModels.Catalog.Categories;
using EshopSolution.ViewModels.Common;

namespace EshopSolution.Application.Catalog.Categories
{
    public interface ICategoryService
    {
        Task<int> Create(CategoryCreateRequest request);
        Task<CategoryViewModel> GetById(int categoryId, string languageId);
        Task<int> Update(CategoryUpdateRequest request);
        Task<List<CategoryVM>> GetAll(string languageId);
    }
}
