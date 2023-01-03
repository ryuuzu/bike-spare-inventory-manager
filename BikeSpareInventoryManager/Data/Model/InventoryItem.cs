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

        public void UpdateNow()
        {
            _lastUpdated = DateTime.Now;
        }

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
        }

        public static implicit operator Guid(InventoryItem v)
        {
            throw new NotImplementedException();
        }
    }
}
