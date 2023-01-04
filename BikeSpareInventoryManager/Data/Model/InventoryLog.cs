using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSpareInventoryManager.Data.Model
{
    public class InventoryLog
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
        public InvLogType LogType { get; set; }
        public Guid LogAuthor { get; set; }
        public DateTime LogDate { get; set; }
        public Guid ApprovedBy { get; set; }
        public bool IsApproved { get; set; } = false;
        public DateTime ApprovedAt { get; set; }
    }
}
