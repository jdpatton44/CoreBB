using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoreBB.Models
{
    public class LogInViewModel
    {
        [Required, DisplayName("Name")]
        public string Name { get; set; }
        [Required, DisplayName("Password")]
        public string Password { get; set; }
    }
}
