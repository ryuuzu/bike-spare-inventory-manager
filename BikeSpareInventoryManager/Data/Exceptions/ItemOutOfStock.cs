namespace BikeSpareInventoryManager.Data.Exceptions
{
    public class ItemOutOfStock : Exception
    {
        public ItemOutOfStock(String msg)
        : base(msg)
        {

        }
    }
}
