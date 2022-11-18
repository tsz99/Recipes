using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Recipes.Models;
using Recipes.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private FoodAPIService api;
        public HomeController(ILogger<HomeController> logger, FoodAPIService service)
        {
            _logger = logger;
            api = service;
            api.GetRecipes();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
