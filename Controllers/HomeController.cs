﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Recipes.DAL;
using Recipes.Data;
using Recipes.Models;
using Recipes.Services;
using Recipes.ViewModels;
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
        private RecipesRepository repo;

        public HomeController(ILogger<HomeController> logger, FoodAPIService service, RecipesRepository _repo)
        {
            _logger = logger;
            api = service;
            repo = _repo;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Index()
        {
            IEnumerable<Recipe> recipes = api.GetRecipes();
            return View(recipes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var allIngredients = repo.GetAllIngredients(null);
            return PartialView("~/Views/Home/PartialViews/_CreateRecipe.cshtml", new RecipeVM(allIngredients) { });
        }


        [HttpGet]
        public IActionResult Search()
        {
            List<Recipe> recipesFiltered = repo.GetRecipeByFilter();
            return View(recipesFiltered);
        }

        [HttpPost]
        public IActionResult Create(RecipeVM rec)
        { 
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }
            repo.SaveUserCreatedRecipe(rec.ToRecipe());
            return Json(new { success = true });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Recipe rec = repo.GetRecipeById(id);
            return PartialView("~/Views/Home/PartialViews/_EditRecipe.cshtml", rec);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Recipe rec = repo.GetRecipeById(id);
            return PartialView("~/Views/Home/PartialViews/_DetailsRecipe.cshtml", new RecipeVM(rec));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return PartialView("~/Views/Home/PartialViews/_DeleteRecipe.cshtml", id);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
