using BikeSpareInventoryManager.Data.Exceptions;

namespace BikeSpareInventoryManager.Data.Model
{
    public class InventoryItem
    {
        /*
         * Inventory Item class for the items to be stored in the inventory object.
         * Also helps perform item specific tasks in the inventory.
         * 
         * _lastUpdated: Last Update Time of the Item
         * _createdAt: Creation TIme of the Item
         * Guid: ID for the item.
         * Name: Name of the item
         * Description: Description of the item
         * Price: Price of the item
         * Quantity: QUantity of the item in the inventory.
         * CreatedAt: Accessor and Mutator for the _createdAt.
         * LastUpdated: Accessor the the _lastUpdated.
         */
        private DateTime _lastUpdated;
        private DateTime _createdAt;
        public Guid Guid { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; } = 0;

        public DateTime CreatedAt
        {
            get { return _createdAt; }
            set
            {
                if (_createdAt == DateTime.MinValue)
                {
                    _createdAt = value;
                }
            }
        }

        public DateTime LastUpdated
        {
            get { return _lastUpdated; }
        }

        // Method to update the LastUpdated to current time.
        public void UpdateNow()
        {
            _lastUpdated = DateTime.Now;
        }

        // Method to decrease the stock of the item as per the request.
        public void DecreaseQuantity(int ToDecrease)
        {
            if (Quantity == 0)
            {
                throw new ItemOutOfStock("Item is out of stock.");
            }
            if (Quantity < ToDecrease && Quantity > 0)
            {
                throw new LowItemStock("Item stock is lower than amount requested.");
            }
            Quantity -= ToDecrease;
        }
    }
}
