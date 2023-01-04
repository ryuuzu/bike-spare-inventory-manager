using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSpareInventoryManager.Data.Exceptions
{
    public class LogAlreadyApproved : Exception
    {
        public LogAlreadyApproved(string msg) : base(msg) { }
    }
}
