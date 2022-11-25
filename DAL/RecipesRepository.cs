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

        public void SaveDataset(List<Recipe> recipes)
        {
            foreach (var rec in recipes)
            {
                SaveRecipeRecursively(rec);
            }
            _db.SaveChanges();
        }

        public void SaveRecipeRecursively(Recipe rec)
        {
            var RecipeId = SaveRecipe(rec);
            foreach (var ai in rec.AnalyzedInstructions)
            {
                var AnalyzedInsId = SaveAnalyzedInstruction(ai);
                SaveRecipeAnalyzedInstruction(new RecipeAnalyzedInstruction
                {
                    AnalyzedInstructionId = AnalyzedInsId,
                    RecipeId = RecipeId
                });
                foreach (var st in ai.Steps)
                {
                    var StepId = SaveStep(st);
                    SaveAnalyzedInstructionStep(new AnalyzedInstructionStep
                    {
                        AnalyzedInstructionId = AnalyzedInsId,
                        StepId = StepId
                    });
                    foreach (var ing in st.Ingredients)
                    {
                        var IngId = SaveIngredient(ing);
                        SaveStepIngredient(new StepIngredient
                        {
                            IngredientId = IngId,
                            StepId = StepId
                        });
                    }

                    foreach (var eq in st.Equipment)
                    {
                        var EqId = SaveEquipment(eq);
                        SaveStepEquipment(new StepEquipment
                        {
                            EquipmentId = EqId,
                            StepId = StepId
                        });
                    }
                }
            }
            foreach (var exIng in rec.ExtendedIngredients)
            {
                var exIngId = SaveExtendedIngredient(exIng);
                SaveRecipeExtendedIngredient(new RecipeExtendedIngredient
                {
                    ExtendedIngredientId = exIngId,
                    RecipeId = RecipeId
                });
            }
            _db.SaveChanges();
        }
    
        private int SaveIngredient(Ingredient Ingredient)
        {
            var dbIngredient = _db.Ingredients.FirstOrDefault(x => (x.IngredientId == Ingredient.IngredientId));
            if (dbIngredient == null)
            {
                _db.Ingredients.Add(Ingredient);
                _db.SaveChanges();
                return Ingredient.IngredientId;
            }
            return dbIngredient.IngredientId;
        }

        private int SaveExtendedIngredient(ExtendedIngredient ExtendedIngredient)
        {
            var dbExtendedIngredient = _db.ExtendedIngredients.FirstOrDefault(x => (x.Id == ExtendedIngredient.Id));
            if (dbExtendedIngredient == null)
            {
                _db.ExtendedIngredients.Add(ExtendedIngredient);
                _db.SaveChanges();
                return ExtendedIngredient.Id;
            }
            return dbExtendedIngredient.Id;
        }

        private int SaveEquipment(Equipment Equipment)
        {
            var dbEquipment = _db.Equipments.FirstOrDefault(x => (x.Id == Equipment.Id));
            if (dbEquipment == null)
            {
                _db.Equipments.Add(Equipment);
                _db.SaveChanges();
                return Equipment.Id;
            }
            return dbEquipment.Id;
        }

        private int SaveAnalyzedInstruction(AnalyzedInstruction AnalyzedInstruction)
        {
            var dbAnalyzedInstruction = _db.AnalyzedInstructions.FirstOrDefault(x => (x.Name == AnalyzedInstruction.Name));
            if (dbAnalyzedInstruction == null)
            {
                _db.AnalyzedInstructions.Add(AnalyzedInstruction);
                _db.SaveChanges();
                return AnalyzedInstruction.DB_ID;
            }
            return dbAnalyzedInstruction.DB_ID;
        }

        private void SaveStepIngredient(StepIngredient stepIngredient)
        {
            var dbStepIngredient = _db.StepIngredients.FirstOrDefault(x => (x.IngredientId == stepIngredient.IngredientId && x.StepId == stepIngredient.StepId));
            if (dbStepIngredient == null)
            {
                _db.StepIngredients.Add(stepIngredient);
                _db.SaveChanges();
            }
        }

        private void SaveAnalyzedInstructionStep(AnalyzedInstructionStep AnalyzedInstructionStep)
        {
            var dbAnalyzedInstructionStep = _db.AnalyzedInstructionSteps.FirstOrDefault(x => (x.AnalyzedInstructionId == AnalyzedInstructionStep.AnalyzedInstructionId && x.StepId == AnalyzedInstructionStep.StepId));
            if (dbAnalyzedInstructionStep == null)
            {
                _db.AnalyzedInstructionSteps.Add(AnalyzedInstructionStep);
                _db.SaveChanges();
            }
        }

        private void SaveStepEquipment(StepEquipment stepEquipment)
        {
            var dbStepEquipment = _db.StepEquipments.FirstOrDefault(x => (x.EquipmentId == stepEquipment.EquipmentId && x.StepId == stepEquipment.StepId));
            if (dbStepEquipment == null)
            {
                _db.StepEquipments.Add(stepEquipment);
                _db.SaveChanges();
            }
        }

        private int SaveStep(Step step)
        {
            var dbStep = _db.Steps.FirstOrDefault(x => (x.StepId == step.StepId));
            if (dbStep == null)
            {
                _db.Steps.Add(step);
                _db.SaveChanges();
                return step.StepId;
            }
            return dbStep.StepId;
        }

        private void SaveRecipeExtendedIngredient(RecipeExtendedIngredient RecipeExtendedIngredient)
        {
            var dbRecipeExtendedIngredient = _db.RecipeExtendedIngredients.FirstOrDefault(x => (x.ExtendedIngredientId == RecipeExtendedIngredient.ExtendedIngredientId && x.RecipeId == RecipeExtendedIngredient.RecipeId));
            if (dbRecipeExtendedIngredient == null)
            {
                _db.RecipeExtendedIngredients.Add(RecipeExtendedIngredient);
                _db.SaveChanges();
            }
        }

        private void SaveRecipeAnalyzedInstruction(RecipeAnalyzedInstruction RecipeAnalyzedInstruction)
        {
            var dbRecipeAnalyzedInstruction = _db.RecipeAnalyzedInstructions.FirstOrDefault(x => (x.AnalyzedInstructionId == RecipeAnalyzedInstruction.AnalyzedInstructionId && x.RecipeId == RecipeAnalyzedInstruction.RecipeId));
            if (dbRecipeAnalyzedInstruction == null)
            {
                _db.RecipeAnalyzedInstructions.Add(RecipeAnalyzedInstruction);
                _db.SaveChanges();
            }
        }

        private int SaveRecipe(Recipe Recipe)
        {
            var dbRecipe = _db.Recipes.FirstOrDefault(x => (x.Id == Recipe.Id && x.CreatorUser == Recipe.CreatorUser));
            if (dbRecipe == null)
            {
                _db.Recipes.Add(Recipe);
                _db.SaveChanges();
                return Recipe.DB_ID;
            }
            return dbRecipe.DB_ID;
        }

        public Recipe GetRecipeById(int id)
        {
            var recipe = _db.Recipes.FirstOrDefault(x => x.DB_ID == id);
            if (recipe == null) return null;
            var analyzedInstructionIds = _db.RecipeAnalyzedInstructions.Where(x => x.RecipeId == recipe.DB_ID)
                                                                     .Select(y => y.AnalyzedInstructionId)
                                                                     .ToList();
            var analyzedInstructions = _db.AnalyzedInstructions.Where(x => analyzedInstructionIds.Contains(x.DB_ID)).ToList();
            
            foreach (var item in analyzedInstructions)
            {
                var stepIds = _db.AnalyzedInstructionSteps.Where(x => x.StepId == item.DB_ID)
                                                            .Select(y => y.AnalyzedInstructionId)
                                                            .ToList();
                var steps = _db.Steps.Where(x => stepIds.Contains(x.StepId)).ToList();
                foreach (var step in steps)
                {
                    var ingredientIds = _db.StepIngredients.Where(x => x.StepId == step.StepId)
                                                            .Select(y => y.IngredientId)
                                                            .ToList();
                    var ingredients = _db.Ingredients.Where(x => ingredientIds.Contains(x.IngredientId)).ToList();
                    step.Ingredients = ingredients;
                }
                item.Steps = steps;
            }
            recipe.AnalyzedInstructions = analyzedInstructions;

            var extendedIngredientIds = _db.RecipeExtendedIngredients.Where(x => x.RecipeId == recipe.DB_ID)
                                                                     .Select(y => y.ExtendedIngredientId)
                                                                     .ToList();
            var extendedIngredients = _db.ExtendedIngredients.Where(x => extendedIngredientIds.Contains(x.DB_ID)).ToList();
            recipe.ExtendedIngredients = extendedIngredients;

            return recipe;
        }

        public List<Recipe> GetRecipeByFilter(string? name = null, bool? vegetarian = null, bool? vegan = null, bool? glutenFree = null, bool? dairyFree = null)
        {
            return _db.Recipes
                            .Where(x => x.Vegetarian == vegetarian || vegetarian == null)
                            .Where(x => x.Vegan == vegan || vegan == null)
                            .Where(x => x.GlutenFree == glutenFree || glutenFree == null)
                            .Where(x => x.DairyFree == dairyFree || dairyFree == null)
                            .Where(x => x.Title.ToLower().Contains(name.ToLower()) || name == null)
                            .ToList();
                              
        }

        public List<Ingredient> GetAllIngredients(int? count)
        {
            return _db.Ingredients.ToList();
        }

        public List<Recipe> GetAllRecipes(int? count)
        {
            return _db.Recipes.ToList();
        }

    }
}
