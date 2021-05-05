using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyBudget.Models
{
    public class DescriptionDetail
    {
        public int DescriptionId { get; set; }
        [Display(Name = "Description of purchase")]
        public string DescriptionName { get; set; }

        public List<DescriptionListItem> Descriptions { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
