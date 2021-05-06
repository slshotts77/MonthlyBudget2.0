using System;
using System.ComponentModel.DataAnnotations;

namespace MonthlyBudget.Models
{
    public class CheckingEdit
    {
        public int CheckingId { get; set; }
        [Display(Name = "Expense Description")]
        [MinLength(5, ErrorMessage = "Please enter at least 3 characters.")]
        [MaxLength(50, ErrorMessage = "Enter shorter name.")]
        public string CheckingName { get; set; }
        [Display(Name = "Reoccuring?")]
        public bool MonthlyBill { get; set; }
        [Display(Name = "Purchase Date")]
        public String ChargeDate { get; set; }
        [Display(Name = "Date Bank CLeared")]
        public String DateCleared { get; set; }
        [Display(Name = "Bank Note Cleared")]
        public bool Cleared { get; set; }


        public int UtilityCompanyId { get; set; }

        public int CategoryId { get; set; }

        public int DescriptionId { get; set; }

        public int PayingById { get; set; }
    }
}