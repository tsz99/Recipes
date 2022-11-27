using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Recipes.DAL;
using Recipes.Data;
using Recipes.Models;
using Recipes.Services;
using Recipes.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Controllers
{
    public class HomeController : Controller
    {
        private RecipesRepository repo;
        public HomeController(RecipesRepository _repo)
        {
            repo = _repo;
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
            recipe.CreatorUser = User.Identity.Name;
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
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
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
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

        [HttpGet]
        public FileResult Download(int id)
        {
            Recipe rec = repo.GetRecipeById(id);
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(rec.Title);

            builder.AppendLine("Summary");
            builder.AppendLine(rec.Summary);

            string glutenFreeText = rec.GlutenFree == true ? "yes" : "no";
            builder.AppendLine($"Is gluten free: {glutenFreeText}");

            string vegetarianText = rec.Vegetarian == true ? "yes" : "no";
            builder.AppendLine($"Is vegetarian: {vegetarianText}");

            string veganText = rec.Vegan == true ? "yes" : "no";
            builder.AppendLine($"Is vegan: {veganText}");

            string dairyFreeText = rec.DairyFree == true ? "yes" : "no";
            builder.AppendLine($"Is dairy free: {dairyFreeText}");

            builder.AppendLine("Instructions");
            builder.AppendLine(rec.Instructions);

            builder.AppendLine("Ingredients");
            foreach (var item in rec.Ingredients)
            {
                builder.AppendLine(item.Name);
            }

            var stream = new MemoryStream(Encoding.ASCII.GetBytes(builder.ToString()));
            return new FileStreamResult(stream, new MediaTypeHeaderValue("text/plain"))
            {
                FileDownloadName = $"{rec.Title}.txt"
            };
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
