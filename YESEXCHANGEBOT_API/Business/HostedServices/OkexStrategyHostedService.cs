using Business.AlgoEntities;
using Core.Accounts;
using DataAccess.Repositories.PairBuySellStrategyRepository;
using DataAccess.Repositories.TradeHistoryRepository;
using Entities.Concrete;
using Microsoft.Extensions.Hosting;
using Okex.Net;
using Okex.Net.CoreObjects;
using Okex.Net.Enums;
using Okex.Net.RestObjects.Market;
using Okex.Net.RestObjects.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacTec.TA.Library;


namespace Business.HostedServices
{
    //public class OkexStrategyHostedService : IHostedService, IDisposable
    //{
    //private static PairBuySellStrategy strategy = null;
    //private readonly ITradeHistoryDal _tradeHistoryDal;
    //private readonly IPairBuySellStrategyDal _strategyDal;
    //public List<VolumeTracker> volumeTrackList = null;
    //public OkexStrategyHostedService(ITradeHistoryDal tradeHistoryDal, IPairBuySellStrategyDal pairBuySellStrategyDal)
    //{
    //    _tradeHistoryDal = tradeHistoryDal;
    //    _strategyDal = pairBuySellStrategyDal;
    //}

    //public void Dispose()
    //{
    //    //throw new NotImplementedException();
    //}

    ///*
    //* At first checks if any strategy Exists
    //* Then processes necessary transactions
    //*/
    //public Task StartAsync(CancellationToken cancellationToken)
    //{
    //    Console.WriteLine("Bakcgrond Okex Strategy Started!!!");
    //    ConnectProcessOkex();
    //    return Task.CompletedTask;
    //}

    //public Task StopAsync(CancellationToken cancellationToken)
    //{
    //    throw new NotImplementedException();
    //}

    //private void ConnectProcessOkex()
    //{ }
    ////OkexRestClientOptions opt = new OkexRestClientOptions();
    ////opt.DemoTradingService = true;
    ////OkexClient api = new OkexClient(opt);
    //OkexClient api = new OkexClient();
    ////api.SetApiCredentials(OkexliveAccountInformation.DemoApiKey, OkexliveAccountInformation.DemoApiSecret, OkexliveAccountInformation.DemoPassPhrase);
    //api.SetApiCredentials(OkexliveAccountInformation.LiveApiKey, OkexliveAccountInformation.LiveApiSecret, OkexliveAccountInformation.LivePassPhrase);
    //var system_01 = api.GetSystemStatus();

    ////OkexSocketClientOptions sopt = new OkexSocketClientOptions();
    ////sopt.DemoTradingService = true;
    ////var ws = new OkexSocketClient(sopt);
    //var ws = new OkexSocketClient();
    //api.SetApiCredentials(OkexliveAccountInformation.LiveApiKey, OkexliveAccountInformation.LiveApiSecret, OkexliveAccountInformation.LivePassPhrase);
    //var sample_pairs = new List<string> { "BTC-USDT" };
    //var subs = new List<UpdateSubscription>();

    //var market_06 = api.GetCandlesticksHistory("BTC-USDT", OkexPeriod.OneHour);

    //int a = 0;
    //int b = 0;
    //double[] ema = new double[market_06.Data.Count()];
    //TicTacTec.TA.Library.Core.Ema(0,market_06.Data.Count()-1,market_06.Data.Select(t=>(double)t.Close).ToArray(),20,out a,out b,ema);

    //var public_01 = api.GetInstruments(OkexInstrumentType.Spot);


    ////TicTacTec.TA.Library.Core.Ema(0, market_06.Data.Count() - 1, market_06.Data.Select(t => (double)t.Close).ToArray(), 10, out a, out b, ema);
    ////Core.Ema(0, mumsLength, Prices.Select(p => ((double)p.Close)).ToArray(), 20, out a, out b, Ema);

    //foreach (var pair in sample_pairs)
    //{
    //    var subscription = ws.SubscribeToTickers(pair, (data) =>
    //    {
    //        if (data != null)
    //        {

    //            //Console.WriteLine(data.Time + "-" + data.AskPrice);

    //        }
    //    });
    //    subs.Add(subscription.Data);
    //}

