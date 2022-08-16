using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class buysellstrategy
    {
        public decimal? capitaltorisk { get; set; }
        public string status { get; set; }
        public int id { get; set; }
        public string pairname { get; set; }
        public int? partialbuycount { get; set; }
        public decimal? expectedprofitrate { get; set; }
        public decimal? stoplossrate { get; set; }
        public decimal? realizedprofitloss { get; set; }
        public decimal? virtualprofitloss { get; set; }
        public int? arbitragecount { get; set; }
        public DateTime createtime { get; set; }
        public decimal creationprice { get; set; }
        public IEnumerable<transaction> transactions { get; set; }
    }       
}
