using BikeSpareInventoryManager.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BikeSpareInventoryManager.Data
{
    public class InventoryService
    {
        public static Inventory SetupInventory()
        {
            Inventory CurrentInventory;
            try
            {
                string InventoryJSON = File.ReadAllText(FilesUtils.GetInventoryFilePath());
                CurrentInventory = JsonSerializer.Deserialize<Inventory>(InventoryJSON);
            }
            catch (Exception ex)
            {
                List<Item> Items = new List<Item>
                {
                    new Item{Name="Brake Yoke", Description="High strength aluminium die casting product\r\nBetter surface finish\r\nHigh grade powder coating material used\r\nAttractive pricing", Price=555.00F},
                    new Item{Name="Piston", Description="Falls under motor parts and accessories. No compromise in terms of quality. A necessary item for your vehicle. Reasonable price. First choice among consumers.", Price=1080.00F},
                    new Item{Name="Mukut Fuel Pump", Description="Mukut Fuel Pump Assembly for optimised supply of fuel to your bike engine for increased level of engine performance.", Price=2975.00F},
                    new Item{Name="Gabriel Rear Mono Shock Absorber", Description="Gabriel shock absorver offers a comfortable ride & required handling behaviour.", Price=2498.00F},
                    new Item{Name="Mukut Digital Speedometer", Description="MUKUT'S PRECISION MADE SPEEDOMETER TO MEASURE AND DISPLAY THE SPEED OF YOUR VEHICLE INSTANTANEOUSLY", Price=3880.00F},
                    new Item{Name="Techlon CDI", Description="Original Techlon Capacitor Discharge Ignition for reliable rides", Price=3450.00F},
                    new Item{Name="Front Fork Pipe", Description="Sanri Engineering Heavy-Duty Front\r\nFork Pipe or Front Tube that helps in a\r\ncomfortable ride & smooth\r\nhandling even on those bumpy roads", Price=1350.00F},
                    new Item{Name="ROLON Chain Sprocket Kit", Description="Genuine Heavy DUTY ROLON Chain\r\nSprocket kit to provide a secure &\r\ntension free ride", Price=1920.00F},
                    new Item{Name="ROLON Chain Sprocket Kit", Description="", Price=.00F},
                    new Item{Name="", Description="", Price=.00F},
                    new Item{Name="", Description="", Price=.00F},
                    new Item{Name="", Description="", Price=.00F},
                };
                List<InventoryItem> inventoryItems = new List<InventoryItem>();
                CurrentInventory = new Inventory(inventoryItems, Items);
            }
            return CurrentInventory;
        }
    }
}
