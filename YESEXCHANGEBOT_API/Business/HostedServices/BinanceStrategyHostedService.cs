using Binance.Net;
using Binance.Net.Interfaces;
using Binance.Net.Objects;
using Business.AlgoEntities;
using Core.Accounts;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
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
    public class BinanceStrategyHostedService : IHostedService, IDisposable
    {
        public List<VolumeTracker> volumeTrackList = null;
        private async Task ConnectProcessBinance()
        {


            var apiClient = new BinanceClient(new BinanceClientOptions()
            {
                ApiCredentials = new ApiCredentials(BinanceliveAccountInformation.LiveApiKey, BinanceliveAccountInformation.LiveApiSecret)
            });

            var socketClient = new BinanceSocketClient(new BinanceSocketClientOptions()
            {
                ApiCredentials = new ApiCredentials(BinanceliveAccountInformation.LiveApiKey, BinanceliveAccountInformation.LiveApiSecret)

            });

            Console.WriteLine("Binance api/socket started!!!");

            /*
             * 
             */
            await Task.Run(async () =>
            {
                List<IBinanceKline> binanceKlines = new List<IBinanceKline>();
                for (int i = -1; i <= 0; i++)
                {
                    var klines = await apiClient.Spot.Market.GetKlinesAsync("BTCUSDT", Binance.Net.Enums.KlineInterval.OneMinute, DateTime.UtcNow.AddHours(i), DateTime.UtcNow.AddHours(i+1),60);
                    binanceKlines.AddRange(klines.Data);
                }

                var orderedKlines =  binanceKlines.OrderByDescending(t=>t.Close);
                decimal highestPrice = orderedKlines.FirstOrDefault().Close;
                decimal lowestPrice = orderedKlines.LastOrDefault().Close;

                decimal incRate = (highestPrice - lowestPrice) / 10;

                for (decimal i = lowestPrice; i <= highestPrice; i += incRate)
                {
                    decimal alt_sinir =  i;
                    decimal ust_sinir =  i + incRate;
                    Console.WriteLine(alt_sinir);
                    Console.WriteLine(ust_sinir);
                    int sayi =  binanceKlines.Where(t => (t.Close >= alt_sinir && t.Close < ust_sinir)).Count();
                    decimal hacim = binanceKlines.Where(t => (t.Close >= alt_sinir && t.Close < ust_sinir)).Select(t => t.BaseVolume).Sum();
                    decimal alimHacmi = binanceKlines.Where(t => (t.Close >= alt_sinir && t.Close < ust_sinir)).Select(t => t.TakerBuyBaseVolume).Sum();
                    Console.WriteLine(i +"-" +sayi  +" VolumeSum: " +hacim +" BuyVol: " +alimHacmi +" BuyRate: " +alimHacmi/hacim*100);
                }
            });


           // await Task.Run(async () =>
           // {
           //     //var tmpspotData = apiClient.SpotApi.CommonSpotClient.GetSymbolsAsync();
           //     var tmpspotData = apiClient.Spot.Market.GetAllBookPricesAsync();
           //     var spotData = tmpspotData.Result.Data.Where(t => t.Symbol.EndsWith("BTC")).Take(10);
           //     //var spotData = tmpspotData.Result.Data.Where(t => t.Name.EndsWith("BTC")).Take(10);
           //     if (volumeTrackList == null)
           //     {
           //         volumeTrackList = new List<VolumeTracker>();
           //         foreach (var item in spotData)
           //         {


           //             var klines = await apiClient.Spot.Market.GetKlinesAsync(item.Symbol, Binance.Net.Enums.KlineInterval.OneMinute, DateTime.UtcNow.AddHours(-1), DateTime.UtcNow, 60);

           //             VolumeTracker volumeTracker = new VolumeTracker
           //             {
           //                 Pair = item.Symbol,
           //                 Length = 60,
           //                 Volumes = new decimal[60],
           //                 BuyVolumes = new decimal[60]


           //             };

           //             klines.Data.Select(t => (decimal)t.BaseVolume).ToArray().CopyTo(volumeTracker.Volumes, 0);
           //             volumeTracker.RecentVolume = volumeTracker.Volumes[volumeTracker.Length - 1];
           //             volumeTracker.RecentAvarageVolume = volumeTracker.Volumes.Sum() / volumeTracker.Length;
           //             volumeTracker.PingTime = klines.Data.Select(t => t).LastOrDefault().OpenTime;
           //             volumeTrackList.Add(volumeTracker);
           //         }
           //     }

           // }
           // );
           // Console.WriteLine("Entry information loaded!!!");

           // await socketClient.Spot.SubscribeToKlineUpdatesAsync("BTCUSDT", Binance.Net.Enums.KlineInterval.OneMinute, data =>
           //{
           //    Task.Run(async () =>
           //    {
           //        await TrackVolume(data.Data.Data, "BTCUSDT");
           //        Console.WriteLine("Api tick!!!");
           //    }
           //   );
           //});

            //await socketClient.SpotStreams.SubscribeToTickerUpdatesAsync("BTCUSDT" , async data =>
            //{

            //});

            //Task.Run( async ()  =>
            //{
            //    await socketClient.SpotStreams.SubscribeToKlineUpdatesAsync("BTCUSDT", Binance.Net.Enums.KlineInterval.OneMinute, data =>
            //    {
            //        //Console.WriteLine("Geldi!!");
            //        TrackVolume(data.Data.Data, "BTCUSDT");
            //    });
            //});
            //apiClient.SpotApi.CommonSpotClient.

            //return Task.CompletedTask;

        }

        public async Task TrackVolume(IBinanceKline candleStick, string pairName)
        {
            try
            {
                //if (candleStick.)
                {
                    await Task.Run(() =>
                   {
                       if (volumeTrackList != null)
                       {
                           decimal avarageVolume;
                           VolumeTracker vt = (VolumeTracker)volumeTrackList.Where(t => t.Pair == pairName).FirstOrDefault();
                           lock (vt)
                           {
                               if (vt.PingTime != candleStick.OpenTime)
                               {
                                   ++vt.PingCount;
                                   vt.PingTime = candleStick.OpenTime;
                                   if (vt.IntervalCount == vt.Length - 1)
                                   {
                                       vt.IntervalCount = 0;
                                   }

                                   vt.Volumes[vt.IntervalCount] = candleStick.BaseVolume;
                                   avarageVolume = vt.Volumes.Sum() / vt.Length;
                                   ++vt.IntervalCount;
                                   vt.RecentVolumeChange = vt.RecentVolume == 0 ? 0 : (double)((candleStick.BaseVolume - vt.RecentVolume) / vt.RecentVolume * 100);
                                   vt.RecentVolume = candleStick.BaseVolume;
                                   vt.AvarageVolumeChange = vt.RecentAvarageVolume == 0 ? 0 : (double)((avarageVolume - vt.RecentAvarageVolume) / vt.RecentAvarageVolume * 100);
                                   vt.AvarageVolumeChangeAvarage += vt.AvarageVolumeChange;
                                   vt.AvarageVolumeChangeAvarage /= vt.PingCount;
                                   vt.RecentAvarageVolume = avarageVolume;
                                   vt.BuyRate = candleStick.BaseVolume == 0 ? 0 : (double)(candleStick.TakerBuyBaseVolume / candleStick.BaseVolume * 100);
                                   vt.BuyRateAvarage += vt.BuyRate;
                                   vt.BuyRateAvarage /= vt.PingCount;
                                   //Console.WriteLine("Parity: " + vt.Pair + " Change:" + vt.AvarageVolumeChange);
                                   if (vt.AvarageVolumeChange > 0.3 && vt.BuyRate >= 60) //(double)avg_buy_rate)//if(candleStick.BaseVolume == 0)//Math.Abs(vt.AvarageVolumeChangeAvarage)*50
                                   {
                                       ++vt.LongSignalCount;
                                       vt.LongSignalsAvarage += vt.AvarageVolumeChange;
                                       vt.LongSignalsAvarage /= vt.LongSignalCount;
                                       //Console.WriteLine("Parity: " + vt.Pair + " Volume:" + candleStick.BaseVolume + " BuyVolume " + candleStick.TakerBuyBaseVolume + "-" + candleStick.TakerBuyQuoteVolume + " RecentChange: " + vt.RecentVolumeChange + " AverageChange: " + vt.AvarageVolumeChange
                                       //+ " Price: " + candleStick.CommonClose + " Time: " + vt.PingTime + " BuyRate: " + vt.BuyRate);
                                   }
                                   else
                                   {
                                       ++vt.ShortSignalCount;
                                       vt.ShortSignalsAvarage += vt.AvarageVolumeChange;
                                       vt.ShortSignalsAvarage /= vt.ShortSignalCount;
                                   }

                               }
                           }

                       }
                   }
                   );

                }
            }
            catch (Exception)
            {

                throw;
            }

            //return Task.CompletedTask;
        }

        public void Dispose()
        {
            this.Dispose();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await ConnectProcessBinance();
            Console.WriteLine("Started");
            //return Task.CompletedTask;
            //throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


    }
}

