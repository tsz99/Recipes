using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Data
{
    public class AnalyzedInstructionStep
    {

        public int AnalyzedInstructionId { get; set; }

        public int StepId { get; set; }
    }
}
