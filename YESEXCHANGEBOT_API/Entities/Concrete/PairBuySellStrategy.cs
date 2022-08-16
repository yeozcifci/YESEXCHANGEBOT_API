using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class PairBuySellStrategy
    {
        public decimal CapitalToRisk { get; set; }
        public string Status { get; set; }
        public IEnumerable<StrategyTransaction> Transactions { get; set; }
        public int Id { get; set; }
        public int ActiveTransactionCount { get; set; }
        public string PairName { get; set; }
        public decimal EntryPrice { get; set; }
        public int PartialBuyCount { get; set; }
        public decimal ExpectedProfitRate { get; set; }
        public decimal StopLossRatio { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastTransactionTime { get; set; }
        public decimal RealizedProfitLoss { get; set; }
        public DateTime ClosedTime { get; set; }

    }
}
