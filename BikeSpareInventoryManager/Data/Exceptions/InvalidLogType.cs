using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSpareInventoryManager.Data.Exceptions
{
    public class InvalidLogType : Exception
    {
        public InvalidLogType(string msg) : base(msg) { }
    }
}
