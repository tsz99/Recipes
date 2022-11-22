using Recipes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.DAL
{
    public class RecipesRepository
    {
        private ApplicationDbContext _db;
        public RecipesRepository(ApplicationDbContext _context)
        {
            _db = _context;
        }

        public void SaveRecipe(Recipe r)
        {
            _db.Recipes.Add(r);
            _db.SaveChanges();
        }

        public Recipe GetRecipeById(int id)
        {
           return _db.Recipes.FirstOrDefault(x => x.Id == id);
        }

        public List<Recipe> GetAllRecipes()
        {
            return _db.Recipes.ToList();
        }

    }
}
