namespace Lynx.Data.Models
{
    public class BillItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int? UnitId { get; set; }
        public virtual Unit Unit { get; set; }
        public double Total { get; set; }
        public double Discount { get; set; }
        public double Taxe { get; set; }
        public double Net { get; set; }
        public string Notes { get; set; }
    }
}