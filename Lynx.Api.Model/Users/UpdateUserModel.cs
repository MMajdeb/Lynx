using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lynx.Api.Model.Users
{
    public class UpdateUserModel
    {
        public UpdateUserModel()
        {
            BusinessUnits = new int[0];
        }

        [Required]
        public string Username { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public DateTime LastConnection { get; set; }
        public int[] BusinessUnits { get; set; }
        [Required]
        public int ClientId { get; set; }
    }
}
