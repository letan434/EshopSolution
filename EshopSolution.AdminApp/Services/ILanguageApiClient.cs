using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EshopSolution.ViewModels.Common;
using EshopSolution.ViewModels.System.Languages;

namespace EshopSolution.AdminApp.Services
{
    public interface ILanguageApiClient
    {
        Task<ApiResult<List<LanguageVm>>> GetAll();

    }
}
