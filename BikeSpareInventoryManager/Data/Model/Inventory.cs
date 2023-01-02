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
        private List<Item> _allItems;

        public List<InventoryItem> InventoryItems { get { return _inventoryItems; } }
        public List<Item> AllItems { get { return _allItems; } }

        public Inventory(List<InventoryItem> InvItems, List<Item> Items)
        {
            _inventoryItems = InvItems;
            _allItems = Items;
        }

        public string GetSaveJSON()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
