using Lynx.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lynx.Data.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModificationDate { get; set; }
        public DateTime DueDate { get; set; }
        public double Total { get; set; }
        public double Net { get; set; }
        public double Taxe { get; set; }
        public double Paid { get; set; }
        public double Reste { get; set; }
        public double Discount { get; set; }
        public double Shippment { get; set; }
        public BillType Type { get; set; }
        public PaymentMethode PaymentMethode { get; set; }
        public string Street { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Mobile { get; set; }
        public string Notes { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int? PartnerId { get; set; }
        public virtual Partner Partner { get; set; }
        public int? BankId { get; set; }
        public virtual Bank Bank { get; set; }
        public int? CashierId { get; set; }
        public virtual Cashier Cashier { get; set; }
        public int BusinessUnitId { get; set; }
        public virtual BusinessUnit BusinessUnit { get; set; }

        public virtual IList<BillItem> Items { get; set; }
        public virtual IList<Payment> Payments { get; set; }
    }
}
