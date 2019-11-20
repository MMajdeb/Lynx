using Lynx.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lynx.Data.Models
{
    public class Partner
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Reference { get; set; }
        public PartnerType Type { get; set; }
        public string Mobile { get; set; }
        public string Street { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public double Balance { get; set; }
        public DateTime LastOperation { get; set; }
        public string Notes { get; set; }

        public virtual IList<Bill> Bills { get; set; }
    }
}
