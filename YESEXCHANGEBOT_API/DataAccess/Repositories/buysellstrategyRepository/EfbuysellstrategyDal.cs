using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.buysellstrategyRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.buysellstrategyRepository
{
    public class EfbuysellstrategyDal : EfEntityRepositoryBase<buysellstrategy, SimpleContextDb>, IbuysellstrategyDal
    {
        public async  Task<int> AddThenGetId(buysellstrategy buysellstrategy)
        {
            using(var context = new SimpleContextDb())
            {
                await context.AddAsync(buysellstrategy);
                await context.SaveChangesAsync();
                return buysellstrategy.id;

            }
        }

    }
}
