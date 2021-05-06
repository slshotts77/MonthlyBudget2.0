using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyBudget.Models
{
    public class CategoryListItem
    {
        [Display(Name = "Entry Id")]
        public int CategoryId { get; set; }
        [Display(Name = "Type of expense")]
        public string CategoryName { get; set; }
    }
}