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
