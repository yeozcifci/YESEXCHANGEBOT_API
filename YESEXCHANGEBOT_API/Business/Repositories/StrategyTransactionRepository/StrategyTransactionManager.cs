using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.StrategyTransactionRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.StrategyTransactionRepository.Validation;
using Business.Repositories.StrategyTransactionRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.StrategyTransactionRepository;

namespace Business.Repositories.StrategyTransactionRepository
{
    public class StrategyTransactionManager : IStrategyTransactionService
    {
        private readonly IStrategyTransactionDal _strategyTransactionDal;

        public StrategyTransactionManager(IStrategyTransactionDal strategyTransactionDal)
        {
            _strategyTransactionDal = strategyTransactionDal;
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(StrategyTransactionValidator))]
        [RemoveCacheAspect("IStrategyTransactionService.Get")]

        public async Task<IResult> Add(StrategyTransaction strategyTransaction)
        {
            await _strategyTransactionDal.Add(strategyTransaction);
            return new SuccessResult(StrategyTransactionMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(StrategyTransactionValidator))]
        [RemoveCacheAspect("IStrategyTransactionService.Get")]

        public async Task<IResult> Update(StrategyTransaction strategyTransaction)
        {
            await _strategyTransactionDal.Update(strategyTransaction);
            return new SuccessResult(StrategyTransactionMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("IStrategyTransactionService.Get")]

        public async Task<IResult> Delete(StrategyTransaction strategyTransaction)
        {
            await _strategyTransactionDal.Delete(strategyTransaction);
            return new SuccessResult(StrategyTransactionMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<StrategyTransaction>>> GetList()
        {
            return new SuccessDataResult<List<StrategyTransaction>>(await _strategyTransactionDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<StrategyTransaction>> GetById(int id)
        {
            return new SuccessDataResult<StrategyTransaction>(await _strategyTransactionDal.Get(p => p.Id == id));
        }

    }
}
