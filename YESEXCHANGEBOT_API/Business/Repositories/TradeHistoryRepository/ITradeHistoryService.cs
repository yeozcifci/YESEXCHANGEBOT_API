using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.TradeHistoryRepository
{
    public interface ITradeHistoryService
    {
        Task<IResult> Add(tradehistory tradeHistory);
        Task<IResult> Update(tradehistory tradeHistory);
        Task<IResult> Delete(tradehistory tradeHistory);
        Task<IDataResult<List<tradehistory>>> GetList();
        Task<IDataResult<tradehistory>> GetById(int id);
    }
}
