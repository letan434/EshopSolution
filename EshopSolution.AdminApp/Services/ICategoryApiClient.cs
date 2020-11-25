using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EshopSolution.ViewModels.Catalog.Categories;

namespace EshopSolution.AdminApp.Services
{
    public interface ICategoryApiClient
    {
        Task<CategoryVM> GetById(string languageId, int id);

        Task<List<CategoryVM>> GetAll(string languageId);
    }
}
