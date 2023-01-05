namespace BikeSpareInventoryManager.Data.Exceptions
{
    public class TotalAdminLimitReached : Exception
    {
        public TotalAdminLimitReached(string msg) : base(msg) { }
    }
}
