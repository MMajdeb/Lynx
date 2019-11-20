using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Lynx.Data.Models
{
    public class Discount
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public double Value { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StartQuantity { get; set; }
        public int MaxQuantity { get; set; }
        public int LimitQuantity { get; set; }
        public string Color { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Size { get; set; }
        public string Notes { get; set; }

        public virtual IList<Item> Items { get; set; }
    }
}