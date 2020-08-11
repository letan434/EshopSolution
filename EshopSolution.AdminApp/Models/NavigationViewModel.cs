using System;
using System.Collections.Generic;
using EshopSolution.ViewModels.System.Languages;

namespace EshopSolution.AdminApp.Models
{
    public class NavigationViewModel
    {
        public List<LanguageVm> Languages { get; set; }
        public string CurrentLanguageId { get; set; }
    }
}
