using Newtonsoft.Json;
using Recipes.DAL;
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
        private RecipesRepository repo;

        public FoodAPIService(RecipesRepository _repo)
        {
            repo = _repo;
        }

        public void GetRecipes()
        {
            var client = new RestClient("https://api.spoonacular.com/recipes/random?limitLicense=true&number=10");
            var request = new RestRequest();
            request.AddHeader("x-api-key", "06cc6c8dbb2f4624b74b643be0585d38");
            RestResponse response = client.Execute(request);
            RecipesResult result = JsonConvert.DeserializeObject<RecipesResult>(response.Content);
            repo.SaveDataset(result.Recipes);
        }
    }
}
