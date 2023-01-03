using BikeSpareInventoryManager.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSpareInventoryManager.Data.Forms
{
    public class UserAdditionForm
    {
        [Required] public string Username { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public UserType UserType { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string Password { get; set; }

        public User GetUser()
        {
            return new User { Username = this.Username, FirstName = this.FirstName, LastName = this.LastName, UserType = this.UserType, Email = this.Email, Password = HelperService.ConvertHash(this.Password) };
        }
    }
}
