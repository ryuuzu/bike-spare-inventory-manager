 using BikeSpareInventoryManager.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BikeSpareInventoryManager.Data
{
    public class LogsManagerService
    {
        public static LogsManager LoadLogs()
        {
            string InventoryLogsJSON = File.ReadAllText(FilesUtils.GetInventoryLogsFilePath());
            return new LogsManager(InventoryLogsJSON);
        }

        public static void SaveLogs(LogsManager logsManager)
        {
            string AppDirectoryPath = FilesUtils.GetAppDirectoryPath();
            string InventoryLogsFilePath = FilesUtils.GetInventoryLogsFilePath();

            if (!Directory.Exists(AppDirectoryPath))
            {
                Directory.CreateDirectory(AppDirectoryPath);
            }

            File.WriteAllText(InventoryLogsFilePath, logsManager.GetSaveJSON());
        }

        public static LogsManager SetupManager()
        {
            LogsManager logsManager;

            try
            {
                logsManager = LoadLogs();
            }
            catch (Exception e)
            {
                List<User> AllUsers = UserService.SetupUsers();
                Inventory CurrentInventory = InventoryService.SetupInventory();
                Random random = new Random();
                List<InventoryLog> inventoryLogs = new();
                List<InvLogType> invLogType = new() { InvLogType.Add, InvLogType.Withdraw };
                for (int i = 0; i < 10; i++)
                {
                    inventoryLogs.Add(new InventoryLog
                    {
                        ItemId = CurrentInventory.InventoryItems[random.Next(CurrentInventory.InventoryItems.Count)].Guid,
                        Quantity = random.Next(30),
                        LogAuthor = AllUsers[random.Next(AllUsers.Count)].Guid,
                        LogDate = DateTime.Now,
                        LogType = invLogType[random.Next(2)]
                    });
                }

                logsManager = new(inventoryLogs);
                SaveLogs(logsManager);
            }

            return logsManager;
        }
    }
}
