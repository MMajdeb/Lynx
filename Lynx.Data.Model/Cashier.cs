using Lynx.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lynx.Data.Models
{
    public class Cashier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public CaisseType Type { get; set; }
        public string Notes { get; set; }
        public int BusinessUnitId { get; set; }
        public virtual BusinessUnit BusinessUnit { get; set; }

        public virtual IList<Bill> Bills { get; set; }
    }
}
