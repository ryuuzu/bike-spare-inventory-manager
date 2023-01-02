using BikeSpareInventoryManager.Data.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSpareInventoryManager.Data.Model
{
    public class InventoryItem
    {
        private DateTime _lastUpdated;
        private DateTime _createdAt;
        private int _quantity;
        public Guid Guid { get; set; } = Guid.NewGuid();
        public Item Item { get; set; }
        public int Quantity { get { return _quantity; } }

        public DateTime CreatedAt
        {
            get { return _createdAt; }
        }

        public DateTime LastUpdated
        {
            get { return _lastUpdated; }
        }

        public void UpdateNow()
        {
            _lastUpdated = DateTime.Now;
        }

        public void DecreaseQuantity(int ToDecrease)
        {
            if (_quantity < ToDecrease && _quantity > 0)
            {
                throw new LowItemStock("Item stock is lower than amount requested.");
            }
        }
    }
}
