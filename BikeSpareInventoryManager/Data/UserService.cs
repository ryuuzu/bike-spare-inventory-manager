
/* Unmerged change from project 'BikeSpareInventoryManager (net6.0-windows10.0.19041.0)'
Before:
using System;
After:
using BikeSpareInventoryManager.Data;
using BikeSpareInventoryManager.Data.Model;
using System;
*/

/* Unmerged change from project 'BikeSpareInventoryManager (net6.0-ios)'
Before:
using System;
After:
using BikeSpareInventoryManager.Data;
using BikeSpareInventoryManager.Data.Model;
using System;
*/

/* Unmerged change from project 'BikeSpareInventoryManager (net6.0-android)'
Before:
using System;
After:
using BikeSpareInventoryManager.Data;
using BikeSpareInventoryManager.Data.Model;
using System;
*/
using BikeSpareInventoryManager.Data.Model;
using System.Text.Json;
/* Unmerged change from project 'BikeSpareInventoryManager (net6.0-windows10.0.19041.0)'
Before:
using System.Threading.Tasks;
using BikeSpareInventoryManager.Data;
using BikeSpareInventoryManager.Data.Model;
After:
using System.Threading.Tasks;
*/

/* Unmerged change from project 'BikeSpareInventoryManager (net6.0-ios)'
Before:
using System.Threading.Tasks;
using BikeSpareInventoryManager.Data;
using BikeSpareInventoryManager.Data.Model;
After:
using System.Threading.Tasks;
*/

/* Unmerged change from project 'BikeSpareInventoryManager (net6.0-android)'
Before:
using System.Threading.Tasks;
using BikeSpareInventoryManager.Data;
using BikeSpareInventoryManager.Data.Model;
After:
using System.Threading.Tasks;
*/


namespace BikeSpareInventoryManager.Data
{
    public class UserService
    {
        public static List<User> SetupUsers()
        {
            List<User> UsersList;
            try
            {
                UsersList = LoadAll();
            }
            catch (Exception)
            {
                UsersList = new List<User>
                {
                    new User{Username="adminboy", FirstName="Ram", LastName="Bahadur", UserType=UserType.Admin, Email="ram.bahadur@janatagarage.com.np", Password = HelperService.ConvertHash("Ram@123")},
                    new User{Username="admingirl", FirstName="Sita", LastName="Bahadurni", UserType=UserType.Admin, Email="sita.bahadurni@janatagarage.com.np", Password = HelperService.ConvertHash("Sita@123")},
                    new User{Username="userboy", FirstName="Ramu", LastName="Kumar", UserType=UserType.Staff, Email="ramu.bahadur@janatagarage.com.np", Password = HelperService.ConvertHash("Ram@123")},
                    new User{Username="usergirl", FirstName="Situ", LastName="Kumari", UserType=UserType.Staff, Email="situ.bahadurni@janatagarage.com.np", Password = HelperService.ConvertHash("Sita@123")},
                    new User{Username="random", FirstName="Random", LastName="Kumari", UserType=UserType.Staff, Email="random.bahadur@janatagarage.com.np", Password = HelperService.ConvertHash("Sita@123")},
                };
                SaveAll(UsersList);
            }
            return UsersList;
        }

        public static string GetUserFullName(Guid userId)
        {
            List<User> users = SetupUsers();
            User user = users.Find(usr => usr.Guid == userId);
            return $"{user.FirstName} {user.LastName}";
        }

        public static void SaveAll(List<User> UsersList)
        {
            string AppDirectoryPath = FilesUtils.GetAppDirectoryPath();
            string UsersFilesPath = FilesUtils.GetUsersFilePath();

            if (!Directory.Exists(AppDirectoryPath))
            {
                Directory.CreateDirectory(AppDirectoryPath);
            }

            string UserJSON = JsonSerializer.Serialize(UsersList);
            File.WriteAllText(UsersFilesPath, UserJSON);
        }

        public static List<User> LoadAll()
        {
            string UsersJSON = File.ReadAllText(FilesUtils.GetUsersFilePath());
            return JsonSerializer.Deserialize<List<User>>(UsersJSON);
        }

        public static List<User> LoginUser(string username, string password)
        {
            List<User> UsersList = SetupUsers();
            string HashedPassword = HelperService.ConvertHash(password);
            List<User> MatchedUser = UsersList.Where(User => (User.Username == username && User.Password == HashedPassword)).ToList();

            return MatchedUser;
        }
    }
}
