using System;
using System.Collections.Generic;
using System.Text;

namespace Lynx.Data.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string About { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public double Revenue { get; set; }

        public virtual IList<BusinessUnit> BusinessUnits { get; set; }
        public virtual IList<User> Users { get; set; }
    }
}
