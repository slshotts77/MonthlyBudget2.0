﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MonthlyBudget.Models
{
    public class CheckingListItem
    {
        public int CheckingId { get; set; }
        [Display(Name = "Checking Name")]
        public string CheckingName { get; set; }
        [Display(Name = "Reoccuring?")]
        public bool MonthlyBill { get; set; }
        [Display(Name = "Date of purchase")]
        public String ChargeDate { get; set; }
        [Display(Name = "Date cleared with bank")]
        public String DateCleared { get; set; }
        [Display(Name = "Check if cleared with the bank")]
        public bool Cleared { get; set; }
        public string UtilityComapny { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string PayingBy { get; set; }
    }
}