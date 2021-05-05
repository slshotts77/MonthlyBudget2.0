using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyBudget.Models
{
    public class CheckingListItem
    {
        public int CheckingId { get; set; }

        [Display(Name = "Description of expenditure")]
        public string CheckingName { get; set; }

        [Display(Name = "Check if this a mothly bill")]
        public bool MonthlyBill { get; set; }
      
        [Display(Name = "Date of purchase")]
        public String ChargeDate { get; set; }
        [Display(Name = "Date cleared with bank")]
        public String DateCleared { get; set; }
        [Display(Name = "Check if cleared with the bank")]
        public bool Cleared { get; set; }
        
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset ModifiedUtc { get; set; }

        public string UtilityComapny { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public string PayingBy { get; set; }
    }
}
