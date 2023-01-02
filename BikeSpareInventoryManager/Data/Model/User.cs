using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSpareInventoryManager.Data.Model
{
    public class User
    {
        string _userType = "Staff";

        public Guid Guid { get; set; } = Guid.NewGuid();
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserType
        {
            get { return _userType; }
            set
            {
                if (value == "Admin" || value == "Staff")
                {
                    _userType = value;
                }
            }
        }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
