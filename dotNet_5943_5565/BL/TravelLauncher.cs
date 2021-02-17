using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    class TravelLauncher
    {
        #region singelton
        static readonly TravelLauncher instance = new TravelLauncher();
        static TravelLauncher() { }// static ctor to ensure instance init is done just before first usage
        public TravelLauncher() { }
        public static TravelLauncher Instance { get => instance; }// The public Instance property to use
        #endregion

        private int stationWatch;
        private static Random random = new Random();
        public int StationWatch { get; set; }

        public void StartLaunch()
        {
            
        }
    }
}
