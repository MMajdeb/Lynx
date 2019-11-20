using System;
using System.Collections.Generic;
using System.Text;

namespace Lynx.Api.Model.Users
{
    public class UserModel
    {
        public UserModel()
        {
            BusinessUnits = new int[0];
        }

        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastConnection { get; set; }
        public int[] BusinessUnits { get; set; }
        public int ClientId { get; set; }
    }
}
