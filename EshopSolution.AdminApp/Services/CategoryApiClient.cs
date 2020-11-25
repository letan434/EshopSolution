using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using EshopSolution.ViewModels.Catalog.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace EshopSolution.AdminApp.Services
{
    public class CategoryApiClient : BaseApiClient,ICategoryApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        public CategoryApiClient(IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<CategoryVM>> GetAll(string languageId)
        {
            var data = await GetListAsync<CategoryVM>("/api/categories?languageId=" + languageId);
            return data;
        }
        public async Task<CategoryVM> GetById(string languageId, int id)
        {
            return await GetAsync<CategoryVM>($"/api/categories/{id}/{languageId}");
        }
    }
}
