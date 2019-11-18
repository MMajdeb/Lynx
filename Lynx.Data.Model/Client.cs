using System;
using System.Collections.Generic;
using System.Text;

namespace Lynx.Data.Models
{
    public class Client
    {
        public Client()
        {
            BusinessUnits = new List<BusinessUnit>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }

        public virtual IList<BusinessUnit> BusinessUnits { get; set; }
    }
}
