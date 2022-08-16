using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.transactionRepository
{
    public interface ItransactionService
    {
        Task<IResult> Add(transaction transaction);
        Task<IResult> Update(transaction transaction);
        Task<IResult> Delete(transaction transaction);
        Task<IDataResult<List<transaction>>> GetList();
        Task<IDataResult<transaction>> GetById(int id);
    }
}
