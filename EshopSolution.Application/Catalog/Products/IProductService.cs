using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EshopSolution.ViewModels.Catalog.ProductImages;
using EshopSolution.ViewModels.Catalog.Products;
using EshopSolution.ViewModels.Catalog.ProductTranslations;
using EshopSolution.ViewModels.Common;

namespace EshopSolution.Application.Catalog.Products
{
    public interface IProductService
    {
        Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);

        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int productId);

        Task<ProductViewModel> GetById(int productId, string languageId);

        Task<bool> UpdatePrice(int productId, decimal newPrice);

        Task<bool> UpdateStock(int productId, int addedQuantity);

        Task AddViewcount(int productId);

        Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);

        Task<int> AddImage(int productId, ProductImageCreateRequest request);

        Task<int> RemoveImage(int imageId);

        Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request);

        Task<ProductImageViewModel> GetImageById(int imageId);

        Task<List<ProductImageViewModel>> GetListImages(int productId);

        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(string languageId, GetPublicProductPagingRequest request);

        Task<int> AddProductTranslation(int productId, AddProductTranslationRequest request);
        Task<int> RemoveProductTranslation(int productTranslationId);
        Task<List<ProducTranslationViewModel>> GetListProductTranslations(int productId);
        Task<int> AddProductInCategory(int productId, int categoryId);
        Task<int> RemoveProductInCategory(int productId, int categoryId);

    }
}   