    //foreach (var pair in sample_pairs)
    //{
    //    var subscription = ws.SubscribeToTickers(pair, (data) =>
    //    {
    //        if (data != null)
    //        {
    //            Console.WriteLine(data.Time + "-" + data.AskPrice);
    //            try
    //            {
    //                if (strategy == null)
    //                {
    //                    strategy = CreateStrategy(100, "BTC-USDT", data.AskPrice, 10, (decimal)0.0001);
    //                }
    //                else
    //                {
    //                    lock (strategy)
    //                    {
    //                        Task.Run(async () =>
    //                        {
    //                            await CheckStrategyStatesAsync(data.AskPrice, strategy, data.Time, api);

    //                        });
    //                    }
    //                    lock (strategy)
    //                    {
    //                        Task.Run(async () =>
    //                        {
    //                            await CheckOrderStatesAsync(api);
    //                        });
    //                    }
    //                }
    //            }
    //            catch (Exception e)
    //            {
    //                Console.WriteLine("Hata: " + data.AskPrice);
    //            }


    //        }
    //    });
    //    //subs.Add(subscription.Data);
    //}

    //if (volumeTrackList == null)
    //{
    //    volumeTrackList = new List<VolumeTracker>();
    //    foreach (var item in public_01.Data)
    //    {
    //        VolumeTracker volumeTracker = new VolumeTracker
    //        {
    //            Pair = item.Instrument,
    //            Length = 60,
    //            Volumes = new decimal[60]
    //        };
    //        volumeTrackList.Add(volumeTracker);
    //    }
    //}


    //foreach (var pair in public_01.Data)
    //{
    //        ws.SubscribeToCandlesticks("BTC-USDT", OkexPeriod.OneMinute, (data) =>
    //        {
    //            if (data != null)
    //            {
    //                try
    //                {
    //                    Task.Run(async () =>
    //                    {
    //                        await TrackVolume(data);
    //                    });

    //                    //lock (strategy)
    //                    //{
    //                    //    Task.Run(async () =>
    //                    //    {
    //                    //        await CheckStrategyAsync(data.Close, strategy, data.Time);

    //                    //    });
    //                    //}
    //                    //lock (strategy)
    //                    //{
    //                    //    Task.Run(async () =>
    //                    //    {
    //                    //        await ProcessBuySellSignalsAsync(strategy, api);

    //                    //    });
    //                    //}
    //                }
    //                catch (Exception e)
    //                {
    //                    Console.WriteLine("HATA: " + "Close Price: " + data.Close + "Time: " + data.Time);
    //                }
    //            }
    //        });
    //    }

    //}


    //    public Task StopAsync(CancellationToken cancellationToken)
    //    {
    //        throw new NotImplementedException();
    //    }
    //    public void Dispose()
    //    {
    //        throw new NotImplementedException();
    //    }


    //    public async Task TrackVolume(OkexCandlestick candleStick) 
    //    {
    //        await Task.Run(() =>
    //        {
    //            if (volumeTrackList != null)
    //            {

    //                decimal avarageVolume;
    //                VolumeTracker vt = (VolumeTracker)volumeTrackList.Where(t=>t.Pair == candleStick.Instrument).FirstOrDefault();
    //                //if (vt.PingTime != candleStick.Time)
    //                {
    //                    vt.PingTime = candleStick.Time;
    //                    if (vt.IntervalCount == vt.Length - 1)
    //                    {
    //                        vt.IntervalCount = 0;
    //                    }
    //                    ++vt.IntervalCount;
    //                    vt.Volumes[vt.IntervalCount] = candleStick.VolumeCurrency;
    //                    if (vt.IntervalCount < vt.Length)
    //                    {
    //                        avarageVolume = vt.Volumes.Sum() / vt.IntervalCount;
    //                    }
    //                    else
    //                    {
    //                        avarageVolume = vt.Volumes.Sum() / vt.Length;
    //                    }
    //                    vt.RecentVolumeChange = vt.RecentVolume == 0 ? 0 : (double)((candleStick.VolumeCurrency - vt.RecentVolume) / vt.RecentVolume * 100);
    //                    vt.RecentVolume = candleStick.VolumeCurrency;
    //                    vt.AvarageVolumeChange = vt.RecentAvarageVolume == 0 ? 0 : (double)((avarageVolume - vt.RecentAvarageVolume) / vt.RecentAvarageVolume * 100);
    //                    vt.RecentAvarageVolume = avarageVolume;
    //                    Console.WriteLine("Volume:" + candleStick + " RecentChange: " + vt.RecentVolumeChange + " AvarageChange: " + vt.AvarageVolumeChange + " Price: " + candleStick.Close + " Time: " + vt.PingTime);
    //                }

