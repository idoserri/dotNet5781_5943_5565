using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace DS
{
    public static class DataSource
    {
        public static List<Bus> listBusses;
        public static List<Station> listStations;
        public static List<Line> listLines;
        public static List<LineStation> listLineStations;
        public static List<AdjacentStations> listAdjacentStations;
        public static Random r;
        static DataSource()
        {
            InitialLists();
        }
        static void InitialLists()
        {
            listBusses = new List<Bus>
            {
                new Bus
                {
                    LicenseNum = 1,
                    FromDate = DateTime.Now.AddDays(r.Next(-3000, 0)),
                    Mileage = 0,
                    FuelRemain = 1200,
                    BusStatus = Status.Ready
                },

            };
            listStations = new List<Station>
            {
                new Station
                {
                    Code = 1,
                    Name = "sudanim",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
            };
            listLines = new List<Line>
            {
                new Line
                {
                    ID = 1,
                    Code = 1,
                    Area = Areas.Center,
                    FirstStation = 1,
                    LastStation = 2
                }
            };
        }
    }
}
