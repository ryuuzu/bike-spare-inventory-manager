
/* Unmerged change from project 'BikeSpareInventoryManager (net6.0-windows10.0.19041.0)'
Before:
using System;
After:
using BikeSpareInventoryManager.Data.Model;
using System;
*/

/* Unmerged change from project 'BikeSpareInventoryManager (net6.0-ios)'
Before:
using System;
After:
using BikeSpareInventoryManager.Data.Model;
using System;
*/

/* Unmerged change from project 'BikeSpareInventoryManager (net6.0-android)'
Before:
using System;
After:
using BikeSpareInventoryManager.Data.Model;
using System;
*/
using
/* Unmerged change from project 'BikeSpareInventoryManager (net6.0-windows10.0.19041.0)'
Before:
using BikeSpareInventoryManager.Data.Model;

namespace BikeSpareInventoryManager.Data
After:
namespace BikeSpareInventoryManager.Data
*/

/* Unmerged change from project 'BikeSpareInventoryManager (net6.0-ios)'
Before:
using BikeSpareInventoryManager.Data.Model;

namespace BikeSpareInventoryManager.Data
After:
namespace BikeSpareInventoryManager.Data
*/

/* Unmerged change from project 'BikeSpareInventoryManager (net6.0-android)'
Before:
using BikeSpareInventoryManager.Data.Model;

namespace BikeSpareInventoryManager.Data
After:
namespace BikeSpareInventoryManager.Data
*/
BikeSpareInventoryManager.Data.Model;

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
