using BikeSpareInventoryManager.Data.Model;
using System.Text.Json;

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

        public static void AddInventoryLog(InventoryLog invLog)
        {
            List<InventoryLog> inventoryLogs = SetupInventoryLogs();
            inventoryLogs.Add(invLog);
            SaveAll(inventoryLogs);
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
                List<InvLogType> invLogType = new() { InvLogType.Add, InvLogType.Withdraw };
                for (int i = 0; i < 10; i++)
                {
                    InventoryLogs.Add(new InventoryLog
                    {
                        ItemId = CurrentInventory.InventoryItems[random.Next(CurrentInventory.InventoryItems.Count)].Guid,
                        Quantity = random.Next(30),
                        LogAuthor = AllUsers[random.Next(AllUsers.Count)].Guid,
                        LogDate = DateTime.Now,
                        LogType = invLogType[random.Next(2)]
                    });
                }
                SaveAll(InventoryLogs);
            }
            return InventoryLogs;
        }
    }
}
