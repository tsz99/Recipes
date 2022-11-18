using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Data
{
    public class RecipesResult
    {
        public List<Recipe> results { get; set; }
        public int offset { get; set; }
        public int number { get; set; }
        public int totalResults { get; set; }
    }

}
