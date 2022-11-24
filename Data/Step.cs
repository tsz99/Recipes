using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Data
{
    public class Step
    {
        [Key]
        public int StepId { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("step")]
        public string StepDescription { get; set; }

        [NotMapped]
        [JsonProperty("ingredients")]
        public List<Ingredient> Ingredients { get; set; }

        [NotMapped]
        [JsonProperty("equipment")]
        public List<Equipment> Equipment { get; set; }

    }

}
