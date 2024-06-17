using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TicketPurchaseRequest
    {
        public int PlaceStart { get; set; }
        public int PlaceEnd { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }

    }
}
