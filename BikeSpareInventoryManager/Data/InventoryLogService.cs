using BikeSpareInventoryManager.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BikeSpareInventoryManager.Data
{
    public class InventoryLogService
    {
        public static void SaveAll(List<InventoryLog> InvLogs)
        {
            string AppDirectoryPath = FilesUtils.GetAppDirectoryPath();
            string InventoryLogsFilePath = FilesUtils.GetInventoryLogsFilePath();

            if (!Directory.Exists(AppDirectoryPath))
            {
                Directory.CreateDirectory(AppDirectoryPath);
            }

            string UserJSON = JsonSerializer.Serialize(InvLogs);
            File.WriteAllText(InventoryLogsFilePath, UserJSON);
        }

        public static List<InventoryLog> LoadAll()
        {
            string InventoryLogsJSON = File.ReadAllText(FilesUtils.GetInventoryLogsFilePath());
            return JsonSerializer.Deserialize<List<InventoryLog>>(InventoryLogsJSON);
        }

        public static List<InventoryLog> SetupInventoryLogs()
        {
            List<InventoryLog> InventoryLogs;
            try
            {
                InventoryLogs = LoadAll();
            }
            catch (Exception)
            {
                List<User> AllUsers = UserService.SetupUsers();
                Inventory CurrentInventory = InventoryService.SetupInventory();
                Random random = new Random();
                InventoryLogs = new List<InventoryLog>();
                for (int i = 0; i < 5; i++)
                {
                    InventoryLogs.Add(new InventoryLog
                    {
                        ItemId = CurrentInventory.InventoryItems[random.Next(CurrentInventory.InventoryItems.Count)].Guid,
                        Quantity = random.Next(30),
                        RequestedBy = AllUsers[random.Next(AllUsers.Count)].Guid,
                        RequestedAt = DateTime.Now
                    });
                }
                SaveAll(InventoryLogs);
            }
            return InventoryLogs;
        }
    }
}
