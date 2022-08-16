using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.transactionorderRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.transactionorderRepository
{
    public class EftransactionorderDal : EfEntityRepositoryBase<transactionorder, SimpleContextDb>, ItransactionorderDal
    {
    }
}
