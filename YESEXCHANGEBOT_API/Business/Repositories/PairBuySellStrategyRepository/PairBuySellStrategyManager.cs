using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.PairBuySellStrategyRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.PairBuySellStrategyRepository.Validation;
using Business.Repositories.PairBuySellStrategyRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.PairBuySellStrategyRepository;

namespace Business.Repositories.PairBuySellStrategyRepository
{
    public class PairBuySellStrategyManager : IPairBuySellStrategyService
    {
        private readonly IPairBuySellStrategyDal _pairBuySellStrategyDal;

        public PairBuySellStrategyManager(IPairBuySellStrategyDal pairBuySellStrategyDal)
        {
            _pairBuySellStrategyDal = pairBuySellStrategyDal;
        }



        [SecuredAspect()]
        [ValidationAspect(typeof(PairBuySellStrategyValidator))]
        [RemoveCacheAspect("IPairBuySellStrategyService.Get")]

        public async Task<IResult> Add(PairBuySellStrategy pairBuySellStrategy)
        {
            await _pairBuySellStrategyDal.Add(pairBuySellStrategy);
            return new SuccessResult(PairBuySellStrategyMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(PairBuySellStrategyValidator))]
        [RemoveCacheAspect("IPairBuySellStrategyService.Get")]

        public async Task<IResult> Update(PairBuySellStrategy pairBuySellStrategy)
        {
            await _pairBuySellStrategyDal.Update(pairBuySellStrategy);
            return new SuccessResult(PairBuySellStrategyMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("IPairBuySellStrategyService.Get")]

        public async Task<IResult> Delete(PairBuySellStrategy pairBuySellStrategy)
        {
            await _pairBuySellStrategyDal.Delete(pairBuySellStrategy);
            return new SuccessResult(PairBuySellStrategyMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<PairBuySellStrategy>>> GetList()
        {
            return new SuccessDataResult<List<PairBuySellStrategy>>(await _pairBuySellStrategyDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<PairBuySellStrategy>> GetById(int id)
        {
            return new SuccessDataResult<PairBuySellStrategy>(await _pairBuySellStrategyDal.Get(p => p.Id == id));
        }

    }
}
