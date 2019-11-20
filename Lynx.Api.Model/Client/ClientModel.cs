using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lynx.Api.Models.Client
{
    public class ClientModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string About { get; set; }
        public bool IsActive { get; set; }
        public double Revenue { get; set; }
    }
}