/*
 * Used for volume backtest
 * Prepare necessary data calls the signal method
 */
//await Task.Run(async () =>
//{
//    var tmpspotData = apiClient.Spot.Market.GetAllBookPricesAsync();
//    tmpspotData.Result.Data.Select(t => t.Symbol);
//    //var tmpspotData = apiClient.SpotApi.CommonSpotClient.GetSymbolsAsync();
//    //var spotData = tmpspotData.Result.Data.Where(t => t.Symbol.EndsWith("USDT")).Take(100);
//    var spotData = tmpspotData.Result.Data.Where(t => t.Symbol.EndsWith("SHIBUSDT")).Take(100);
//    if (volumeTrackList == null)
//    {
//        volumeTrackList = new List<VolumeTracker>();
//        try
//        {
//            foreach (var item in spotData)
//            {
//                var klinesw = await apiClient.Spot.Market.GetKlinesAsync(item.Symbol, Binance.Net.Enums.KlineInterval.OneDay, DateTime.UtcNow.AddDays(-8), DateTime.UtcNow.AddHours(-1), 60);
//                decimal avg_volume = klinesw.Data.Count() == 0 ? 0 : klinesw.Data.Select(t => t.BaseVolume).Sum() / klinesw.Data.Count() / 24;
//                decimal avg_buyvol = klinesw.Data.Count() == 0 ? 0 : klinesw.Data.Select(t => t.TakerBuyBaseVolume).Sum() / klinesw.Data.Count() / 24;
//                decimal avg_buy_rate = klinesw.Data.Count() == 0 ? 0 : avg_buyvol / avg_volume * 100;
//                for (int i = -2; i <= 0; i++)
//                {

