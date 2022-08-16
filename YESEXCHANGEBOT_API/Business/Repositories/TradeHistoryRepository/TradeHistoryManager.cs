using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.TradeHistoryRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.TradeHistoryRepository.Validation;
using Business.Repositories.TradeHistoryRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.TradeHistoryRepository;

namespace Business.Repositories.TradeHistoryRepository
{
    public class TradeHistoryManager : ITradeHistoryService
    {
        private readonly ITradeHistoryDal _tradeHistoryDal;

        public TradeHistoryManager(ITradeHistoryDal tradeHistoryDal)
        {
            _tradeHistoryDal = tradeHistoryDal;
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(TradeHistoryValidator))]
        [RemoveCacheAspect("ITradeHistoryService.Get")]

        public async Task<IResult> Add(tradehistory tradeHistory)
        {
            await _tradeHistoryDal.Add(tradeHistory);
            return new SuccessResult(TradeHistoryMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(TradeHistoryValidator))]
        [RemoveCacheAspect("ITradeHistoryService.Get")]

        public async Task<IResult> Update(tradehistory tradeHistory)
        {
            await _tradeHistoryDal.Update(tradeHistory);
            return new SuccessResult(TradeHistoryMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("ITradeHistoryService.Get")]

        public async Task<IResult> Delete(tradehistory tradeHistory)
        {
            await _tradeHistoryDal.Delete(tradeHistory);
            return new SuccessResult(TradeHistoryMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<tradehistory>>> GetList()
        {
            return new SuccessDataResult<List<tradehistory>>(await _tradeHistoryDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<tradehistory>> GetById(int id)
        {
            return new SuccessDataResult<tradehistory>(await _tradeHistoryDal.Get(p => p.id == id));
        }

    }
}
