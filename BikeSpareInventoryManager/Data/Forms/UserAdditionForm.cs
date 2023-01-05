using BikeSpareInventoryManager.Data.Model;
using System.ComponentModel.DataAnnotations;

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