//                    var klines = await apiClient.Spot.Market.GetKlinesAsync(item.Symbol, Binance.Net.Enums.KlineInterval.OneMinute, DateTime.UtcNow.AddHours(i), DateTime.UtcNow.AddHours(i + 1), 60);
//                    //var klines= await apiClient.SpotApi.CommonSpotClient.GetKlinesAsync(item.Name, TimeSpan.FromMinutes(1), DateTime.UtcNow.AddHours(i), DateTime.UtcNow.AddHours(i+1), 60);
//                    if (klines.Data.Count() > 0)
//                    {
//                        if (i == -2)
//                        {
//                            VolumeTracker volumeTracker = new VolumeTracker
//                            {
//                                Pair = item.Symbol,
//                                Length = 60,
//                                Volumes = new decimal[60],
//                                BuyVolumes = new decimal[60]
//                            };

//                            klines.Data.Select(t => (decimal)t.BaseVolume).ToArray().CopyTo(volumeTracker.Volumes, 0);
//                            klines.Data.Select(t => (decimal)t.TakerBuyBaseVolume).ToArray().CopyTo(volumeTracker.BuyVolumes, 0);
//                            volumeTracker.RecentVolume = volumeTracker.Volumes[volumeTracker.Length - 1];
//                            volumeTracker.RecentAvarageVolume = volumeTracker.Volumes.Sum() / volumeTracker.Length;
//                            volumeTracker.PingTime = klines.Data.Select(t => t).LastOrDefault().OpenTime;
//                            volumeTrackList.Add(volumeTracker);
//                        }
//                        else
//                        {
//                            //List<CryptoExchange.Net.CommonObjects.Kline> klinesData 
//                            var klinesData = klines.Data.Select(t => t);
//                            foreach (var d in klines.Data)
//                            {
//                                await TrackVolume(d, item.Symbol, avg_volume, avg_buy_rate);
//                            }
//                            //for (int j = 0; j < 60; j++)
//                            //{
//                            //    await TrackVolume((IBinanceStreamKline)klinesData, item.Name);
//                            //}
//                        }
//                    }
//                }
//                VolumeTracker vt = (VolumeTracker)volumeTrackList.Where(t => t.Pair == item.Symbol).FirstOrDefault();
//                if (vt != null)
//                {
//                    Console.WriteLine("Pair : " + item.Symbol +" LongSignalAvarageSize: " +vt.LongSignalsAvarage +" Long Signal Count: " + vt.LongSignalCount 
//                        + " ShortSignalAvarageSize: " + vt.ShortSignalsAvarage + " Short Signal Count: " +vt.ShortSignalCount );
//                }
//                else
//                {
//                    Console.WriteLine("Pair : " + item.Symbol);
//                }
//            }
//        }
//        catch (Exception e)
//        {
//            throw;

//        }
//    }
//});