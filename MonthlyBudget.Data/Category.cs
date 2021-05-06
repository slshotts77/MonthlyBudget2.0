using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MonthlyBudget.Data
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public virtual ICollection<Checking> Entries { get; set; } = new List<Checking>();
    }
}