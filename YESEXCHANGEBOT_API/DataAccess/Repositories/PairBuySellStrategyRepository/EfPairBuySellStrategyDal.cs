using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.PairBuySellStrategyRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.PairBuySellStrategyRepository
{
    public class EfPairBuySellStrategyDal : EfEntityRepositoryBase<PairBuySellStrategy, SimpleContextDb>, IPairBuySellStrategyDal
    {
    }
}
