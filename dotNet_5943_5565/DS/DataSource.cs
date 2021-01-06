using System;
using System.Device.Location;
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
        public static Random r = new Random();
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
             }

         };
            #endregion

            #region Stations
            listStations = new List<Station>
            {
                new Station
                {
                    Code = 1,
                    Name = "Dr. Josheph Burg St.",
                    Latitude =  31.968936,
                    Longitude = 34.820043,
                },
                new Station
                {
                    Code = 2,
                    Name = "Vietzman St.",
                    Latitude =  31.923041,
                    Longitude = 34.798033,
                },
                new Station
                {
                    Code = 3,
                    Name = "Moshe Dayan Blvd.",
                    Latitude =  31.98568,
                    Longitude = 34.764014,
                },
                new Station
                {
                    Code = 4,
                    Name = "Haim Moshe Shapira 4",
                    Latitude =  31.992583,
                    Longitude = 34.751999,
                },
                new Station
                {
                    Code = 5,
                    Name = "Haim Moshe Shapira 16",
                    Latitude =  31.990757,
                    Longitude = 34.755683,
                },
                new Station
                {
                    Code = 6,
                    Name = "Jacob Blvd. 65",
                    Latitude =  31.950254,
                    Longitude = 34.819244,
                },
                new Station
                {
                    Code = 7,
                    Name = "Jacob Blvd. 59",
                    Latitude = 31.95111,
                    Longitude = 34.819766,
                },
                new Station
                {
                    Code = 8,
                    Name = "Yehuda Leib Yosefzona St.",
                    Latitude =  31.905052,
                    Longitude = 34.818909,
                },
                new Station
                {
                    Code = 9,
                    Name = "Rabbi Yaakov Berman 4",
                    Latitude = 31.901879,
                    Longitude = 34.819443,
                },
                new Station
                {
                    Code = 10,
                    Name = "Rabbi Yaakov Berman St.",
                    Latitude = 31.90281,
                    Longitude = 34.818922,
                },
                new Station
                {
                    Code = 11,
                    Name = "Shulamit 2",
                    Latitude = 32.270586,
                    Longitude = 34.837598,
                },
                new Station
                {
                    Code = 12,
                    Name = "Shosh Atari/Blob",
                    Latitude =  32.272632,
                    Longitude = 34.838726,
                },
                new Station
                {
                    Code = 13,
                    Name = "Shosh Atari/Gleb",
                    Latitude =  32.27242,
                    Longitude = 34.838508,
                },
                new Station
                {
                    Code = 14,
                    Name = "Ehud Manor/Larry King",
                    Latitude =  32.274543,
                    Longitude = 34.8413,
                },
                new Station
                {
                    Code = 15,
                    Name = "Ehud Manor/Prince Boi",
                    Latitude =  32.27487,
                    Longitude = 34.842868,
                },
                new Station
                {
                    Code = 16,
                    Name = "Zalman Shazar/Stephen Murry",
                    Latitude =  32.27572,
                    Longitude = 34.845201,
                },
                new Station
                {
                    Code = 17,
                    Name = "Zalman Shazar/Connor McFly",
                    Latitude =  32.276562,
                    Longitude = 34.846404,
                },
                new Station
                {
                    Code = 18,
                    Name = "Zalman Shazar/Lemurs",
                    Latitude =  32.276837,
                    Longitude = 34.847509,
                },
                new Station
                {
                    Code = 19,
                    Name = "Adam/Bojack Faceman",
                    Latitude =  32.256581,
                    Longitude = 34.864843,
                },
                new Station
                {
                    Code = 20,
                    Name = "Golda Meir Blvd.",
                    Latitude =  32.27659,
                    Longitude = 34.85165,
                },
                new Station
                {
                    Code = 21,
                    Name = "Havradim/Peanut Butter",
                    Latitude = 32.267569,
                    Longitude = 34.913161,
                },
                new Station
                {
                    Code = 22,
                    Name = "Haerez/Vineman",
                    Latitude =  32.266731,
                    Longitude = 34.913567,
                },
                new Station
                {
                    Code = 23,
                    Name = "Katzanelson/Coodchuck-Berkowitz",
                    Latitude =  32.272356,
                    Longitude = 34.9105,
                },
                new Station
                {
                    Code = 24,
                    Name = "Yoseftal/Vincent Adultman",
                    Latitude =  32.27471,
                    Longitude = 34.907677,
                },
                new Station
                {
                    Code = 25,
                    Name = "Yanosh Korchack/Todd Chavez",
                    Latitude = 32.275943,
                    Longitude = 34.908497,
                },
                new Station
                {
                    Code = 26,
                    Name = "Melvin Gordon/Derrick Henry",
                    Latitude =  32.273996,
                    Longitude = 34.909588,
                },
                new Station
                {
                    Code = 27,
                    Name = "Yanosh Korchack/James Yarden",
                    Latitude = 32.275772,
                    Longitude = 34.909654,
                },
                new Station
                {
                    Code = 28,
                    Name = "Yanosh Korchack/Morty McRick",
                    Latitude = 32.275743,
                    Longitude = 34.910497,
                },
                new Station
                {
                    Code = 29,
                    Name = "Jabotinsky/Lebowski",
                    Latitude =  32.268747,
                    Longitude = 34.91245,
                },
                new Station
                {
                    Code = 30,
                    Name = "Hahistadrut/Kenya",
                    Latitude =  32.269922,
                    Longitude = 34.912325,
                },
                new Station
                {
                    Code = 31,
                    Name = "Hahistadrut West",
                    Latitude =  32.2710195,
                    Longitude = 34.912545,
                },
                new Station
                {
                    Code = 32,
                    Name = "Shawazzi/Yemen",
                    Latitude =  32.272628,
                    Longitude = 34.911703,
                },
                new Station
                {
                    Code = 33,
                    Name = "Ahidekel/Mahms Pageti",
                    Latitude =  32.269267,
                    Longitude = 34.913385,
                },
                new Station
                {
                    Code = 34,
                    Name = "M.G. Morgan",
                    Latitude =  32.271478,
                    Longitude = 34.913327,
                },
                new Station
                {
                    Code = 35,
                    Name = "M.G. Gaecant",
                    Latitude =  32.271388,
                    Longitude = 34.914331,
                },
                new Station
                {
                    Code = 36,
                    Name = "Shawazzi/Plozki",
                    Latitude = 32.273004,
                    Longitude = 34.913138,
                },
                new Station
                {
                    Code = 37,
                    Name = "Shawazzi/Klotzki",
                    Latitude =  32.273334,
                    Longitude = 34.913549,
                },
                new Station
                {
                    Code = 38,
                    Name = "Yavne/Lienz",
                    Latitude =  32.180757,
                    Longitude = 34.915164,
                },
                new Station
                {
                    Code = 39,
                    Name = "Bar Ilan/Indira",
                    Latitude =  32.181731,
                    Longitude = 34.913225,
                },
                new Station
                {
                    Code = 40,
                    Name = "Azar/Help",
                    Latitude =  32.182884,
                    Longitude = 34.914328,
                },
                new Station
                {
                    Code = 41,
                    Name = "Zamanhoff/Schwarzenegger",
                    Latitude = 32.177881,
                    Longitude = 34.920374,
                },
                new Station
                {
                    Code = 42,
                    Name = "Hagalil/Pls",
                    Latitude =  32.177963,
                    Longitude = 34.918212,
                },
                new Station
                {
                    Code = 43,
                    Name = "Hagalil/Pizdetz",
                    Latitude =  32.176566,
                    Longitude = 34.917749,
                },
                new Station
                {
                    Code = 44,
                    Name = "Hacarmel/Habbznot",
                    Latitude =  32.176925,
                    Longitude = 34.914404,
                },
                new Station
                {
                    Code = 45,
                    Name = "Hacarmel/Hatavloor",
                    Latitude = 32.177581,
                    Longitude = 34.911645,
                },
                new Station
                {
                    Code = 46,
                    Name = "Hacarmel/Sekiro",
                    Latitude =  32.178461,
                    Longitude = 34.907682,
                },
                new Station
                {
                    Code = 47,
                    Name = "Veitzman/Vineman",
                    Latitude =  32.173907,
                    Longitude = 34.914826,
                },
                new Station
                {
                    Code = 48,
                    Name = "Hashachar/Hanutella",
                    Latitude =  32.180341,
                    Longitude = 34.909755,
                },
                new Station
                {
                    Code = 49,
                    Name = "Tscharnichovsky/Pewders",
                    Latitude =  32.1865,
                    Longitude = 34.903738,
                },
                new Station
                {
                    Code = 50,
                    Name = "Tscharnichovsky/Levov",
                    Latitude =  32.189203,
                    Longitude = 34.906032,
                }


            };
            #endregion

            #region Lines
            listLines = new List<Line>
            {
                new Line
                {
                    ID = 1,
                    LineNum = 1,
                    Area = Areas.Center,
                    FirstStation = 1,
                    LastStation = 10
                },
                new Line
                {
                    ID = 2,
                    LineNum = 2,
                    Area = Areas.Center,
                    FirstStation = 5,
                    LastStation = 15
                },
                new Line
                {
                    ID = 3,
                    LineNum = 3,
                    Area = Areas.General,
                    FirstStation = 10,
                    LastStation = 20
                },
                new Line
                {
                    ID = 4,
                    LineNum = 4,
                    Area = Areas.General,
                    FirstStation = 15,
                    LastStation = 25
                },
                new Line
                {
                    ID = 5,
                    LineNum = 5,
                    Area = Areas.Jerusalem,
                    FirstStation = 20,
                    LastStation = 30
                },
                new Line
                {
                    ID = 6,
                    LineNum = 6,
                    Area = Areas.Jerusalem,
                    FirstStation = 25,
                    LastStation = 35
                },
                new Line
                {
                    ID = 7,
                    LineNum = 7,
                    Area = Areas.North,
                    FirstStation = 30,
                    LastStation = 40
                },
                new Line
                {
                    ID = 8,
                    LineNum = 8,
                    Area = Areas.North,
                    FirstStation = 35,
                    LastStation = 45
                },
                new Line
                {
                    ID = 9,
                    LineNum = 9,
                    Area = Areas.South,
                    FirstStation = 38,
                    LastStation = 48
                },
                new Line
                {
                    ID = 10,
                    LineNum = 10,
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
                }
                #endregion
                

            };
            #endregion


            #region AdjStations
            listAdjacentStations = new List<AdjacentStations>();

            for (int i = 0; i < listStations.Count()-1; i++)
            {
                var s1 = new GeoCoordinate(listStations[i].Latitude, listStations[i].Longitude);
                var s2 = new GeoCoordinate(listStations[i+1].Latitude, listStations[i+1].Longitude);
                double distance = s1.GetDistanceTo(s2);
                int sec = (int)(distance + r.NextDouble() * 0.5 * distance) / 14;  // meter/sec
                TimeSpan t = new TimeSpan(0,0,sec);

                listAdjacentStations.Add(
                    new AdjacentStations
                    {
                        Station1 = listStations[i].Code,
                        Station2 = listStations[i + 1].Code,
                        Distance = distance/1000,
                        Time = t
                    });

            }
            #endregion
        }
    }
}
