using System;
using System.Collections.Generic;
using EshopSolution.ViewModels.Common;

namespace EshopSolution.ViewModels.System.Users
{
    public class RoleAssignRequest
    {
        public Guid Id { get; set; }
        public List<SelectItem> Roles { get; set; } = new List<SelectItem>();
    }
}
