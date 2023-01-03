using BikeSpareInventoryManager.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSpareInventoryManager.Data.Forms
{
    public class ItemAdditionForm
    {
        [Required] public string Name { get; set; }
        [Required] public string Description { get; set; }
        [Required] public float Price { get; set; }
        [Required] public int Quantity { get; set; }

        public InventoryItem GetInventoryItem()
        {
            return new InventoryItem { Name = this.Name, Description = this.Description, Price = this.Price, Quantity = this.Quantity, CreatedAt = DateTime.Now };
        }
    }
}
