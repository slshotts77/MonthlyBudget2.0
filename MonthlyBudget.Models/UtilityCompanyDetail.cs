using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyBudget.Models
{
    public class UtilityCompanyDetail
    {
        public int UtilityCompanyId { get; set; }
        [Required]
        public string UtilityName { get; set; }
        [Required]
        [Display(Name = "www.what.com")]
        public string Website { get; set; }
        [Required]
        public string UserLogin { get; set; }
        [Required]
        public string UserPassword { get; set; }
        [Required]
        [Display(Name = "(123) 555-1234")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }


        public List<CheckingListItem> Entries { get; set; }
    }
}