using AutoMapper;
using EshopSolution.Data.Entities;
using EshopSolution.ViewModels.Catalog.Products;

namespace EshopSolution.Application.AutoMapper
{
    internal class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            //CreateMap<ProductViewModel, Product>()
            //  .ConstructUsing(c => new Product(c.Price, c.OriginalPrice, c.Stock,
            //  c.ViewCount, c.DateCreated, c.SeoAlias));
        }
    }
}