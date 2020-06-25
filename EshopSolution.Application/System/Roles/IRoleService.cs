using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EshopSolution.ViewModels.System.Roles;

namespace EshopSolution.Application.System.Roles
{
    public interface IRoleService
    {
        Task<List<RoleVm>> GetAll();

    }
}
