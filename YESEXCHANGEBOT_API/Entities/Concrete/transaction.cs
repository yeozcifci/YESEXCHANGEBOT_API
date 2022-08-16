using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class transaction
    {
        public int id { get; set; }
        public int buysellstrategyid { get; set; }
        public decimal? entryprice { get; set; }
        public decimal? sellprice { get; set; }
        public decimal? stoppedprice { get; set; }
        public DateTime entrytime { get; set; }
        public DateTime lastservertime { get; set; }
        public long lastorderid { get; set; }
        public string status { get; set; }
        public IEnumerable<transactionorder> orders { get; set; }
    }
}
