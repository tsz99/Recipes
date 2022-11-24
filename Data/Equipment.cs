using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Data
{
    public class Equipment
    {
        [Key]
        public int DB_ID { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("localizedName")]
        public string LocalizedName { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }
    }
}
