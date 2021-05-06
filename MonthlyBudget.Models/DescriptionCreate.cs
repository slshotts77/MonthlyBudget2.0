using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyBudget.Models
{
    public class DescriptionCreate
    {
        [Display(Name = "Expense Description")]
        [MinLength(10, ErrorMessage = "Please enter at least 3 characters.")]
        [MaxLength(50, ErrorMessage = "Enter shorter name.")]
        public string DescriptionName { get; set; }
    }
}