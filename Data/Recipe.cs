using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Recipes.Data
{
    public class Recipe
    {
        [Key]
        public int DB_ID { get; set; }

        [JsonProperty("vegetarian")]
        public bool Vegetarian { get; set; }

        [JsonProperty("vegan")]
        public bool Vegan { get; set; }

        [JsonProperty("glutenFree")]
        public bool GlutenFree { get; set; }

        [JsonProperty("dairyFree")]
        public bool DairyFree { get; set; }

        [JsonProperty("veryHealthy")]
        public bool VeryHealthy { get; set; }

        [JsonProperty("cheap")]
        public bool Cheap { get; set; }

        [JsonProperty("veryPopular")]
        public bool VeryPopular { get; set; }

        [JsonProperty("sustainable")]
        public bool Sustainable { get; set; }

        [JsonProperty("lowFodmap")]
        public bool LowFodmap { get; set; }

        [JsonProperty("weightWatcherSmartPoints")]
        public int WeightWatcherSmartPoints { get; set; }

        [JsonProperty("gaps")]
        public string Gaps { get; set; }

        [JsonProperty("preparationMinutes")]
        public int PreparationMinutes { get; set; }

        [JsonProperty("cookingMinutes")]
        public int CookingMinutes { get; set; }

        [JsonProperty("aggregateLikes")]
        public int AggregateLikes { get; set; }

        [JsonProperty("healthScore")]
        public int HealthScore { get; set; }

        [JsonProperty("creditsText")]
        public string CreditsText { get; set; }

        [JsonProperty("license")]
        public string License { get; set; }

        [JsonProperty("sourceName")]
        public string SourceName { get; set; }

        [JsonProperty("pricePerServing")]
        public double PricePerServing { get; set; }

        [JsonProperty("extendedIngredients")]
        public List<ExtendedIngredient> ExtendedIngredients { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("readyInMinutes")]
        public int ReadyInMinutes { get; set; }

        [JsonProperty("servings")]
        public int Servings { get; set; }

        [JsonProperty("sourceUrl")]
        public string SourceUrl { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("imageType")]
        public string ImageType { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("instructions")]
        public string Instructions { get; set; }

        [JsonProperty("analyzedInstructions")]
        public List<AnalyzedInstruction> AnalyzedInstructions { get; set; }

        [JsonProperty("spoonacularSourceUrl")]
        public string SpoonacularSourceUrl { get; set; }

        public string CreatorUser { get; set; }
    }
}
