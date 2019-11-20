using Lynx.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Text;

namespace Lynx.Data.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Cost { get; set; }
        public string Color { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Size { get; set; }
        public double Weight { get; set; }
        public byte[] Image { get; set; }
        public double WholeSalePrice { get; set; }
        public int MinQuantity { get; set; }
        public bool AlertQuantity { get; set; }
        public double LastPrice { get; set; }
        public double LastCost { get; set; }
        public string Notes { get; set; }
        public ItemType Type { get; set; }

        public int? GroupId { get; set; }
        public virtual Item Group { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int? DiscountId { get; set; }
        public virtual Discount Discount { get; set; }
        public int? TaxeId { get; set; }
        public virtual Taxe Taxe { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }

        public virtual IList<Item> Items { get; set; }
        public virtual IList<BillItem> BillItems { get; set; }
        public virtual IList<Unit> Units { get; set; }

    }
}
