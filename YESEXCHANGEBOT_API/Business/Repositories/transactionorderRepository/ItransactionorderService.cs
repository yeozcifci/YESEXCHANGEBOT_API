using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.transactionorderRepository
{
    public interface ItransactionorderService
    {
        Task<IResult> Add(transactionorder transactionorder);
        Task<IResult> Update(transactionorder transactionorder);
        Task<IResult> Delete(transactionorder transactionorder);
        Task<IDataResult<List<transactionorder>>> GetList();
        Task<IDataResult<transactionorder>> GetById(int id);
    }
}
