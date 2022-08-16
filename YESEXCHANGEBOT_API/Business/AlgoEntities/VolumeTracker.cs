using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AlgoEntities
{
    public class VolumeTracker
    {
        public DateTime PingTime { get; set; }
        public string Pair { get; set; }
        public decimal RecentAvarageVolume { get; set; }
        public decimal RecentVolume { get; set; }
        public double RecentVolumeChange { get; set; }
        public double  AvarageVolumeChange { get; set; }
        public int IntervalCount { get; set; } = 0;
        public int Length { get; set; }
        public decimal[] Volumes { get; set; }
        public decimal RecentAvarageBuyVolume { get; set; }
        public decimal[] BuyVolumes { get; set; }
        public double AvarageBuyVolumeChange { get; set; }
        public double BuyRate { get; set; }
        public int PingCount { get; set; }
        public double AvarageVolumeChangeAvarage { get; set; }
        public int LongSignalCount { get; set; }
        public int ShortSignalCount { get; set; }
        public double LongSignalsAvarage { get; set; }
        public double ShortSignalsAvarage { get; set; }
        public double BuyRateAvarage { get; set; }

    }
}
