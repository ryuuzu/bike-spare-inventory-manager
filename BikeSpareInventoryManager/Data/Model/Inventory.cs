using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BikeSpareInventoryManager.Data.Model
{
    public class Inventory
    {
        private List<InventoryItem> _inventoryItems;

        public List<InventoryItem> InventoryItems { get { return _inventoryItems; } }

        public Inventory(List<InventoryItem> InvItems)
        {
            _inventoryItems = InvItems;
        }

        public InventoryItem GetInventoryItem(Guid itemId)
        {
            return _inventoryItems.Find(invItem => invItem.Guid == itemId);
        }

        public void AddItemStock(Guid guid, int quantity)
        {
            _inventoryItems[_inventoryItems.FindIndex(inventoryItem => inventoryItem.Guid == guid)].Quantity += quantity;
        }

        public void RemoveItemStock(Guid guid, int quantity)
        {
            _inventoryItems[_inventoryItems.FindIndex(inventoryItem => inventoryItem.Guid == guid)].DecreaseQuantity(quantity);
        }

        public void AddItem(InventoryItem InvItem)
        {
            _inventoryItems.Add(InvItem);
        }

        public string GetSaveJSON()
        {
            return JsonSerializer.Serialize(this.InventoryItems);
        }

        public Inventory(string InventoryJSON)
        {
            _inventoryItems = JsonSerializer.Deserialize<List<InventoryItem>>(InventoryJSON);
        }
    }
}
