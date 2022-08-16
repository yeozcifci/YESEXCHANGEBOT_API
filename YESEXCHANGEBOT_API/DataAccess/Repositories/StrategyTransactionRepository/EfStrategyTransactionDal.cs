using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.StrategyTransactionRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.StrategyTransactionRepository
{
    public class EfStrategyTransactionDal : EfEntityRepositoryBase<StrategyTransaction, SimpleContextDb>, IStrategyTransactionDal
    {
    }
}