    //            }
    //        });
    //    }
    //    public async Task CheckOrdersAsync(OkexClient api)
    //    {
    //        await Task.Run(async () =>
    //        {
    //            foreach (var transaction in strategy.Transactions)
    //            {

    //                try
    //                {
    //                    WebCallResult<IEnumerable<OkexOrder>> order_hist = null;
    //                    lock (this)
    //                    {
    //                        order_hist = api.GetOrderHistory(OkexInstrumentType.Spot);
    //                    }

    //                    if (order_hist.Data != null)
    //                    {
    //                        var orders = order_hist.Data.Where(t => t.OrderId == transaction.LastOrderId);
    //                        foreach (var order in orders)
    //                        {
    //                            if (order != null)
    //                            {
    //                                if (!transaction.BuyCompleted)
    //                                {
    //                                    if (order.OrderSide == OkexOrderSide.Buy)
    //                                    {
    //                                        lock (transaction)
    //                                        {
    //                                            Console.WriteLine("Buy Completed: " + order.OrderId);
    //                                            transaction.LastOrderStatus = "BuyCompleted";
    //                                            transaction.Quantity = order.FillQuantity;
    //                                            transaction.EntryPrice = order.FillPrice;
    //                                            transaction.BuySignal = false;
    //                                            transaction.BuyCompleted = true;
    //                                            transaction.ReachedSellPrice = false;
    //                                        }
    //                                        await CreateTradeHistoryAsync(order, decimal.Zero, transaction.Id);
    //                                        //Task.Run(async () => await CreateTradeHistoryAsync(order,order.Fee));
    //                                    }
    //                                }
    //                                if (!transaction.ReachedSellPrice)
    //                                {
    //                                    if (order.OrderSide == OkexOrderSide.Sell)
    //                                    {
    //                                        lock (transaction)
    //                                        {
    //                                            Console.WriteLine("Sell Completed: " + order.OrderId);
    //                                            transaction.Status = "Passive";
    //                                            transaction.LastOrderStatus = "SellCompleted";
    //                                            transaction.Quantity = order.FillQuantity;
    //                                            transaction.StoppedPrice = order.FillPrice;
    //                                            transaction.RealSellSignal = false;
    //                                            transaction.TempSellSignal = false;
    //                                            transaction.ReachedSellPrice = true;
    //                                            transaction.BuyCompleted = false;
    //                                            transaction.EntryPrice = order.FillPrice;
    //                                        }
    //                                        await CreateTradeHistoryAsync(order, (transaction.StoppedPrice - transaction.EntryPrice) / transaction.EntryPrice * (decimal)100, transaction.Id);
    //                                        //Task.Run(async () => await CreateTradeHistoryAsync(order,(transaction.StoppedPrice-transaction.EntryPrice)/transaction.EntryPrice*100));
    //                                    }
    //                                }
    //                            }
    //                        }
    //                    }
    //                }
    //                catch (Exception e)
    //                {
    //                }


    //            }
    //        });
    //    }
    //    public async Task CreateTradeHistoryAsync(OkexOrder okexOrder, decimal? profitloss, int tid)
    //    {
    //        //await Task.Run(() =>
    //        //{
    //        tradehistory trade_hist = new tradehistory();
    //        trade_hist.id = 0;
    //        trade_hist.price = (decimal)okexOrder.FillPrice;
    //        trade_hist.processtime = (DateTime)okexOrder.FillTime;
    //        trade_hist.processtype = okexOrder.OrderSide.ToString();
    //        trade_hist.amount = (decimal)okexOrder.Quantity;
    //        trade_hist.pair = okexOrder.Instrument;
    //        trade_hist.orderid = (long)okexOrder.OrderId;
    //        trade_hist.fee = okexOrder.Fee;
    //        trade_hist.profitloss = profitloss;
    //        trade_hist.transactionid = tid;
    //        trade_hist.strategyid = strategy.Id;
    //        await _tradeHistoryDal.Add(trade_hist);
    //        //});

