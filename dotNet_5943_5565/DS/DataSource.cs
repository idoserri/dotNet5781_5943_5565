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
                    Name = "station1",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 2,
                    Name = "station2",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 3,
                    Name = "station3",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 4,
                    Name = "station4",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 5,
                    Name = "station5",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 6,
                    Name = "station6",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 7,
                    Name = "station7",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 8,
                    Name = "station8",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 9,
                    Name = "station9",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 10,
                    Name = "station10",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 11,
                    Name = "station11",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 12,
                    Name = "station12",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 13,
                    Name = "station13",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 14,
                    Name = "station14",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 15,
                    Name = "station15",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 16,
                    Name = "station16",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 17,
                    Name = "station17",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 18,
                    Name = "station18",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 19,
                    Name = "station19",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 20,
                    Name = "station10",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 21,
                    Name = "station21",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 22,
                    Name = "station22",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 23,
                    Name = "station23",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 24,
                    Name = "station24",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 25,
                    Name = "station25",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 26,
                    Name = "station26",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 27,
                    Name = "station27",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 28,
                    Name = "station28",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 29,
                    Name = "station29",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 30,
                    Name = "station30",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 31,
                    Name = "station31",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 32,
                    Name = "station32",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 33,
                    Name = "station33",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 34,
                    Name = "station34",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 35,
                    Name = "station35",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 36,
                    Name = "station36",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 37,
                    Name = "station37",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 38,
                    Name = "station38",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 39,
                    Name = "station39",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 40,
                    Name = "station40",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 41,
                    Name = "station41",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 42,
                    Name = "station42",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 43,
                    Name = "station43",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 44,
                    Name = "station44",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 45,
                    Name = "station45",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 46,
                    Name = "station46",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 47,
                    Name = "station47",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 48,
                    Name = "station48",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 49,
                    Name = "station49",
                    Latitude =  r.NextDouble() * (33.3 - 31) + 31,
                    Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3,
                },
                new Station
                {
                    Code = 50,
                    Name = "station50",
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
                    LastStation = 10
                },
                new Line
                {
                    ID = 2,
                    Code = 2,
                    Area = Areas.Center,
                    FirstStation = 5,
                    LastStation = 15
                },
                new Line
                {
                    ID = 3,
                    Code = 3,
                    Area = Areas.General,
                    FirstStation = 10,
                    LastStation = 20
                },
                new Line
                {
                    ID = 4,
                    Code = 4,
                    Area = Areas.General,
                    FirstStation = 15,
                    LastStation = 25
                },
                new Line
                {
                    ID = 5,
                    Code = 5,
                    Area = Areas.Jerusalem,
                    FirstStation = 20,
                    LastStation = 30
                },
                new Line
                {
                    ID = 6,
                    Code = 6,
                    Area = Areas.Jerusalem,
                    FirstStation = 25,
                    LastStation = 35
                },
                new Line
                {
                    ID = 7,
                    Code = 7,
                    Area = Areas.North,
                    FirstStation = 30,
                    LastStation = 40
                },
                new Line
                {
                    ID = 8,
                    Code = 8,
                    Area = Areas.North,
                    FirstStation = 35,
                    LastStation = 45
                },
                new Line
                {
                    ID = 9,
                    Code = 9,
                    Area = Areas.South,
                    FirstStation = 38,
                    LastStation = 48
                },
                new Line
                {
                    ID = 10,
                    Code = 10,
                    Area = Areas.South,
                    FirstStation = 40,
                    LastStation = 50,
                }
            };

            listLineStations = new List<LineStation>
            {
                // line 1 (stations 1-10)
                new LineStation
                {
                    LineID = 1,
                    Station = 1,
                    LineStationIndex = 1,
                    PrevStation = 0, // 0 means there is not prev/next station
                    NextStation = 2
                },
                new LineStation
                {
                    LineID = 1,
                    Station = 2,
                    LineStationIndex = 2,
                    PrevStation = 1, 
                    NextStation = 3
                },
                new LineStation
                {
                    LineID = 1,
                    Station = 3,
                    LineStationIndex = 3,
                    PrevStation = 2,
                    NextStation = 4
                },
                new LineStation
                {
                    LineID = 1,
                    Station = 4,
                    LineStationIndex = 4,
                    PrevStation = 3,
                    NextStation = 5
                },
                new LineStation
                {
                    LineID = 1,
                    Station = 5,
                    LineStationIndex =5,
                    PrevStation = 4,
                    NextStation = 6
                },
                new LineStation
                {
                    LineID = 1,
                    Station = 6,
                    LineStationIndex = 6,
                    PrevStation = 5,
                    NextStation = 7
                },
                new LineStation
                {
                    LineID = 1,
                    Station = 7,
                    LineStationIndex = 7,
                    PrevStation = 6,
                    NextStation = 8
                },
                new LineStation
                {
                    LineID = 1,
                    Station = 8,
                    LineStationIndex = 8,
                    PrevStation = 7,
                    NextStation = 9
                },
                new LineStation
                {
                    LineID = 1,
                    Station = 9,
                    LineStationIndex = 9,
                    PrevStation = 8,
                    NextStation = 10
                },
                new LineStation
                {
                    LineID = 1,
                    Station = 10,
                    LineStationIndex = 10,
                    PrevStation = 9,
                    NextStation = 0  // 0 means there is not prev/next station
                },
                // end of line 1

                // line 2 (stations 5-15)
                new LineStation
                {
                    LineID = 2,
                    Station = 5,
                    LineStationIndex = 1,
                    PrevStation = 0,
                    NextStation = 6
                },

                //will be continued***********

            };
        }
    }
}
