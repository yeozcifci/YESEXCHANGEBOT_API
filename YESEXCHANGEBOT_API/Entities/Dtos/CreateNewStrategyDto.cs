using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class CreateNewStrategyDto
    {
        public decimal? CapitalToRisk { get; set; }
        public string PairName { get; set; }
        public int? PartialBuyCount { get; set; }
        public decimal? ExpectedProfitRate { get; set; }
        public decimal? StopLossrate { get; set; }
        public decimal StartPrice { get; set; }
    }
}
