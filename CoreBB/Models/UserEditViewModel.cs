using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CoreBB.Models
{
    public class UserEditViewModel
    {
        [DisplayName("ID")]
        public int Id { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Current Password")]
        public string CurrentPassword { get; set; }

        [DisplayName("New Password")]
        public string Password { get; set; }

        [DisplayName("New Password Again")]
        public string RepeatPassword { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Administrator")]
        public bool IsAdministrator { get; set; }

        [DisplayName("Lock")]
        public bool IsLocked { get; set; }

        [DisplayName("Register Date")]
        public DateTime RegisterDateTime { get; set; }

        [DisplayName("Last Log In Date")]
        public DateTime LastLoginDateTime { get; set; }

        public static UserEditViewModel FromUser(User user)
        {
            var model = new UserEditViewModel();
            model.Id = user.Id;
            model.Name = user.Name;
            model.Description = user.Description;
            model.IsAdministrator = user.IsAdministrator;
            model.IsLocked = user.IsLocked;
            model.RegisterDateTime = user.RegisterDateTime;
            model.LastLoginDateTime = user.LastLogInDateTime;
            return model;
        }
    }
}
