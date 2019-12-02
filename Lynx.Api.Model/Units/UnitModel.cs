using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lynx.Api.Models
{
    public class UnitModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double QuantityMultiplier { get; set; }
        [Required]
        public double PriceMultiplier { get; set; }
        [Required]
        public int ItemId { get; set; }
        public string Notes { get; set; }
    }
}
