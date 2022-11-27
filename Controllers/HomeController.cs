using Microsoft.AspNetCore.Mvc;
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
        private List<Recipe> filteredRecipes;
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

        [HttpGet]
        public IActionResult Index(bool isGlutenFree = false, bool isDiaryFree = false, bool isVegan = false, bool isVegetarian = false, string title = "")
        {
            if (!isGlutenFree && !isDiaryFree && !isVegan && !isVegetarian && title == "")
            {
                List<Recipe> recipes = repo.GetAllRecipes(null);
                return View(new IndexVM()
                {
                    Recipes = recipes
                    ,IsDiaryFree = isDiaryFree
                    ,IsGlutenFree = isGlutenFree
                    ,IsVegan = isVegan
                    ,IsVegetarian = isVegetarian
                    ,Title = title
                });
            }
            List<Recipe> recipesFiltered = repo.GetRecipeByFilter(title, isVegetarian, isVegan, isGlutenFree, isDiaryFree);
             return View(new IndexVM()
                {
                    Recipes = recipesFiltered
                    ,IsDiaryFree = isDiaryFree
                    ,IsGlutenFree = isGlutenFree
                    ,IsVegan = isVegan
                    ,IsVegetarian = isVegetarian
                    ,Title = title
                });
        }

        [HttpPost]
        public IActionResult Search()
        {  
            var title = this.Request.Form["Title"].ToString();
            var isVegetarian = this.Request.Form.ContainsKey("Vegetarian");
            var isVegan = this.Request.Form.ContainsKey("Vegan");
            var isGlutenFree = this.Request.Form.ContainsKey("GlutenFree");
            var isDiaryFree = this.Request.Form.ContainsKey("DiaryFree");
            return RedirectToAction("Index", "Home", new { isGlutenFree = isGlutenFree, isDiaryFree = isDiaryFree, isVegan = isVegan, isVegetarian = isVegetarian, title = title });
        }

        [HttpGet]
        public IActionResult Create()
        {
            var allIngredients = repo.GetAllIngredients(null);
            return PartialView("~/Views/Home/PartialViews/_CreateRecipe.cshtml", new RecipeVM(allIngredients) { });
        }

        [HttpPost]
        public IActionResult Create(RecipeVM recipe)
        {
            this.Request.Form["Ingredients"].ToList().ForEach(x => recipe.Ingredients.Add(new Ingredient() { IngredientId = Int32.Parse(x) }));
            recipe.CreatorUser = "a";
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }
            repo.SaveUserCreatedRecipe(recipe.ToRecipe());
            return Json(new { success = true });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Recipe rec = repo.GetRecipeById(id);
            var allIngredients = repo.GetAllIngredients(null);
            return PartialView("~/Views/Home/PartialViews/_EditRecipe.cshtml", new RecipeVM(rec, allIngredients));
        }

        [HttpPost]
        public IActionResult Edit(RecipeVM recipe)
        {
            this.Request.Form["Ingredients"].ToList().ForEach(x => recipe.Ingredients.Add(new Ingredient() { IngredientId = Int32.Parse(x) }));
            recipe.CreatorUser = "a";
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }
            repo.EditRecipe(recipe.ToRecipe());
            return Json(new { success = true });
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
            Recipe rec = repo.GetRecipeById(id);
            return PartialView("~/Views/Home/PartialViews/_DeleteRecipe.cshtml", new DeleteVM()
            {
                DB_ID = rec.DB_ID,
                Title = rec.Title
            });
        }

        [HttpPost]
        public IActionResult Delete(DeleteVM deleteVM)
        {
            repo.DeleteRecipe(deleteVM.DB_ID);
            return Json(new { success = true });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
