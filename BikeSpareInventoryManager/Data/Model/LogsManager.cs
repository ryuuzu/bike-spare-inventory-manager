using BikeSpareInventoryManager.Data.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BikeSpareInventoryManager.Data.Model
{
    public class LogsManager
    {
        private List<InventoryLog> _inventoryLogs;

        public List<InventoryLog> InventoryLogs { get { return _inventoryLogs; } }

        public LogsManager(List<InventoryLog> inventoryLogs)
        {
            _inventoryLogs = inventoryLogs;
        }

        public string GetSaveJSON()
        {
            return JsonSerializer.Serialize(InventoryLogs);
        }

        public DateTime GetLastUpdatedDate(Guid itemId)
        {
            List<InventoryLog> itemLogs = _inventoryLogs.Where(invLog => invLog.ItemId == itemId).ToList();
            if (itemLogs.Count == 0)
            {
                return DateTime.MinValue;
            }
            else
            {
                return itemLogs.Aggregate((i1, i2) => i1.ApprovedAt > i2.ApprovedAt ? i1 : i2).ApprovedAt;
            }
        }

        public Guid GetItemIdFromLog(Guid logId)
        {
            return _inventoryLogs.Find(inventoryLog => inventoryLog.Guid == logId).Guid;
        }

        public InventoryLog GetInventoryLog(Guid logId)
        {
            return _inventoryLogs.Find(inventoryLog => inventoryLog.Guid == logId);
        }

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

        public void RemoveApproval(Guid logGuid)
        {
            int invLogIndex = _inventoryLogs.FindIndex(inventoryLog => inventoryLog.Guid == logGuid);
            _inventoryLogs[invLogIndex].IsApproved = false;
            _inventoryLogs[invLogIndex].ApprovedBy = default;
            _inventoryLogs[invLogIndex].ApprovedAt = default;
        }

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

        public LogsManager(string InventoryLogsJSON)
        {
            _inventoryLogs = JsonSerializer.Deserialize<List<InventoryLog>>(InventoryLogsJSON);
        }
    }
}
