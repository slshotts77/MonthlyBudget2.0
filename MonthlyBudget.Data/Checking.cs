using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyBudget.Data
{
    public class Checking
    {
        [Key]
        public int CheckingId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string CheckingName { get; set; }

        public bool MonthlyBill { get; set; }

        [Required]
        public string ChargeDate { get; set; }
        public string DateCleared { get; set; }
        public bool Cleared { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }


        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }


        [ForeignKey(nameof(UtilityCompany))]
        public int UtilityCompanyId { get; set; }
        public virtual UtilityCompany UtilityCompany { get; set; }


        [ForeignKey(nameof(Description))]
        public int DescriptionId { get; set; }
        public virtual Description Description { get; set; }


        [ForeignKey(nameof(PayingBy))]
        public int PayingById { get; set; }
        public virtual PayingBy PayingBy { get; set; }

        
        
        //public virtual ICollection<Checking> ListOfEntries { get; set; } = new List<Checking>();
    }
}
