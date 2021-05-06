using System.ComponentModel.DataAnnotations;

namespace MonthlyBudget.Models
{
    public class DescriptionListItem
    {
        public int DescriptionId { get; set; }
        [Display(Name = "Description of purchase")]
        public string DescriptionName { get; set; }
    }
}