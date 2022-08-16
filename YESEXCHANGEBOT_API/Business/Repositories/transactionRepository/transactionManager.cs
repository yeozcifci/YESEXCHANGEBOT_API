using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.transactionRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.transactionRepository.Validation;
using Business.Repositories.transactionRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.transactionRepository;

namespace Business.Repositories.transactionRepository
{
    public class transactionManager : ItransactionService
    {
        private readonly ItransactionDal _transactionDal;

        public transactionManager(ItransactionDal transactionDal)
        {
            _transactionDal = transactionDal;
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(transactionValidator))]
        [RemoveCacheAspect("ItransactionService.Get")]

        public async Task<IResult> Add(transaction transaction)
        {
            await _transactionDal.Add(transaction);
            return new SuccessResult(transactionMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(transactionValidator))]
        [RemoveCacheAspect("ItransactionService.Get")]

        public async Task<IResult> Update(transaction transaction)
        {
            await _transactionDal.Update(transaction);
            return new SuccessResult(transactionMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("ItransactionService.Get")]

        public async Task<IResult> Delete(transaction transaction)
        {
            await _transactionDal.Delete(transaction);
            return new SuccessResult(transactionMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<transaction>>> GetList()
        {
            return new SuccessDataResult<List<transaction>>(await _transactionDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<transaction>> GetById(int id)
        {
            return new SuccessDataResult<transaction>(await _transactionDal.Get(p => p.id == id));
        }

    }
}
