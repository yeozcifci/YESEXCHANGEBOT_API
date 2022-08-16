using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Repositories.transactionRepository
{
    public interface ItransactionDal : IEntityRepository<transaction>
    {
        Task<int> AddThenGetId(transaction transaction);
    }
}
