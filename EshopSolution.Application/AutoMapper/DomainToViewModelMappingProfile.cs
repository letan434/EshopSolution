using AutoMapper;
using EshopSolution.Data.Entities;
using EshopSolution.ViewModels.Catalog.Categories;
using EshopSolution.ViewModels.Catalog.Products;

namespace EshopSolution.Application.AutoMapper
{
    internal class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Product, ProductViewModel>();
        }
    }
}