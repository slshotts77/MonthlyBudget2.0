using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyBudget.Models
{
    public class PayingByDetail
    {
        public int PayById { get; set; }
        [Display(Name = "Paid with cash, enter that amount")]
        public string CashOrCard { get; set; }
        public decimal CashAmount { get; set; }
        [Display(Name = "Example would be Debit or Credit Card-(last 4 of card")]
        public string CardType { get; set; }
        public decimal CardNumber { get; set; }
        public string NameOnCard { get; set; }
        public string ExpirationDate { get; set; }
        [Display(Name = "3 digit code on the back of the card")]
        public int SecurityCode { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset ModifiedUtc { get; set; }

        public List<CheckingListItem> Entries { get; set; }
    }
}