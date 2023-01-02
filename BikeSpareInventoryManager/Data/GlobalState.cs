using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BikeSpareInventoryManager.Data.Model;

namespace BikeSpareInventoryManager.Data
{
    public class GlobalState
    {
        public string PageName { get; set; } = "Home";
        public User CurrentUser { get; set; } = null;
    }
}
