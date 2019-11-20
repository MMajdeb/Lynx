using System;
using System.Collections.Generic;
using System.Text;

namespace Lynx.Data.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int PartnerId { get; set; }
        public virtual Partner Partner { get; set; }
        public int BillId { get; set; }
        public virtual Bill Bill { get; set; }
        public double Amount { get; set; }
        public double Rest { get; set; }
        public string Notes { get; set; }
    }
}
