using Newtonsoft.Json;
using Recipes.Data;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Services
{
    public class FoodAPIService
    {
        public List<Recipe> GetRecipes()
        {
            var client = new RestClient("https://api.spoonacular.com/recipes/complexSearch?cuisine=italian&number=2");
            var request = new RestRequest();
            request.AddHeader("x-api-key", "06cc6c8dbb2f4624b74b643be0585d38");
            RestResponse response = client.Execute(request);
            RecipesResult result = JsonConvert.DeserializeObject<RecipesResult>(response.Content);
            return result.results;
        }
    }
}
