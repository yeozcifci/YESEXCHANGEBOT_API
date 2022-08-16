using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.StrategyTransactionRepository
{
    public interface IStrategyTransactionService
    {
        Task<IResult> Add(StrategyTransaction strategyTransaction);
        Task<IResult> Update(StrategyTransaction strategyTransaction);
        Task<IResult> Delete(StrategyTransaction strategyTransaction);
        Task<IDataResult<List<StrategyTransaction>>> GetList();
        Task<IDataResult<StrategyTransaction>> GetById(int id);
    }
}
