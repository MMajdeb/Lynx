using Lynx.Enum;
using System.Collections.Generic;

namespace Lynx.Data.Models
{
    public class BusinessUnit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TaxeResisterNumber { get; set; }
        public string phone { get; set; }
        public string About { get; set; }
        public string Adress { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public double Revenue { get; set; }
        public BusinessUnitType Type { get; set; }
        public int ManagerId { get; set; }
        public virtual User Manager { get; set; }

        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }

}