    //    }
    //    public async Task ProcessBuySellSignalsAsync(PairBuySellStrategy strategy, OkexClient api)
    //    {
    //        foreach (var transaction in strategy.Transactions)
    //        {
    //            await Task.Run(() =>
    //            {
    //                lock (transaction)
    //                {
    //                    //Console.WriteLine("Transaction ID: " + transaction.Id + " Order Id: " + transaction.LastOrderId + " Status: " + transaction.Status + " Order Status: " + transaction.LastOrderStatus);
    //                    if (transaction.BuySignal && transaction.LastOrderStatus != "Processing" && transaction.Status == "Active" && (transaction.LastOrderId == 0 || transaction.LastOrderStatus == "Reset"))
    //                    {
    //                        Console.WriteLine("BuySignalTransaction ID: " + transaction.Id + " Order Id: " + transaction.LastOrderId + " Status: " + transaction.Status + " Order Status: " + transaction.LastOrderStatus);
    //                        var buy_trade = api.PlaceOrder(strategy.PairName, OkexTradeMode.Cash, OkexOrderSide.Buy, OkexPositionSide.Net, OkexOrderType.MarketOrder, strategy.CapitalToRisk / strategy.PartialBuyCount);
    //                        transaction.LastOrderId = buy_trade.Data == null ? 0 : (long)buy_trade.Data.OrderId;
    //                        transaction.LastOrderStatus = "Processing";

    //                        //Console.WriteLine("BuySignalTransaction ID: " + transaction.Id + " Order Id: " + transaction.LastOrderId + " Entry Price: " + transaction.EntryPrice + " Sell Price: " + transaction.SellPrice + " Status: " + transaction.Status);
    //                    }
    //                    if (transaction.RealSellSignal && transaction.LastOrderStatus == "BuyCompleted" && transaction.Status == "Active" && transaction.LastOrderId != 0)
    //                    {
    //                        Console.WriteLine("SellSignalTransaction ID: " + transaction.Id + " Order Id: " + transaction.LastOrderId + " Status: " + transaction.Status + " Order Status: " + transaction.LastOrderStatus);
    //                        var sell_trade = api.PlaceOrder(strategy.PairName, OkexTradeMode.Cash, OkexOrderSide.Sell, OkexPositionSide.Net, OkexOrderType.MarketOrder, (decimal)transaction.Quantity);
    //                        transaction.LastOrderId = sell_trade.Data == null ? 0 : (long)sell_trade.Data.OrderId;
    //                        transaction.LastOrderStatus = "Processing";
    //                        //Console.WriteLine("SellSignalTransaction ID: " + transaction.Id + " Order Id: " + transaction.LastOrderId + " Entry Price: " + transaction.EntryPrice + " Sell Price: " + transaction.SellPrice + " Status: " + transaction.Status);
    //                    }
    //                }
    //            });
    //        }
    //    }
    //    public async Task CheckStrategyAsync(decimal currentPrice, PairBuySellStrategy strategy, DateTime serverTime)
    //    {
    //        await Task.Run(() =>
    //        {

    //            int buyCountPerMinute = 0;
    //            foreach (var transaction in strategy.Transactions)
    //            {
    //                lock (transaction)
    //                {

