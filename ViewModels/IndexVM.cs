using Recipes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.ViewModels
{
    public class IndexVM
    {
        public List<Recipe> Recipes { get; set; }
        public bool IsGlutenFree { get; set; }
        public bool IsDiaryFree { get; set; }
        public bool IsVegan { get; set; }
        public bool IsVegetarian { get; set; }
        public string Title { get; set; }
    }
}
