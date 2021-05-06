using System.ComponentModel.DataAnnotations;

namespace MonthlyBudget.Models
{
    public class CategoryListItem
    {
        public int CategoryId { get; set; }
        [Display(Name = "Type of expense")]
        public string CategoryName { get; set; }
    }
}