    //                    if (transaction.LastServerTime != serverTime)
    //                    {
    //                        if (currentPrice <= transaction.EntryPrice && transaction.Status == "Passive" && buyCountPerMinute == 0 && transaction.LastOrderStatus != "Proccessing")
    //                        {
    //                            buyCountPerMinute++;
    //                            transaction.Status = "Active";
    //                            transaction.BuySignal = true;
    //                            transaction.EntryTime = serverTime;
    //                            if (transaction.LastOrderStatus == "SellCompleted")
    //                            {
    //                                transaction.LastOrderStatus = "Reset";
    //                            }
    //                            Console.WriteLine("Alım Sinyali: " + transaction.EntryPrice);
    //                        }
    //                        else if (currentPrice >= transaction.SellPrice && transaction.Status == "Active" && transaction.LastOrderStatus == "BuyCompleted")
    //                        {
    //                            transaction.TempSellSignal = true;
    //                            transaction.SellPrice = currentPrice * (1 + strategy.ExpectedProfitRate);
    //                            transaction.StopPrice = currentPrice;
    //                            Console.WriteLine("Fiyat Yükseltmesi: " + transaction.SellPrice);
    //                        }
    //                        else if (currentPrice <= transaction.StopPrice && transaction.TempSellSignal && transaction.Status == "Active" && transaction.LastOrderStatus == "BuyCompleted")
    //                        {
    //                            transaction.RealSellSignal = true;
    //                            //transaction.Status = "Passive";
    //                            Console.WriteLine("Satış Sinyali: " + transaction.StopPrice);
    //                        }
    //                    }
    //                    transaction.LastServerTime = serverTime;
    //                }
    //            }
    //        });
    //    }
    //    public async Task CheckStrategyStatesAsync(decimal currentPrice, PairBuySellStrategy strategy, DateTime serverTime, OkexClient api)
    //    {
    //            await Task.Run(() =>
    //            {
    //                int buyCountTimeFrame = 0;
    //                foreach (var transaction in strategy.Transactions)
    //                {
    //                    if (transaction.LastServerTime != serverTime)
    //                    {
    //                        transaction.LastServerTime = serverTime;
    //                        lock (transaction)
    //                        {
    //                            if (transaction.Status == "WAIT")
    //                            {
    //                                if (currentPrice <= transaction.EntryPrice && buyCountTimeFrame == 0)
    //                                {
    //                                    try
    //                                    {
    //                                        ++buyCountTimeFrame;
    //                                        var buy_trade = api.PlaceOrder(strategy.PairName, OkexTradeMode.Cash, OkexOrderSide.Buy, OkexPositionSide.Net, OkexOrderType.MarketOrder, strategy.CapitalToRisk / strategy.PartialBuyCount);
    //                                        transaction.LastOrderId = buy_trade.Data == null ? 0 : (long)buy_trade.Data.OrderId;
    //                                        transaction.Status = transaction.LastOrderId > 0 ? "BUYORDERCREATED" : "WAIT";
    //                                    }
    //                                    catch (Exception e)
    //                                    {

    //                                        Console.WriteLine(e.ToString());
    //                                    }

    //                                }
    //                            }
    //                            else if (transaction.Status == "BUYORDERCREATED")
    //                            {
    //                                Console.WriteLine("Waiting for order to be processed!!! -" + transaction.LastOrderId);
    //                            }
    //                            else if (transaction.Status == "BUYORDERFILLED")
    //                            {
    //                                Console.WriteLine("TARGET PRICE:" + transaction.SellPrice);
    //                                if (currentPrice >= transaction.SellPrice)
    //                                {
    //                                    transaction.SellPrice = currentPrice * (1 + strategy.ExpectedProfitRate);
    //                                    transaction.Status = "TARGETPRICEREACHED";
    //                                }
    //                            }
    //                            else if (transaction.Status == "TARGETPRICEREACHED")
    //                            {
    //                                if (currentPrice >= transaction.SellPrice)
    //                                {
    //                                    transaction.SellPrice = currentPrice * (1 + strategy.ExpectedProfitRate);
    //                                }
    //                                else if (currentPrice <= transaction.SellPrice)
    //                                {
    //                                    try
    //                                    {
    //                                        var sell_trade = api.PlaceOrder(strategy.PairName, OkexTradeMode.Cash, OkexOrderSide.Sell, OkexPositionSide.Net, OkexOrderType.MarketOrder, (decimal)transaction.Quantity);
    //                                        transaction.LastOrderId = sell_trade.Data == null ? 0 : (long)sell_trade.Data.OrderId;
    //                                        transaction.Status = transaction.LastOrderId > 0 ? "SELLORDERCREATED" : "TARGETPRICEREACHED";
    //                                        int a = 0;
    //                                    }
    //                                    catch (Exception e)
    //                                    {

    //                                        Console.WriteLine(e.ToString());
    //                                    }

