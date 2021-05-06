﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MonthlyBudget.Data
{
    public class UtilityCompany
    {
        [Key]
        public int UtilityCompanyId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string UtilityName { get; set; }
        [Required]
        public string Website { get; set; }
        [Required]
        public string UserLogin { get; set; }
        [Required]
        public string UserPassword { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public virtual ICollection<Checking> Entries { get; set; } = new List<Checking>();
    }
}