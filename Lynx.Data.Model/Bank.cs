using Lynx.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lynx.Data.Models
{
    public class Bank
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string Iban { get; set; }
        public string Balance { get; set; }
        public BankType Type { get; set; }
        public string Notes { get; set; }

        public virtual IList<Bill> Bills { get; set; }
    }
}
