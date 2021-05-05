using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyBudget.Data
{
    public class Description
    {
        [Key]
        public int DescriptionId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        
        public string DescriptionName { get; set; }

        public virtual ICollection<Checking> Entries { get; set; } = new List<Checking>();
    }
}
