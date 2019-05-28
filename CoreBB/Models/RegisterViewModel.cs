using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace CoreBB.Models
{
    public class RegisterViewModel
    {
        [Required, DisplayName("Name")]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string Name { get; set; }
        [Required, DisplayName("Password")]
        [UIHint("Password")]
        public string Password { get; set; }
        [Required, DisplayName("Repeat Password")]
        [UIHint("Password")]
        public string RepeatPassword { get; set; }
        [Required, DisplayName("Self-Introduction")]
        public string Description { get; set; }

    }
}
