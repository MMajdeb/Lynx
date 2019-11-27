using System.Collections.Generic;

namespace Lynx.Data.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BusinessUnitId { get; set; }
        public virtual BusinessUnit BusinessUnit { get; set; }
        public bool IsDeleted { get; set; }

        public virtual IList<Item> Items { get; set; }
    }
}