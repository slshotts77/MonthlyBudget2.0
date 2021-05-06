using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MonthlyBudget.Data
{
    public class PayingBy
    {
        [Key]
        public int PayById { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string CashOrCard { get; set; }
        public decimal CashAmount { get; set; }
        public string CardType { get; set; }
        public decimal CardNumber { get; set; }
        public string NameOnCard { get; set; }
        public string ExpirationDate { get; set; }
        public int SecurityCode { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public virtual ICollection<Checking> Entries { get; set; } = new List<Checking>();
    }
}