namespace Lynx.Data.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double QuantityMultiplier { get; set; }
        public double PriceMultiplier { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public string Notes { get; set; }
    }
}