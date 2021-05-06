using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MonthlyBudget.Models
{
    public class DescriptionCreate
    {
        public int DescriptionId { get; set; }
        [Display(Name = "Expense Description")]
        public string DescriptionName { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset ModifiedUtc { get; set; }
        public List<CheckingListItem> Entries { get; set; }
    }
}