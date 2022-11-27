using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Data
{
    public class AnalyzedInstruction
    {
        [Key]
        public int DB_ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [NotMapped]
        [JsonProperty("steps")]
        public List<Step> Steps { get; set; }
    }
}
