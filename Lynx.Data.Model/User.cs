using System;
using System.Collections.Generic;
using System.Text;

namespace Lynx.Data.Models
{
    public class User
    {
        public User()
        {
            Roles = new List<UserRole>();
            BusinessUnits = new List<BusinessUnit>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public virtual IList<UserRole> Roles { get; set; }
        public virtual IList<BusinessUnit> BusinessUnits { get; set; }
    }
}
