using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class transactionorder
    {
        public int id { get; set; }
        public string pair { get; set; }
        public DateTime? processtime { get; set; }
        public string processtype { get; set; }
        public decimal price { get; set; }
        public decimal amount { get; set; }
        public long orderid { get; set; }
        public decimal? fee { get; set; }
        public int transactionid { get; set; }
    }
}
