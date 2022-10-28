using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapinAspNetCore.Models
{
    public class UserViewModel
    {
        [Display(Name ="FullName")]
        public string FullName { get; set; }
        [Display(Name ="Country")]
        public string  AddressCountry { get; set; }
        public string Email { get; set; }
    }
}
