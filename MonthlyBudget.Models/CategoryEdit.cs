using System.ComponentModel.DataAnnotations;

namespace MonthlyBudget.Models
{
    public class CategoryEdit
    {
        [Display(Name = "Type of expense")]
        [MinLength(3, ErrorMessage = "Please enter at least 3 characters.")]
        [MaxLength(25, ErrorMessage = "Enter shorter name.")]
        public string CategoryName { get; set; }
    }
}