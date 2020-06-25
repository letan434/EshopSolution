using System;
using Microsoft.AspNetCore.Identity;

namespace EshopSolution.Data.Entities
{
    public class AppRole : IdentityRole<Guid>
    {
        public string  Description { get; set; }
    }
}
