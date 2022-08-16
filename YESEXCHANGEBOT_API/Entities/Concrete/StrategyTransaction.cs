using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class StrategyTransaction
    {
        public int StrategyId { get; set; }
        public int Id { get; set; }
        public decimal? EntryPrice { get; set; }
        public decimal? SellPrice { get; set; }
        public decimal? StopPrice { get; set; }
        public decimal? StoppedPrice { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime ServerEntryTime { get; set; }
        public bool ReachedSellPrice { get; set; } = false;
        public int ProfitIncrementCount { get; set; }
        public string Status { get; set; }
        public bool BuySignal { get; set; } = false;
        public bool TempSellSignal { get; set; } = false;
        public bool RealSellSignal { get; set; } = false;
        public long LastOrderId { get; set; } = 0;
        public bool BuyCompleted { get; set; } = false;
        public decimal? Quantity { get; set; } = 0;
        public DateTime LastServerTime { get; set; }
        public string LastOrderStatus { get; set; }

    }
}
