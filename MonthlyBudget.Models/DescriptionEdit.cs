using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyBudget.Models
{
    public class DescriptionEdit
    {
        [Display(Name = "Description of purchase")]
        public string DescriptionName { get; set; }
    }
}
