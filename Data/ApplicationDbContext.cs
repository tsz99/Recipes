using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<AnalyzedInstruction> AnalyzedInstructions { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<ExtendedIngredient> ExtendedIngredients { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<AnalyzedInstructionStep> AnalyzedInstructionSteps { get; set; }
        public DbSet<RecipeAnalyzedInstruction> RecipeAnalyzedInstructions { get; set; }
        public DbSet<RecipeExtendedIngredient> RecipeExtendedIngredients { get; set; }
        public DbSet<StepEquipment> StepEquipments { get; set; }
        public DbSet<StepIngredient> StepIngredients { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AnalyzedInstructionStep>()
                .HasKey(x => new { x.StepId, x.AnalyzedInstructionId });
            builder.Entity<RecipeAnalyzedInstruction>()
                .HasKey(x => new { x.AnalyzedInstructionId, x.RecipeId });
            builder.Entity<RecipeExtendedIngredient>()
                .HasKey(x => new { x.ExtendedIngredientId, x.RecipeId });
            builder.Entity<StepEquipment>()
                .HasKey(x => new { x.StepId, x.EquipmentId });
            builder.Entity<StepIngredient>()
                .HasKey(x => new { x.StepId, x.IngredientId });
        }
    }
}
