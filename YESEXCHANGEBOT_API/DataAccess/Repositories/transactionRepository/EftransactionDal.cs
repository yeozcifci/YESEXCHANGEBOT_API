using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.transactionRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.transactionRepository
{
    public class EftransactionDal : EfEntityRepositoryBase<transaction, SimpleContextDb>, ItransactionDal
    {
        public async Task<int> AddThenGetId(transaction transaction)
        {
            using (var context = new SimpleContextDb())
            {
                await context.AddAsync(transaction);
                await context.SaveChangesAsync();
                return transaction.id;

            }
        }
    }
}
