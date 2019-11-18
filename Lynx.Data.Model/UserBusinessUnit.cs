using System;
using System.Collections.Generic;
using System.Text;

namespace Lynx.Data.Models
{
    public class UserBusinessUnit
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int BusinessUnitId { get; set; }
        public virtual BusinessUnit BusinessUnit { get; set; }
    }

}
