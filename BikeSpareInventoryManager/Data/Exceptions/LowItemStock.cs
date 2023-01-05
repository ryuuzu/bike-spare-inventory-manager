namespace BikeSpareInventoryManager.Data.Exceptions
{
    public class LowItemStock : Exception
    {
        public LowItemStock(string msg) : base(msg) { }
    }
}