    //                                }
    //                            }
    //                            else if (transaction.Status == "SELLORDERCREATED")
    //                            {
    //                                Console.WriteLine("Waiting for order to be processed!!! -" + transaction.LastOrderId);
    //                            }
    //                            else if (transaction.Status == "SELLORDERFILLED")
    //                            {
    //                                transaction.Status = "WAIT";
    //                            }
    //                            else
    //                            {
    //                                Console.WriteLine("ERROR STATES!!!");
    //                            }

    //                        }
    //                    }
    //                }
    //            });   
    //    }
    //    public async Task CheckOrderStatesAsync(OkexClient api)
    //    {
    //        await Task.Run(async () =>
    //        {
    //            foreach (var transaction in strategy.Transactions)
    //            {
    //                try
    //                {
    //                    if (transaction.Status == "BUYORDERCREATED")
    //                    {
    //                        WebCallResult<IEnumerable<OkexOrder>> order_history = null;
    //                        lock (this)
    //                        {
    //                            order_history = api.GetOrderHistory(OkexInstrumentType.Spot);
    //                        }
    //                        if (order_history.Data != null)
    //                        {
    //                            var buyOrder = order_history.Data.Where(t => t.OrderId == transaction.LastOrderId).FirstOrDefault();

    //                            if (buyOrder != null)
    //                            {
    //                                lock (transaction)
    //                                {
    //                                    transaction.Status = buyOrder == null ? "BUYORDERCREATED" : "BUYORDERFILLED";
    //                                    transaction.EntryPrice = buyOrder.FillPrice;
    //                                    transaction.Quantity = buyOrder.FillQuantity;
    //                                }
    //                                await CreateTradeHistoryAsync(buyOrder, decimal.Zero, transaction.Id);
    //                            }
    //                        }
    //                    }
    //                    else if (transaction.Status == "SELLORDERCREATED")
    //                    {
    //                        WebCallResult<IEnumerable<OkexOrder>> order_history = null;
    //                        lock (this)
    //                        {
    //                            order_history = api.GetOrderHistory(OkexInstrumentType.Spot);
    //                        }
    //                        if (order_history.Data != null)
    //                        {
    //                            var sellOrder = order_history.Data.Where(t => t.OrderId == transaction.LastOrderId).FirstOrDefault();

    //                            if (sellOrder != null)
    //                            {
    //                                lock (transaction)
    //                                {
    //                                    transaction.Status = sellOrder == null ? "SELLORDERCREATED" : "SELLORDERFILLED";
    //                                    transaction.StoppedPrice = sellOrder.FillPrice;
    //                                    decimal RealizedProfitLoss = (decimal)((decimal)(transaction.StoppedPrice - transaction.EntryPrice) / transaction.EntryPrice * (decimal)100);
    //                                    strategy.RealizedProfitLoss += RealizedProfitLoss;
    //                                    transaction.Quantity -= sellOrder.FillQuantity;
    //                                }
    //                                await CreateTradeHistoryAsync(sellOrder, (decimal)((decimal)(transaction.StoppedPrice - transaction.EntryPrice) / transaction.EntryPrice * (decimal)100), transaction.Id);
    //                            }
    //                        }
    //                    }
    //                    else
    //                    {
    //                        Console.WriteLine("ORDER: " + transaction.Id + "-" + transaction.Status);
    //                    }
    //                }
    //                catch (Exception e)
    //                {
    //                }
    //            }
    //        });
    //    }

    //    /*
    //* Syncronocus methods failed because they block main thread and cause time difference between clinet and server.
    //*/
    //    public PairBuySellStrategy CreateStrategy(decimal capital, string pairName, decimal entryPrice, int buyCount, decimal expectedProfitRate)
    //    {
    //        var strategy = new PairBuySellStrategy();
    //        //await Task.Run(() =>
    //        //{
    //        strategy.CapitalToRisk = capital;
    //        strategy.Id = 1;
    //        strategy.PairName = pairName;
    //        strategy.Status = "Active";
    //        strategy.EntryPrice = entryPrice;
    //        strategy.CreatedTime = DateTime.Now;
    //        strategy.PartialBuyCount = buyCount;
    //        strategy.ExpectedProfitRate = expectedProfitRate;
    //        List<StrategyTransaction> transactions = new List<StrategyTransaction>();
    //        for (int i = 0; i < buyCount; i++)
    //        {
    //            StrategyTransaction st = new StrategyTransaction();
    //            st.StrategyId = 1;
    //            st.Id = i;
    //            st.EntryPrice = entryPrice - ((i) * expectedProfitRate * entryPrice);
    //            st.SellPrice = st.EntryPrice + (expectedProfitRate * st.EntryPrice);
    //            st.Status = "WAIT";
    //            st.Quantity = capital / buyCount;
    //            transactions.Add(st);
    //        }
    //        strategy.Transactions = transactions;
    //        //});

