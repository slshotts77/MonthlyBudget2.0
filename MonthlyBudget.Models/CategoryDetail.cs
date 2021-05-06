using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MonthlyBudget.Models
{
    public class CategoryDetail
    {
        public int CategoryId { get; set; }
        [Display(Name = "Type of expense")]
        public string CategoryName { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset ModifiedUtc { get; set; }
        public List<CheckingListItem> Entries { get; set; }
    }
}