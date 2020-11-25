using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EshopSolution.ViewModels.Catalog.Products;
using EshopSolution.ViewModels.Common;

namespace EshopSolution.AdminApp.Services
{
    public interface IProductApiClient
    {
        //Task<PagedResult<ProductViewModel>> GetPagings(GetManageProductPagingRequest request);
        //Task<bool> CreateProduct(ProductCreateRequest request);
        //Task<ApiResult<bool>> Update(ProductUpdateRequest request);
        //Task<ApiResult<ProductUpdateRequest>> GetPoductUpdateById(int productId);
        //Task<ProductViewModel> GetbyId(int Id, string languageId);
        Task<PagedResult<ProductViewModel>> GetPagings(GetManageProductPagingRequest request);

        Task<bool> CreateProduct(ProductCreateRequest request);

        Task<bool> UpdateProduct(ProductUpdateRequest request);

        Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);

        Task<ProductViewModel> GetById(int id, string languageId);

        Task<List<ProductViewModel>> GetFeaturedProducts(string languageId, int take);

        Task<List<ProductViewModel>> GetLatestProducts(string languageId, int take);
        Task<bool> Delete(int id);
    }
}

