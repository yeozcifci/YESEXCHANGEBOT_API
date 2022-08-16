using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.PairBuySellStrategyRepository
{
    public interface IPairBuySellStrategyService
    {
        Task<IResult> Add(PairBuySellStrategy pairBuySellStrategy);
        Task<IResult> Update(PairBuySellStrategy pairBuySellStrategy);
        Task<IResult> Delete(PairBuySellStrategy pairBuySellStrategy);
        Task<IDataResult<List<PairBuySellStrategy>>> GetList();
        Task<IDataResult<PairBuySellStrategy>> GetById(int id);
    }
}
