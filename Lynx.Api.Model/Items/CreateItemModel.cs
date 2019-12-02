using Lynx.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lynx.Api.Models
{
    public class CreateItemModel
    {
        [Required]
        public string Barcode { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
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
        public int? CategoryId { get; set; }
        public int? DiscountId { get; set; }
        public int? TaxeId { get; set; }
        [Required]
        public int StoreId { get; set; }
    }
}
