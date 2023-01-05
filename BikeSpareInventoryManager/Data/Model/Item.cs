namespace BikeSpareInventoryManager.Data.Model
{
    public class Item
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
    }
}
