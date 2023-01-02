using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSpareInventoryManager.Data.Exceptions
{
    public class LowItemStock : Exception
    {
        public LowItemStock(string msg) : base(msg) { }
    }
}
