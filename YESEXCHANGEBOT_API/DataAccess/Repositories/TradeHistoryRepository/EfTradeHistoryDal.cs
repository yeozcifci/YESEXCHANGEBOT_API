using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.TradeHistoryRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.TradeHistoryRepository
{
    public class EfTradeHistoryDal : EfEntityRepositoryBase<tradehistory, SimpleContextDb>, ITradeHistoryDal
    {
    }
}
