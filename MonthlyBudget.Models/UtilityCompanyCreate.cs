using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyBudget.Models
{
    public class UtilityCompanyCreate
    {
        [Display(Name = "Utility Company Name")]
        public string Name { get; set; }
        [Display(Name = "www.what.com")]
        public string Website { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        [Display(Name = "(123) 555-1234")]
        public string PhoneNumber { get; set; }
    }
}
