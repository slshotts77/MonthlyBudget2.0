using System.ComponentModel.DataAnnotations;

namespace MonthlyBudget.Models
{
    public class DescriptionEdit
    {
        public int DescriptionId { get; set; }
        [Display(Name = "Expense Description")]
        [MinLength(10, ErrorMessage = "Please enter at least 3 characters.")]
        [MaxLength(50, ErrorMessage = "Enter shorter name.")]
        public string DescriptionName { get; set; }
    }
}