using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EshopSolution.BackendApi.Models;

namespace EshopSolution.BackendApi.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            return Ok();
        }

       
    }
}
