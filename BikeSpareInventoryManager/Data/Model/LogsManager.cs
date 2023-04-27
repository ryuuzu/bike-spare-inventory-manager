using BikeSpareInventoryManager.Data.Exceptions;
using System.Text.Json;

namespace BikeSpareInventoryManager.Data.Model
{
    public class LogsManager
    {
        /*
         * Log manager class to create, update, delete the logs.
         * Also to perform other log specific tasks.
         * 
         * _inventoryLogs: All the logs from the system.
         * InventoryLogs: Accessor the the logs.
        */
        private List<InventoryLog> _inventoryLogs;

        public List<InventoryLog> InventoryLogs { get { return _inventoryLogs; } }

        // Method to get a count of all the logs pending (i.e. Not Approved by and admin)
        public int PendingLogsCount { get { return _inventoryLogs.Where(invLog => invLog.LogType == InvLogType.Withdraw && !invLog.IsApproved).ToList().Count; } }

        // Constructor to create logs manager from the list of logs
        public LogsManager(List<InventoryLog> inventoryLogs)
        {
            _inventoryLogs = inventoryLogs;
        }

        // Constructor to create logs manager from JSON file.
        public LogsManager(string InventoryLogsJSON)
        {
            _inventoryLogs = JsonSerializer.Deserialize<List<InventoryLog>>(InventoryLogsJSON);
        }

        // Method to get data to be saved into the JSON file.
        public string GetSaveJSON()
        {
            return JsonSerializer.Serialize(InventoryLogs);
        }

        // Method to get the last updated date of an item based on the newest logs.
        public DateTime GetLastUpdatedDate(Guid itemId)
        {
            List<InventoryLog> itemLogs = _inventoryLogs.Where(invLog => invLog.ItemId == itemId).ToList();
            if (itemLogs.Count == 0)
            {
                return DateTime.MinValue;
            }
            else
            {
                DateTime lastAddedDate = itemLogs.Aggregate((i1, i2) => i1.LogDate > i2.LogDate ? i1 : i2).LogDate;
                DateTime lastWithdrawDate = itemLogs.Aggregate((i1, i2) => i1.ApprovedAt > i2.ApprovedAt ? i1 : i2).ApprovedAt;
                if (lastAddedDate > lastWithdrawDate)
                {
                    return lastAddedDate;
                }
                return lastWithdrawDate;
            }
        }

        //Method to get item id that belongs to the log
        public Guid GetItemIdFromLog(Guid logId)
        {
            return _inventoryLogs.Find(inventoryLog => inventoryLog.Guid == logId).Guid;
        }

        //Method to get the inventory log based on the id
        public InventoryLog GetInventoryLog(Guid logId)
        {
            return _inventoryLogs.Find(inventoryLog => inventoryLog.Guid == logId);
        }

        //Method to approve the log.
        public void ApproveLog(Guid logGuid, User approver)
        {
            int invLogIndex = _inventoryLogs.FindIndex(inventoryLog => inventoryLog.Guid == logGuid);
            if (_inventoryLogs[invLogIndex].LogType != InvLogType.Withdraw)
            {
                throw new InvalidLogType("Withdraw Log Type was expected.");
            }
            if (_inventoryLogs[invLogIndex].IsApproved)
            {
                throw new LogAlreadyApproved("Log has already been approved");
            }
            _inventoryLogs[invLogIndex].IsApproved = true;
            _inventoryLogs[invLogIndex].ApprovedBy = approver.Guid;
            _inventoryLogs[invLogIndex].ApprovedAt = DateTime.Now;
        }

        //Method to remove the approval from a log
        public void RemoveApproval(Guid logGuid)
        {
            int invLogIndex = _inventoryLogs.FindIndex(inventoryLog => inventoryLog.Guid == logGuid);
            _inventoryLogs[invLogIndex].IsApproved = false;
            _inventoryLogs[invLogIndex].ApprovedBy = default;
            _inventoryLogs[invLogIndex].ApprovedAt = default;
        }

        //Method to get the total number of items that have been taken out from the system.
        public Dictionary<Guid, int> GetItemsTakenOut()
        {
            Dictionary<Guid, int> itemsTakenOutList = new();

            foreach (InventoryLog inventoryLog in InventoryLogs)
            {
                if (!inventoryLog.IsApproved)
                {
                    continue;
                }
                if (itemsTakenOutList.ContainsKey(inventoryLog.ItemId))
                {
                    itemsTakenOutList[inventoryLog.ItemId] += inventoryLog.Quantity;
                }
                else
                {
                    itemsTakenOutList[inventoryLog.ItemId] = inventoryLog.Quantity;
                }
            }

            return itemsTakenOutList;
        }
    }
}
