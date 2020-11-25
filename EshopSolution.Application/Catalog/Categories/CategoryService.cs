using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using EshopSolution.Data.EF;
using EshopSolution.Data.Entities;
using EshopSolution.Utilities.Exceptions;
using EshopSolution.ViewModels.Catalog.Categories;
using Microsoft.EntityFrameworkCore;

namespace EshopSolution.Application.Catalog.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly EShopDbContext _context;
        public CategoryService(EShopDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(CategoryCreateRequest request)
        {
            var category = new Category
            {
                SortOrder = request.SortOrder,
                IsShowOnHome = request.IsShowOnHome,
                CategoryTranslations = new List<CategoryTranslation>()
                { new CategoryTranslation{
                    Name = request.Name,
                    LanguageId=request.LanguageId,
                    SeoAlias = request.SeoAlias,
                    SeoDescription =request.SeoDescription,
                    SeoTitle =request.SeoTitle
                }
                }
            };
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category.Id;
        }

        public async Task<List<CategoryVM>> GetAll(string languageId)
        {
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        where ct.LanguageId == languageId
                        select new { c, ct };
            return await query.Select(x => new CategoryVM()
            {
                Id = x.c.Id,
                Name = x.ct.Name
            }).ToListAsync();
        }

        public async Task<CategoryViewModel> GetById(int categoryId, string languageId)
        {
            var category = await _context.Categories.FindAsync(categoryId);
            var categoryTranslation = await _context.CategoryTranslations.FirstOrDefaultAsync(x => x.CategoryId == categoryId && x.LanguageId == languageId);
            var categoryVm = new CategoryViewModel()
            {
                Name = categoryTranslation.Name,
                SortOrder = category.SortOrder,
                IsShowOnHome = category.IsShowOnHome,
                SeoAlias = categoryTranslation.SeoAlias,
                SeoDescription = categoryTranslation.SeoDescription,
                SeoTitle = categoryTranslation.SeoTitle,
                Id = categoryId,
                LanguageId =languageId
            };
            return categoryVm;
        }

        public async Task<int> Update(CategoryUpdateRequest request)
        {
            var category = await _context.Categories.FindAsync(request.Id);
            var categoryTranslations = await _context.CategoryTranslations.FirstOrDefaultAsync(x => x.CategoryId == request.Id && x.LanguageId == request.LanguageId);
            if(category==null || categoryTranslations==null)  throw new EshopException($"Cannot find a product with id: {request.Id}");
            categoryTranslations.Name = request.Name;
            categoryTranslations.SeoAlias = request.SeoAlias;
            categoryTranslations.SeoDescription = request.SeoDescription;
            categoryTranslations.SeoTitle = request.SeoTitle;
            category.IsShowOnHome = request.IsShowOnHome;
            category.SortOrder = request.SortOrder;
            return await _context.SaveChangesAsync();

        }
    }
}
