using System;
using System.Collections.Generic;
using System.Text;

namespace Lynx.Api.Model.Users
{
    public class UserModel
    {
        public UserModel()
        {
            Roles = new string[0];
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }

        public string[] Roles { get; set; }
    }
}
