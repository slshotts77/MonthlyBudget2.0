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
        [Display(Name = "Type of expense")]
        [MinLength(5, ErrorMessage = "Please enter at least 3 characters.")]
        [MaxLength(50, ErrorMessage = "Enter shorter name.")]
        public string CheckingName { get; set; }
        
        [Display(Name = "Check if this a mothly bill")]
        public bool MonthlyBill { get; set; }
    
        [Required]
        [Display(Name = "Date of purchase")]
        public string ChargeDate { get; set; }

        [Display(Name = "Date cleared with bank")]
        public string DateCleared { get; set; }
        
        [Display(Name = "Check if cleared with the bank")]
        public bool Cleared { get; set; }
        
        public int UtilityCompanyId { get; set; }
        public int CategoryId { get; set; }
        public int DescriptionId { get; set; }
        public int PayingById { get; set; }
    }
}

