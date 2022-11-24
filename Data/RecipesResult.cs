using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Data
{
    public class RecipesResult
    {
        [JsonProperty("recipes")]
        public List<Recipe> Recipes { get; set; }
        public int offset { get; set; }
        public int number { get; set; }
        public int totalResults { get; set; }
    }

}
