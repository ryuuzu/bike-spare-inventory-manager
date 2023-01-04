using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BikeSpareInventoryManager.Data.Model;

namespace BikeSpareInventoryManager.Data
{
    public class GlobalState
    {
        public string PageName { get; set; } = "Home";
        public User CurrentUser { get; set; } = null;

        public Inventory CurrentInventory { get; set; } = InventoryService.SetupInventory();
        public LogsManager InvLogsManager { get; set; } = LogsManagerService.SetupManager();
        public bool DrawerOpen { get; set; } = true;
        public bool IsDarkMode { get; set; }

        public void RefreshInventory()
        {
            CurrentInventory = InventoryService.SetupInventory();
        }

        public void SaveInventory()
        {
            InventoryService.SaveInventory(CurrentInventory);
        }

        public void RefreshLogs()
        {
            InvLogsManager = LogsManagerService.SetupManager();
        }
        public void SaveLogs()
        {
            LogsManagerService.SaveLogs(InvLogsManager);
        }
    }
}
