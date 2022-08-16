using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.transactionorderRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.transactionorderRepository.Validation;
using Business.Repositories.transactionorderRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.transactionorderRepository;

namespace Business.Repositories.transactionorderRepository
{
    public class transactionorderManager : ItransactionorderService
    {
        private readonly ItransactionorderDal _transactionorderDal;

        public transactionorderManager(ItransactionorderDal transactionorderDal)
        {
            _transactionorderDal = transactionorderDal;
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(transactionorderValidator))]
        [RemoveCacheAspect("ItransactionorderService.Get")]

        public async Task<IResult> Add(transactionorder transactionorder)
        {
            await _transactionorderDal.Add(transactionorder);
            return new SuccessResult(transactionorderMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(transactionorderValidator))]
        [RemoveCacheAspect("ItransactionorderService.Get")]

        public async Task<IResult> Update(transactionorder transactionorder)
        {
            await _transactionorderDal.Update(transactionorder);
            return new SuccessResult(transactionorderMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("ItransactionorderService.Get")]

        public async Task<IResult> Delete(transactionorder transactionorder)
        {
            await _transactionorderDal.Delete(transactionorder);
            return new SuccessResult(transactionorderMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<transactionorder>>> GetList()
        {
            return new SuccessDataResult<List<transactionorder>>(await _transactionorderDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<transactionorder>> GetById(int id)
        {
            return new SuccessDataResult<transactionorder>(await _transactionorderDal.Get(p => p.id == id));
        }

    }
}
