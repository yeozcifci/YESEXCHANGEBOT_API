using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    [Table("tradehistories")]
    public class tradehistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string pair { get; set; }
        public DateTime? processtime { get; set; }
        public string processtype { get; set; }
        public decimal price { get; set; }
        public decimal amount { get; set; }
        public long orderid { get; set; }
        public decimal? fee { get; set; }
        public decimal? profitloss { get; set; }
        public int transactionid { get; set; }
        public int strategyid { get; set; }
    }
}
