using System.Collections.Generic;

namespace Lynx.Data.Models
{
    public class Taxe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }

        public virtual IList<Item> Items { get; set; }
    }
}