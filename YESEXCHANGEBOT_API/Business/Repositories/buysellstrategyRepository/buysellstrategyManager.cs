using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.buysellstrategyRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.buysellstrategyRepository.Validation;
using Business.Repositories.buysellstrategyRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.buysellstrategyRepository;
using DataAccess.Repositories.transactionRepository;

namespace Business.Repositories.buysellstrategyRepository
{
    public class buysellstrategyManager : IbuysellstrategyService
    {
        private readonly IbuysellstrategyDal _buysellstrategyDal;
        private readonly ItransactionDal _transactionDal;

        public buysellstrategyManager(IbuysellstrategyDal buysellstrategyDal)
        {
            _buysellstrategyDal = buysellstrategyDal;
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(buysellstrategyValidator))]
        [RemoveCacheAspect("IbuysellstrategyService.Get")]

        public async Task<IResult> Add(buysellstrategy buysellstrategy)
        {
            int strat_id = await _buysellstrategyDal.AddThenGetId(buysellstrategy);
            decimal profRate = (decimal)(buysellstrategy.expectedprofitrate / 100);
            
            List<transaction> transactions = new List<transaction>();
            for (int i = 0; i < buysellstrategy.partialbuycount; i++)
            {
                decimal ent_price = buysellstrategy.creationprice - ((i) * profRate * buysellstrategy.creationprice);
                decimal sell_price = ent_price + (profRate * ent_price);
                transaction st = new transaction
                {
                    buysellstrategyid = strat_id,
                    entryprice = ent_price,
                    sellprice = sell_price,
                    status = "WAIT"
                };
                //st.qu = buysellstrategy.capitaltorisk / buysellstrategy.partialbuycount;
                transactions.Add(st);
                await _transactionDal.Add(st);
            }
            buysellstrategy.transactions = transactions;
            
            return new SuccessResult(buysellstrategyMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(buysellstrategyValidator))]
        [RemoveCacheAspect("IbuysellstrategyService.Get")]

        public async Task<IResult> Update(buysellstrategy buysellstrategy)
        {
            await _buysellstrategyDal.Update(buysellstrategy);
            return new SuccessResult(buysellstrategyMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("IbuysellstrategyService.Get")]

        public async Task<IResult> Delete(buysellstrategy buysellstrategy)
        {
            await _buysellstrategyDal.Delete(buysellstrategy);
            return new SuccessResult(buysellstrategyMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<buysellstrategy>>> GetList()
        {
            return new SuccessDataResult<List<buysellstrategy>>(await _buysellstrategyDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<buysellstrategy>> GetById(int id)
        {
            return new SuccessDataResult<buysellstrategy>(await _buysellstrategyDal.Get(p => p.id == id));
        }

    }
}
