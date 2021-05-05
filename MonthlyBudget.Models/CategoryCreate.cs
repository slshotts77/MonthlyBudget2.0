using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyBudget.Models
{
    public class CategoryCreate
    {       
        [Display(Name = "Type of expense")]
        [MinLength(3, ErrorMessage = "Please enter at least 3 characters.")]
        [MaxLength(25, ErrorMessage = "Enter shorter name.")]
        public string CategoryName { get; set; }
    }
}