    //        return strategy;
    //    }
    //    public void CheckStrategy(decimal currentPrice, PairBuySellStrategy strategy, DateTime serverTime)
    //    {
    //        //await Task.Run(() =>
    //        //{
    //        int buyCountPerMinute = 0;
    //        foreach (var transaction in strategy.Transactions)
    //        {
    //            //lock (transaction)
    //            {
    //                if (transaction.LastServerTime != serverTime)
    //                {
    //                    if (currentPrice <= transaction.EntryPrice && transaction.Status == "Passive" && buyCountPerMinute == 0)
    //                    {
    //                        buyCountPerMinute++;
    //                        transaction.Status = "Active";
    //                        transaction.BuySignal = true;
    //                        transaction.EntryTime = serverTime;
    //                        Console.WriteLine("Alım Sinyali: " + transaction.EntryPrice);
    //                        //break;//buy only once at a time
    //                    }
    //                    else if (currentPrice >= transaction.SellPrice && transaction.Status == "Active")
    //                    {
    //                        transaction.TempSellSignal = true;
    //                        transaction.SellPrice = currentPrice * (1 + strategy.ExpectedProfitRate);
    //                        transaction.StopPrice = currentPrice;
    //                        Console.WriteLine("Fiyat Yükseltmesi: " + transaction.SellPrice);
    //                    }
    //                    else if (currentPrice <= transaction.StopPrice && transaction.TempSellSignal && transaction.Status == "Active")
    //                    {
    //                        transaction.RealSellSignal = true;
    //                        transaction.Status = "Passive";
    //                        Console.WriteLine("Satış Sinyali: " + transaction.StopPrice);
    //                    }
    //                }
    //                transaction.LastServerTime = serverTime;
    //            }
    //        }
    //        //});


    //    }
    //    public void CheckOrders(OkexClient api)
    //    {
    //        foreach (var transaction in strategy.Transactions)
    //        {
    //            var order_hist = api.GetOrderHistory(OkexInstrumentType.Spot);
    //            if (order_hist != null)
    //            {
    //                try
    //                {
    //                    var orders = order_hist.Data.Where(t => t.OrderId == transaction.LastOrderId);
    //                    foreach (var order in orders)
    //                    {
    //                        if (order != null)
    //                        {
    //                            if (!transaction.BuyCompleted)
    //                            {
    //                                if (order.OrderSide == OkexOrderSide.Buy)
    //                                {
    //                                    transaction.Quantity = order.FillQuantity;
    //                                    transaction.EntryPrice = order.FillPrice;
    //                                    transaction.BuySignal = false;
    //                                    transaction.BuyCompleted = true;
    //                                    CreateTradeHistory(order);
    //                                }
    //                            }
    //                            if (!transaction.ReachedSellPrice)
    //                            {
    //                                if (order.OrderSide == OkexOrderSide.Sell)
    //                                {
    //                                    transaction.Quantity = order.FillQuantity;
    //                                    transaction.EntryPrice = order.FillPrice;
    //                                    transaction.RealSellSignal = false;
    //                                    transaction.TempSellSignal = false;
    //                                    transaction.ReachedSellPrice = true;
    //                                    CreateTradeHistory(order);
    //                                }
    //                            }
    //                        }
    //                    }
    //                }
    //                catch (Exception)
    //                {


    //                }

    //            }

