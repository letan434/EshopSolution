﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using EshopSolution.ViewModels.Common;
using EshopSolution.ViewModels.System.Languages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace EshopSolution.AdminApp.Services
{
    public class LanguageApiClient : BaseApiClient, ILanguageApiClient
    {
        public LanguageApiClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration) :base(httpClientFactory,httpContextAccessor,configuration)
        {
        }

        public async Task<ApiResult<List<LanguageVm>>> GetAll()
        {
            return await GetAsync<ApiResult<List<LanguageVm>>>("/api/languages");
        }
    }
}
