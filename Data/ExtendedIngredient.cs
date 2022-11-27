using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Data
{
    public class ExtendedIngredient
    {
        [Key]
        public int DB_ID { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("aisle")]
        public string Aisle { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("consistency")]
        public string Consistency { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nameClean")]
        public string NameClean { get; set; }

        [JsonProperty("original")]
        public string Original { get; set; }

        [JsonProperty("originalName")]
        public string OriginalName { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

    }
}
