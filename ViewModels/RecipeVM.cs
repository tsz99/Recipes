using Recipes.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.ViewModels
{
    public class RecipeVM
    {
        public RecipeVM()
        {
            Ingredients = new List<Ingredient>();
        }
        public RecipeVM(List<Ingredient> allIngredients)
        {
            Ingredients = new List<Ingredient>();
            AllIngredients = allIngredients;
        }
        public RecipeVM(Recipe r, List<Ingredient> allIngredients = null)
        {
            this.DB_ID = r.DB_ID;
            this.Vegetarian = r.Vegetarian;
            this.Vegan = r.Vegan;
            this.GlutenFree = r.GlutenFree;
            this.DairyFree = r.DairyFree;
            this.Id = r.Id;
            this.Title = r.Title;
            this.Image = r.Image;
            this.Summary = r.Summary;
            this.Instructions = r.Instructions;
            this.CreatorUser = r.CreatorUser;
            this.Ingredients = r.Ingredients;
            this.AllIngredients = allIngredients;
        }
        public int DB_ID { get; set; }

        public bool Vegetarian { get; set; }

        public bool Vegan { get; set; }

        public bool GlutenFree { get; set; }

        public bool DairyFree { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = "Title field must be filled")]
        [DisplayName("Title")]
        public string Title { get; set; }

        public string Image { get; set; }

        [Required]
        [DisplayName("Summary")]
        public string Summary { get; set; }

        [Required(ErrorMessage = "Instructions field must be filled!")]
        [DisplayName("Instructions")]
        public string Instructions { get; set; }

        public List<Ingredient> AllIngredients { get; set; }
        [DisplayName("Ingredients")]
        public List<Ingredient> Ingredients { get; set; }
        public string CreatorUser { get; set; }

        public Recipe ToRecipe()
        {
            return new Recipe()
            {
                DB_ID = this.DB_ID,
                Vegetarian = this.Vegetarian,
                Vegan = this.Vegan,
                GlutenFree = this.GlutenFree,
                DairyFree = this.DairyFree,
                Id = this.Id,
                Title = this.Title,
                Image = this.Image,
                Summary = this.Summary,
                Instructions = this.Instructions,
                CreatorUser = this.CreatorUser,
                Ingredients = this.Ingredients         
            };
        }
    }
}
