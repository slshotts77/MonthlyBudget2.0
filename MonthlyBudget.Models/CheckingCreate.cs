using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyBudget.Models
{
    public class CheckingCreate
    {
        [Display(Name = "Expense Description")]
        [MinLength(5, ErrorMessage = "Please enter at least 3 characters.")]
        [MaxLength(50, ErrorMessage = "Enter shorter name.")]
        public string CheckingName { get; set; }
        [Display(Name = "Reoccuring?")]
        public bool MonthlyBill { get; set; }
        [Required]
        [Display(Name = "Purchase Date")]
        public string ChargeDate { get; set; }
        [Display(Name = "Date Bank Cleared")]
        public string DateCleared { get; set; }
        [Display(Name = "Bank Note Cleared")]
        public bool Cleared { get; set; }


        [Required]
        public int UtilityCompanyId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int DescriptionId { get; set; }

        [Required]
        public int PayingById { get; set; }
    }
}