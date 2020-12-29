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
            #region Busses
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
                new Bus
                {
                    LicenseNum = 10,
                    FromDate = DateTime.Now.AddDays(r.Next(-3000, 0)),
                    Mileage = 0,
                    FuelRemain = 1200,
                    BusStatus = Status.Ready
                },
                new Bus
                {
                    LicenseNum = 11,
                    FromDate = DateTime.Now.AddDays(r.Next(-3000, 0)),
                    Mileage = 0,
                    FuelRemain = 1200,
                    BusStatus = Status.Ready
                },
                new Bus
                {
                    LicenseNum = 100,
                    FromDate = DateTime.Now.AddDays(r.Next(-3000, 0)),
                    Mileage = 0,
                    FuelRemain = 1200,
                    BusStatus = Status.Ready
                },
                new Bus
                {
                    LicenseNum = 101,
                    FromDate = DateTime.Now.AddDays(r.Next(-3000, 0)),
                    Mileage = 0,
                    FuelRemain = 1200,
                    BusStatus = Status.Ready
                },
                new Bus
                {
                    LicenseNum = 110,
                    FromDate = DateTime.Now.AddDays(r.Next(-3000, 0)),
                    Mileage = 0,
                    FuelRemain = 1200,
                    BusStatus = Status.Ready
                },
                new Bus
                {
                    LicenseNum = 111,
                    FromDate = DateTime.Now.AddDays(r.Next(-3000, 0)),
                    Mileage = 0,
                    FuelRemain = 1200,
                    BusStatus = Status.Ready
                },
                new Bus
                {
                    LicenseNum = 1000,
                    FromDate = DateTime.Now.AddDays(r.Next(-3000, 0)),
                    Mileage = 0,
                    FuelRemain = 1200,
                    BusStatus = Status.Ready
                },
                new Bus
                {
                    LicenseNum = 1001,
                    FromDate = DateTime.Now.AddDays(r.Next(-3000, 0)),
                    Mileage = 0,
                    FuelRemain = 1200,
                    BusStatus = Status.Ready
                },
                new Bus
                {
                    LicenseNum = 1010,
                    FromDate = DateTime.Now.AddDays(r.Next(-3000, 0)),
                    Mileage = 0,
                    FuelRemain = 1200,
                    BusStatus = Status.Ready
                },
                new Bus
                {
                    LicenseNum = 1011,
                    FromDate = DateTime.Now.AddDays(r.Next(-3000, 0)),
                    Mileage = 0,
                    FuelRemain = 1200,
                    BusStatus = Status.Ready
                },
                new Bus
                {
                    LicenseNum = 1100,
                    FromDate = DateTime.Now.AddDays(r.Next(-3000, 0)),
                    Mileage = 0,
                    FuelRemain = 1200,
                    BusStatus = Status.Ready
                },
                new Bus
                {
                    LicenseNum = 1101,
                    FromDate = DateTime.Now.AddDays(r.Next(-3000, 0)),
                    Mileage = 0,
                    FuelRemain = 1200,
                    BusStatus = Status.Ready
                },
                new Bus
                {
                    LicenseNum = 1110,
                    FromDate = DateTime.Now.AddDays(r.Next(-3000, 0)),
                    Mileage = 0,
                    FuelRemain = 1200,
                    BusStatus = Status.Ready
                },
                new Bus
                {
                    LicenseNum = 1111,
                    FromDate = DateTime.Now.AddDays(r.Next(-3000, 0)),
                    Mileage = 0,
                    FuelRemain = 1200,
                    BusStatus = Status.Ready
                },
                new Bus
                {
                    LicenseNum = 10000,
                    FromDate = DateTime.Now.AddDays(r.Next(-3000, 0)),
                    Mileage = 0,
                    FuelRemain = 1200,
                    BusStatus = Status.Ready
                },
                new Bus
                {
                    LicenseNum = 10001,
                    FromDate = DateTime.Now.AddDays(r.Next(-3000, 0)),
                    Mileage = 0,
                    FuelRemain = 1200,
                    BusStatus = Status.Ready
                },
                new Bus
                {
                    LicenseNum = 10010,
                    FromDate = DateTime.Now.AddDays(r.Next(-3000, 0)),
                    Mileage = 0,
                    FuelRemain = 1200,
                    BusStatus = Status.Ready
                },
                new Bus
                {
                    LicenseNum = 10011,
                    FromDate = DateTime.Now.AddDays(r.Next(-3000, 0)),
                    Mileage = 0,
                    FuelRemain = 1200,
                    BusStatus = Status.Ready
                },
                new Bus
                {
                    LicenseNum = 10100,
                    FromDate = DateTime.Now.AddDays(r.Next(-3000, 0)),
                    Mileage = 0,
                    FuelRemain = 1200,
                    BusStatus = Status.Ready
                },
            };
            #endregion

            #region Stations
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
            #endregion

            #region Lines
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
            #endregion

            #region LineStations
            listLineStations = new List<LineStation>
            {
                #region line 1 (stations 1-10)
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
                #endregion

                #region line 2 (stations 5-15)
                new LineStation
                {
                    LineID = 2,
                    Station = 5,
                    LineStationIndex = 1,
                    PrevStation = 0,
                    NextStation = 6
                },
                new LineStation
                {
                    LineID = 2,
                    Station = 6,
                    LineStationIndex = 2,
                    PrevStation = 5,
                    NextStation = 7
                },
                new LineStation
                {
                    LineID = 2,
                    Station = 7,
                    LineStationIndex = 3,
                    PrevStation = 6,
                    NextStation = 8
                },
                new LineStation
                {
                    LineID = 2,
                    Station = 8,
                    LineStationIndex = 4,
                    PrevStation = 7,
                    NextStation = 9
                },
                new LineStation
                {
                    LineID = 2,
                    Station = 9,
                    LineStationIndex = 5,
                    PrevStation = 8,
                    NextStation = 10
                },
                new LineStation
                {
                    LineID = 2,
                    Station = 10,
                    LineStationIndex = 6,
                    PrevStation = 9,
                    NextStation = 11
                },
                new LineStation
                {
                    LineID = 2,
                    Station = 11,
                    LineStationIndex = 7,
                    PrevStation = 10,
                    NextStation = 12
                },
                new LineStation
                {
                    LineID = 2,
                    Station = 12,
                    LineStationIndex = 8,
                    PrevStation = 11,
                    NextStation = 13
                },
                new LineStation
                {
                    LineID = 2,
                    Station = 13,
                    LineStationIndex = 9,
                    PrevStation = 12,
                    NextStation = 14
                },
                new LineStation
                {
                    LineID = 2,
                    Station = 14,
                    LineStationIndex = 10,
                    PrevStation = 13,
                    NextStation = 15
                },
                new LineStation
                {
                    LineID = 2,
                    Station = 15,
                    LineStationIndex = 11,
                    PrevStation = 14,
                    NextStation = 0
                },
                #endregion

                #region line 3 (stations 10-20)
                new LineStation
                {
                    LineID = 3,
                    Station = 10,
                    LineStationIndex = 1,
                    PrevStation = 0, // 0 means there is not prev/next station
                    NextStation = 11
                },
                new LineStation
                {
                    LineID = 3,
                    Station = 11,
                    LineStationIndex = 2,
                    PrevStation = 10, 
                    NextStation = 12
                },
                new LineStation
                {
                    LineID = 3,
                    Station = 12,
                    LineStationIndex = 3,
                    PrevStation = 11, 
                    NextStation = 13
                },
                new LineStation
                {
                    LineID = 3,
                    Station = 13,
                    LineStationIndex = 4,
                    PrevStation = 12, 
                    NextStation = 14
                },
                new LineStation
                {
                    LineID = 3,
                    Station = 14,
                    LineStationIndex = 5,
                    PrevStation = 13, 
                    NextStation = 15
                },
                new LineStation
                {
                    LineID = 3,
                    Station = 15,
                    LineStationIndex = 6,
                    PrevStation = 14,
                    NextStation = 16
                },
                new LineStation
                {
                    LineID = 3,
                    Station = 16,
                    LineStationIndex = 7,
                    PrevStation = 15,
                    NextStation = 17
                },
                new LineStation
                {
                    LineID = 3,
                    Station = 17,
                    LineStationIndex = 8,
                    PrevStation = 16,
                    NextStation = 18
                },
                new LineStation
                {
                    LineID = 3,
                    Station = 18,
                    LineStationIndex = 9,
                    PrevStation = 17,
                    NextStation = 19
                },
                new LineStation
                {
                    LineID = 3,
                    Station = 19,
                    LineStationIndex = 10,
                    PrevStation = 18,
                    NextStation = 20
                },
                new LineStation
                {
                    LineID = 3,
                    Station = 20,
                    LineStationIndex = 11,
                    PrevStation = 19,
                    NextStation = 0
                },
                #endregion

                #region line 4 (stations 15-25)
                new LineStation
                {
                    LineID = 4,
                    Station = 15,
                    LineStationIndex = 1,
                    PrevStation = 0,
                    NextStation = 16
                },
                new LineStation
                {
                    LineID = 4,
                    Station = 16,
                    LineStationIndex = 2,
                    PrevStation = 15,
                    NextStation = 17
                },
                new LineStation
                {
                    LineID = 4,
                    Station = 17,
                    LineStationIndex = 3,
                    PrevStation = 16,
                    NextStation = 18
                },
                new LineStation
                {
                    LineID = 4,
                    Station = 18,
                    LineStationIndex = 4,
                    PrevStation = 17,
                    NextStation = 19
                },
                new LineStation
                {
                    LineID = 4,
                    Station = 19,
                    LineStationIndex = 5,
                    PrevStation = 18,
                    NextStation = 20
                },
                new LineStation
                {
                    LineID = 4,
                    Station = 20,
                    LineStationIndex = 6,
                    PrevStation = 19,
                    NextStation = 21
                },
                new LineStation
                {
                    LineID = 4,
                    Station = 21,
                    LineStationIndex = 7,
                    PrevStation = 20,
                    NextStation = 22
                },
                new LineStation
                {
                    LineID = 4,
                    Station = 22,
                    LineStationIndex = 8,
                    PrevStation = 21,
                    NextStation = 23
                },
                new LineStation
                {
                    LineID = 4,
                    Station = 23,
                    LineStationIndex = 9,
                    PrevStation = 22,
                    NextStation = 24
                },
                new LineStation
                {
                    LineID = 4,
                    Station = 24,
                    LineStationIndex = 10,
                    PrevStation = 23,
                    NextStation = 25
                },
                new LineStation
                {
                    LineID = 4,
                    Station = 25,
                    LineStationIndex = 11,
                    PrevStation = 24,
                    NextStation = 0
                },
                #endregion

                #region line 5 (stations 20-30)
                new LineStation
                {
                    LineID = 5,
                    Station = 20,
                    LineStationIndex = 1,
                    PrevStation = 0,
                    NextStation = 21
                },
                new LineStation
                {
                    LineID = 5,
                    Station = 21,
                    LineStationIndex = 2,
                    PrevStation = 20,
                    NextStation = 22
                },
                new LineStation
                {
                    LineID = 5,
                    Station = 22,
                    LineStationIndex = 3,
                    PrevStation = 21,
                    NextStation = 23
                },
                new LineStation
                {
                    LineID = 5,
                    Station = 23,
                    LineStationIndex = 4,
                    PrevStation = 22,
                    NextStation = 24
                },
                new LineStation
                {
                    LineID = 5,
                    Station = 24,
                    LineStationIndex = 5,
                    PrevStation = 23,
                    NextStation = 25
                },
                new LineStation
                {
                    LineID = 5,
                    Station = 25,
                    LineStationIndex = 6,
                    PrevStation = 24,
                    NextStation = 26
                },
                new LineStation
                {
                    LineID = 5,
                    Station = 26,
                    LineStationIndex = 7,
                    PrevStation = 25,
                    NextStation = 27
                },
                new LineStation
                {
                    LineID = 5,
                    Station = 27,
                    LineStationIndex = 8,
                    PrevStation = 26,
                    NextStation = 28
                },
                new LineStation
                {
                    LineID = 5,
                    Station = 28,
                    LineStationIndex = 9,
                    PrevStation = 27,
                    NextStation = 29
                },
                new LineStation
                {
                    LineID = 5,
                    Station = 29,
                    LineStationIndex = 10,
                    PrevStation = 28,
                    NextStation = 30
                },
                new LineStation
                {
                    LineID = 5,
                    Station = 30,
                    LineStationIndex = 11,
                    PrevStation = 29,
                    NextStation = 0
                },
                #endregion

                #region line 6 (stations 25-35)
                new LineStation
                {
                    LineID = 6,
                    Station = 25,
                    LineStationIndex = 1,
                    PrevStation = 0,
                    NextStation = 26
                },
                new LineStation
                {
                    LineID = 6,
                    Station = 26,
                    LineStationIndex = 2,
                    PrevStation = 25,
                    NextStation = 27
                },
                new LineStation
                {
                    LineID = 6,
                    Station = 27,
                    LineStationIndex = 3,
                    PrevStation = 26,
                    NextStation = 28
                },
                new LineStation
                {
                    LineID = 6,
                    Station = 28,
                    LineStationIndex = 4,
                    PrevStation = 27,
                    NextStation = 29
                },
                new LineStation
                {
                    LineID = 6,
                    Station = 29,
                    LineStationIndex = 5,
                    PrevStation = 28,
                    NextStation = 30
                },
                new LineStation
                {
                    LineID = 6,
                    Station = 30,
                    LineStationIndex = 6,
                    PrevStation = 29,
                    NextStation = 31
                },
                new LineStation
                {
                    LineID = 6,
                    Station = 31,
                    LineStationIndex = 7,
                    PrevStation = 30,
                    NextStation = 32
                },
                new LineStation
                {
                    LineID = 6,
                    Station = 32,
                    LineStationIndex = 8,
                    PrevStation = 31,
                    NextStation = 33
                },
                new LineStation
                {
                    LineID = 6,
                    Station = 33,
                    LineStationIndex = 9,
                    PrevStation = 32,
                    NextStation = 34
                },
                new LineStation
                {
                    LineID = 6,
                    Station = 34,
                    LineStationIndex = 10,
                    PrevStation = 33,
                    NextStation = 35
                },
                new LineStation
                {
                    LineID = 6,
                    Station = 35,
                    LineStationIndex = 11,
                    PrevStation = 34,
                    NextStation = 0
                },
                #endregion

                #region line 7 (stations 30-40)
                new LineStation
                {
                    LineID = 7,
                    Station = 30,
                    LineStationIndex = 1,
                    PrevStation = 0,
                    NextStation = 31
                },
                new LineStation
                {
                    LineID = 7,
                    Station = 31,
                    LineStationIndex = 2,
                    PrevStation = 30,
                    NextStation = 32
                },
                new LineStation
                {
                    LineID = 7,
                    Station = 32,
                    LineStationIndex = 3,
                    PrevStation = 31,
                    NextStation = 33
                },
                new LineStation
                {
                    LineID = 7,
                    Station = 33,
                    LineStationIndex = 4,
                    PrevStation = 32,
                    NextStation = 34
                },
                new LineStation
                {
                    LineID = 7,
                    Station = 34,
                    LineStationIndex = 5,
                    PrevStation = 33,
                    NextStation = 35
                },
                new LineStation
                {
                    LineID = 7,
                    Station = 35,
                    LineStationIndex = 6,
                    PrevStation = 34,
                    NextStation = 36
                },
                new LineStation
                {
                    LineID = 7,
                    Station = 36,
                    LineStationIndex = 7,
                    PrevStation = 35,
                    NextStation = 37
                },
                new LineStation
                {
                    LineID = 7,
                    Station = 37,
                    LineStationIndex = 8,
                    PrevStation = 36,
                    NextStation = 38
                },
                new LineStation
                {
                    LineID = 7,
                    Station = 38,
                    LineStationIndex = 9,
                    PrevStation = 37,
                    NextStation = 39
                },
                new LineStation
                {
                    LineID = 7,
                    Station = 39,
                    LineStationIndex = 10,
                    PrevStation = 38,
                    NextStation = 40
                },
                new LineStation
                {
                    LineID = 7,
                    Station = 40,
                    LineStationIndex = 11,
                    PrevStation = 39,
                    NextStation = 0
                },
                #endregion

                #region line 8 (stations 35-45)
                new LineStation
                {
                    LineID = 8,
                    Station = 35,
                    LineStationIndex = 1,
                    PrevStation = 0,
                    NextStation = 36
                },
                new LineStation
                {
                    LineID = 8,
                    Station = 36,
                    LineStationIndex = 2,
                    PrevStation = 35,
                    NextStation = 37
                },
                new LineStation
                {
                    LineID = 8,
                    Station = 37,
                    LineStationIndex = 3,
                    PrevStation = 36,
                    NextStation = 38
                },
                new LineStation
                {
                    LineID = 8,
                    Station = 38,
                    LineStationIndex = 4,
                    PrevStation = 37,
                    NextStation = 39
                },
                new LineStation
                {
                    LineID = 8,
                    Station = 39,
                    LineStationIndex = 5,
                    PrevStation = 38,
                    NextStation = 40
                },
                new LineStation
                {
                    LineID = 8,
                    Station = 40,
                    LineStationIndex = 6,
                    PrevStation = 39,
                    NextStation = 41
                },
                new LineStation
                {
                    LineID = 8,
                    Station = 41,
                    LineStationIndex = 7,
                    PrevStation = 40,
                    NextStation = 42
                },
                new LineStation
                {
                    LineID = 8,
                    Station = 42,
                    LineStationIndex = 8,
                    PrevStation = 41,
                    NextStation = 43
                },
                new LineStation
                {
                    LineID = 8,
                    Station = 43,
                    LineStationIndex = 9,
                    PrevStation = 42,
                    NextStation = 44
                },
                new LineStation
                {
                    LineID = 8,
                    Station = 44,
                    LineStationIndex = 10,
                    PrevStation = 43,
                    NextStation = 45
                },
                new LineStation
                {
                    LineID = 8,
                    Station = 45,
                    LineStationIndex = 11,
                    PrevStation = 44,
                    NextStation = 0
                },
                #endregion

                #region line 9 (stations 38-48)
                new LineStation
                {
                    LineID = 9,
                    Station = 38,
                    LineStationIndex = 1,
                    PrevStation = 0,
                    NextStation = 39
                },
                new LineStation
                {
                    LineID = 9,
                    Station = 39,
                    LineStationIndex = 2,
                    PrevStation = 38,
                    NextStation = 40
                },
                new LineStation
                {
                    LineID = 9,
                    Station = 40,
                    LineStationIndex = 3,
                    PrevStation = 39,
                    NextStation = 41
                },
                new LineStation
                {
                    LineID = 9,
                    Station = 41,
                    LineStationIndex = 4,
                    PrevStation = 40,
                    NextStation = 42
                },
                new LineStation
                {
                    LineID = 9,
                    Station = 42,
                    LineStationIndex = 5,
                    PrevStation = 41,
                    NextStation = 43
                },
                new LineStation
                {
                    LineID = 9,
                    Station = 43,
                    LineStationIndex = 6,
                    PrevStation = 42,
                    NextStation = 44
                },
                new LineStation
                {
                    LineID = 9,
                    Station = 44,
                    LineStationIndex = 7,
                    PrevStation = 43,
                    NextStation = 45
                },
                new LineStation
                {
                    LineID = 9,
                    Station = 45,
                    LineStationIndex = 8,
                    PrevStation = 44,
                    NextStation = 46
                },
                new LineStation
                {
                    LineID = 9,
                    Station = 46,
                    LineStationIndex = 9,
                    PrevStation = 45,
                    NextStation = 47
                },
                new LineStation
                {
                    LineID = 9,
                    Station = 47,
                    LineStationIndex = 10,
                    PrevStation = 46,
                    NextStation = 48
                },
                new LineStation
                {
                    LineID = 9,
                    Station = 48,
                    LineStationIndex = 11,
                    PrevStation = 47,
                    NextStation = 0
                },
                #endregion

                #region line 10 (stations 40-50)
                new LineStation
                {
                    LineID = 10,
                    Station = 40,
                    LineStationIndex = 1,
                    PrevStation = 0,
                    NextStation = 41
                },
                new LineStation
                {
                    LineID = 10,
                    Station = 41,
                    LineStationIndex = 2,
                    PrevStation = 40,
                    NextStation = 42
                },
                new LineStation
                {
                    LineID = 10,
                    Station = 42,
                    LineStationIndex = 3,
                    PrevStation = 41,
                    NextStation = 43
                },
                new LineStation
                {
                    LineID = 10,
                    Station = 43,
                    LineStationIndex = 4,
                    PrevStation = 42,
                    NextStation = 44
                },
                new LineStation
                {
                    LineID = 10,
                    Station = 44,
                    LineStationIndex = 5,
                    PrevStation = 43,
                    NextStation = 45
                },
                new LineStation
                {
                    LineID = 10,
                    Station = 45,
                    LineStationIndex = 6,
                    PrevStation = 44,
                    NextStation = 46
                },
                new LineStation
                {
                    LineID = 10,
                    Station = 46,
                    LineStationIndex = 7,
                    PrevStation = 45,
                    NextStation = 47
                },
                new LineStation
                {
                    LineID = 10,
                    Station = 47,
                    LineStationIndex = 8,
                    PrevStation = 46,
                    NextStation = 48
                },
                new LineStation
                {
                    LineID = 10,
                    Station = 48,
                    LineStationIndex = 9,
                    PrevStation = 47,
                    NextStation = 49
                },
                new LineStation
                {
                    LineID = 10,
                    Station = 49,
                    LineStationIndex = 10,
                    PrevStation = 48,
                    NextStation = 50
                },
                new LineStation
                {
                    LineID = 10,
                    Station = 50,
                    LineStationIndex = 11,
                    PrevStation = 49,
                    NextStation = 0
                },
                #endregion
                //will be continued***********

            };
            #endregion
        }
    }
}