    //        }
    //    }
    //    public void ProcessBuySellSignals(PairBuySellStrategy strategy, OkexClient api)
    //    {
    //        //await Task.Run(() =>
    //        //{
    //        foreach (var transaction in strategy.Transactions)
    //        {
    //            //lock (transaction)
    //            {
    //                Console.WriteLine("Transaction ID: " + transaction.Id + " Order Id: " + transaction.LastOrderId + " Entry Price: " + transaction.EntryPrice + " Sell Price: " + transaction.SellPrice + " Status: " + transaction.Status);
    //                if (transaction.BuySignal)
    //                {
    //                    var buy_trade = api.PlaceOrder(strategy.PairName, OkexTradeMode.Cash, OkexOrderSide.Buy, OkexPositionSide.Net, OkexOrderType.MarketOrder, strategy.CapitalToRisk / strategy.PartialBuyCount);
    //                    transaction.LastOrderId = (long)buy_trade.Data.OrderId;
    //                    //bool orderProcessed = trade_01.GetResultOrError(out OkexOrderPlaceResponse rp, out CryptoExchange.Net.Objects.Error err);
    //                    //if (orderProcessed)
    //                    //{
    //                    //    var orderDetails = api.GetOrderDetails(strategy.PairName, rp.OrderId);
    //                    //    if (orderDetails.Data != null)
    //                    //    {
    //                    //        transaction.EntryPrice = (decimal)orderDetails.Data.AveragePrice;
    //                    //        transaction.Quantity = (decimal)orderDetails.Data.AccumulatedFillQuantity;
    //                    //        transaction.LastOrderId = (long)orderDetails.Data.OrderId;
    //                    //        transaction.BuySignal = false;
    //                    //        Console.WriteLine("Avarage Buy Price :" + orderDetails.Data.AveragePrice + " Stop Price: " + transaction.StopPrice + " Quantity: " + orderDetails.Data.AccumulatedFillQuantity + " Fill Price: " + orderDetails.Data.FillPrice
    //                    //            + " Fee: " + orderDetails.Data.Fee);

    //                    //    }
    //                    //}
    //                }
    //                if (transaction.RealSellSignal)
    //                {
    //                    var sell_trade = api.PlaceOrder(strategy.PairName, OkexTradeMode.Cash, OkexOrderSide.Sell, OkexPositionSide.Net, OkexOrderType.MarketOrder, (decimal)transaction.Quantity);
    //                    //bool orderProcessed = trade_01.GetResultOrError(out OkexOrderPlaceResponse rp, out CryptoExchange.Net.Objects.Error err);
    //                    transaction.LastOrderId = (long)sell_trade.Data.OrderId;
    //                    //if (orderProcessed)
    //                    //{
    //                    //    var orderDetails = api.GetOrderDetails(strategy.PairName, rp.OrderId);

    //                    //    if (orderDetails.Data != null)
    //                    //    {
    //                    //        transaction.StoppedPrice = (decimal)orderDetails.Data.AveragePrice;
    //                    //        transaction.Quantity = transaction.Quantity - (decimal)orderDetails.Data.AccumulatedFillQuantity;
    //                    //        transaction.LastOrderId = (long)orderDetails.Data.OrderId;
    //                    //        Console.WriteLine("Realized Profit: " + (transaction.StoppedPrice - transaction.EntryPrice) * orderDetails.Data.AccumulatedFillQuantity + " Avarage Sell Price :" + orderDetails.Data.AveragePrice + " Quantity: " + orderDetails.Data.AccumulatedFillQuantity + " Fill Price: " + orderDetails.Data.FillPrice
    //                    //            + " Fee: " + orderDetails.Data.Fee);
    //                    //    }
    //                    //}
    //                }

    //            }
    //        }
    //        //});


    //    }
    //    public void CreateTradeHistory(OkexOrder okexOrder)
    //    {
    //        try
    //        {
    //            tradehistory trade_hist = new tradehistory();
    //            trade_hist.id = 0;
    //            trade_hist.price = (decimal)okexOrder.FillPrice;
    //            trade_hist.processtime = (DateTime)okexOrder.FillTime;
    //            trade_hist.processtype = okexOrder.OrderSide.ToString();
    //            trade_hist.amount = (decimal)okexOrder.Quantity;
    //            trade_hist.pair = okexOrder.Instrument;
    //            trade_hist.orderid = (long)okexOrder.OrderId;
    //            _tradeHistoryDal.Add(trade_hist);
    //        }
    //        catch (Exception e)// connect to market then update DB
    //        {

    //        }

    //    }

    //    }//End Class
    //}
}
    
