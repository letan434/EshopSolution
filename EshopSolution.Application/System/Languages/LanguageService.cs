using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshopSolution.Data.EF;
using EshopSolution.ViewModels.Common;
using EshopSolution.ViewModels.System.Languages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EshopSolution.Application.System.Languages
{
    public class LanguageService
    {
        private readonly IConfiguration _config;
        private readonly EShopDbContext _context;
        public LanguageService(IConfiguration config, EShopDbContext contex)
        {
            _config = config;
            _context = contex;
        }
        public async Task<ApiResult<List<LanguageVm>>> GetAll()
        {
            var languages = await _context.Languages.Select(x => new LanguageVm()
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
            return new ApiSuccessResult<List<LanguageVm>>(languages);
        }
    }
}
