using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        
        public virtual ICollection<Checking> Entries { get; set; } = new List<Checking>();
    }
}
