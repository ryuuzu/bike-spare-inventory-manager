namespace BikeSpareInventoryManager.Data
{
    public class FilesUtils
    {
        public static string GetAppDirectoryPath()
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Janata Garage"
            );
        }

        public static string GetUsersFilePath()
        {
            return Path.Combine(GetAppDirectoryPath(), "users.json");
        }

        public static string GetInventoryFilePath()
        {
            return Path.Combine(GetAppDirectoryPath(), "inventory.json");
        }
        public static string GetInventoryLogsFilePath()
        {
            return Path.Combine(GetAppDirectoryPath(), "inventory_logs.json");
        }
    }
}
