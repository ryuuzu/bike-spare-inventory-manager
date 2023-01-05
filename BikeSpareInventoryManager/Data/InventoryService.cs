using BikeSpareInventoryManager.Data.Model;

namespace BikeSpareInventoryManager.Data
{
    public class InventoryService
    {
        public static Inventory LoadInventory()
        {
            string InventoryJSON = File.ReadAllText(FilesUtils.GetInventoryFilePath());
            return new Inventory(InventoryJSON);
        }

        public static void SaveInventory(Inventory CurrentInventory)
        {
            string AppDirectoryPath = FilesUtils.GetAppDirectoryPath();
            string InventoryFilePath = FilesUtils.GetInventoryFilePath();

            if (!Directory.Exists(AppDirectoryPath))
            {
                Directory.CreateDirectory(AppDirectoryPath);
            }

            File.WriteAllText(InventoryFilePath, CurrentInventory.GetSaveJSON());
        }

        public static Inventory SetupInventory()
        {
            Inventory CurrentInventory;
            try
            {
                CurrentInventory = LoadInventory();
            }
            catch (Exception)
            {
                List<InventoryItem> inventoryItems = new()
                {
                    new InventoryItem{Name="Brake Yoke", Description="High strength aluminium die casting product\r\nBetter surface finish\r\nHigh grade powder coating material used\r\nAttractive pricing",Price=555.00F,Quantity=100},
                    new InventoryItem{Name="Piston",Description="Falls under motor parts and accessories. No compromise in terms of quality. A necessary item for your vehicle. Reasonable price. First choice among consumers.",Price=1080.00F,Quantity=69,CreatedAt=DateTime.Now},
                    new InventoryItem{Name = "Mukut Fuel Pump", Description = "Mukut Fuel Pump Assembly for optimised supply of fuel to your bike engine for increased level of engine performance.", Price = 2975.00F, Quantity = 100, CreatedAt = DateTime.Now},
                    new InventoryItem{Name = "Gabriel Rear Mono Shock Absorber", Description = "Gabriel shock absorver offers a comfortable ride & required handling behaviour.", Price = 2498.00F, Quantity = 100, CreatedAt = DateTime.Now},
                    new InventoryItem{Name = "Mukut Digital Speedometer", Description = "MUKUT'S PRECISION MADE SPEEDOMETER TO MEASURE AND DISPLAY THE SPEED OF YOUR VEHICLE INSTANTANEOUSLY", Price = 3880.00F, Quantity = 100, CreatedAt = DateTime.Now},
                    new InventoryItem{Name = "Techlon CDI", Description = "Original Techlon Capacitor Discharge Ignition for reliable rides", Price = 3450.00F, Quantity = 100, CreatedAt = DateTime.Now},
                    new InventoryItem{Name = "Front Fork Pipe", Description = "Sanri Engineering Heavy-Duty Front\r\nFork Pipe or Front Tube that helps in a\r\ncomfortable ride & smooth\r\nhandling even on those bumpy roads", Price = 1350.00F, Quantity = 100, CreatedAt = DateTime.Now},
                    new InventoryItem{Name = "ROLON Chain Sprocket Kit", Description = "Genuine Heavy DUTY ROLON Chain\r\nSprocket kit to provide a secure &\r\ntension free ride", Price = 1920.00F, Quantity = 100, CreatedAt = DateTime.Now}
                };
                CurrentInventory = new Inventory(inventoryItems);
                SaveInventory(CurrentInventory);
            }
            return CurrentInventory;
        }
    }
}
