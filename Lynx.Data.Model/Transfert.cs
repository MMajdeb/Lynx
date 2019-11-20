using Lynx.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lynx.Data.Models
{
    public class Transfert
    {
        public int Id { get; set; }
        public TransfertType Type { get; set; }
        public int? FromBankId { get; set; }
        public virtual Bank FromBank { get; set; }
        public int? ToBankId { get; set; }
        public virtual Bank ToBank { get; set; }
        public int? FromCashierId { get; set; }
        public virtual Cashier FromCashier { get; set; }
        public int? ToCashierId { get; set; }
        public virtual Cashier ToCashier { get; set; }
        public double Amount { get; set; }
        public DateTime TransertDate { get; set; }
        public DateTime OperationDate { get; set; }
        public string Notes { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
