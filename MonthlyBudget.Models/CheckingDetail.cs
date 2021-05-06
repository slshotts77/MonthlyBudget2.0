using System;
using System.ComponentModel.DataAnnotations;

namespace MonthlyBudget.Models
{
    public class CheckingDetail
    {
        public int CheckingId { get; set; }
        [Display(Name = "Expense Description")]
        public string CheckingName { get; set; }
        [Display(Name = "Reoccuring?")]
        public bool MonthlyBill { get; set; }
        [Display(Name = "Purchase Date")]
        public String ChargeDate { get; set; }
        [Display(Name = "Date Bank Cleared")]
        public String DateCleared { get; set; }
        [Display(Name = "Bank Note Cleared")]
        public bool Cleared { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public string UtilityComapny { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string PayingBy { get; set; }
    }
}