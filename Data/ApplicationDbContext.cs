using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Recipe> Recipes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Recipe>().HasData(
                new Recipe { Id = 1, Title = "Recipe_1", Image = "url", ImageType = "png"},
                new Recipe { Id = 2, Title = "Recipe_2", Image = "url", ImageType = "png" },
                new Recipe { Id = 3, Title = "Recipe_3", Image = "url", ImageType = "png" },
                new Recipe { Id = 4, Title = "Recipe_4", Image = "url", ImageType = "png" }
            );
        }
    }
}
