using Lynx.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lynx.Api.Models.BusinessUnit
{
    public class BusinessUnitModel
    {
        [Required]
        public string Name { get; set; }
        public string Reference { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string About { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public double Revenue { get; set; }
        public BusinessUnitType Type { get; set; }
        public int ManagerId { get; set; }
        [Required]
        public int ClientId { get; set; }
    }
}
