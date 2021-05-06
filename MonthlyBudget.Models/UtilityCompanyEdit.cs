using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyBudget.Models
{
    public class UtilityCompanyEdit
    {
        public int UtilityCompanyId { get; set; }
        [Display(Name = "Utility Company Name")]
        public string UtilityName { get; set; }
        [Display(Name = "www.what.com")]
        public string Website { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        [Display(Name = "(123) 555-1234")]
        public string PhoneNumber { get; set; }
    }
}