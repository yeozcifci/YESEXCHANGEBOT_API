using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.buysellstrategyRepository;
using DataAccess.Repositories.transactionRepository;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ExchangeBots.OkexBots
{
    public class OkexExchangeBotManager : IOkexExchangeBotService
    {
        private readonly IbuysellstrategyDal _strategyDal;
        private readonly ItransactionDal _transactionDal;

        public OkexExchangeBotManager(IbuysellstrategyDal strategyDal,ItransactionDal transactionDal)
        {
            _strategyDal = strategyDal;
            _transactionDal = transactionDal;
        }

        public async Task<IResult> CreatePreparedExchangeBot(string pairName)
        {
            throw new NotImplementedException(); 
        }

        public async Task<IResult> CreateNewExchangeBot(CreateNewStrategyDto strategyDto)
        {
            try
            {
                buysellstrategy strategyCreate = new buysellstrategy
                {
                    capitaltorisk = strategyDto.CapitalToRisk,
                    //createtime = DateTime.Now.ToUniversalTime(),
                    expectedprofitrate = strategyDto.ExpectedProfitRate / 100,
                    pairname = strategyDto.PairName,
                    partialbuycount = strategyDto.PartialBuyCount,
                    stoplossrate = strategyDto.StopLossrate
                };

                int strat_id = await _strategyDal.AddThenGetId(strategyCreate);
                decimal profRate = (decimal)(strategyCreate.expectedprofitrate / 100);

                for (int i = 0; i < strategyCreate.partialbuycount; i++)
                {
                    decimal ent_price = strategyCreate.creationprice - ((i) * profRate * strategyCreate.creationprice);
                    decimal sell_price = ent_price + (profRate * ent_price);
                    transaction st = new transaction
                    {
                        buysellstrategyid = strat_id,
                        entryprice = ent_price,
                        sellprice = sell_price,
                        status = "WAIT"
                    };
                    int tid = await _transactionDal.AddThenGetId(st);
                }
            }
            catch (Exception e)
            {
                return new ErrorResult("Error on strateygy generation!!!");
            }
           
            return new SuccessResult("New Strategy has been generated!!!");
        }
    }
}
