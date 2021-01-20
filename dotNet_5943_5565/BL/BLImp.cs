using System;
using System.Device.Location;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLAPI;
using BO;
using DLAPI;


namespace BL
{
    class BLImp : IBL
    {
        IDL dl = DLFactory.GetDL();
        static Random r = new Random();

        #region singelton
        static readonly BLImp instance = new BLImp();
        static BLImp() { }// static ctor to ensure instance init is done just before first usage
        public BLImp() { }
        public static BLImp Instance { get => instance; }// The public Instance property to use
        #endregion

        #region Bus
        BO.Bus BusBoDoAdapter(DO.Bus busDO)
        {
            BO.Bus busBO = new BO.Bus();
            busDO.CopyPropertiesTo(busBO);
            busBO.LicenseNumName = LicenseNumConverter(busBO);
            return busBO;
        }
        string LicenseNumConverter(BO.Bus bus)
        {
            {
                if (bus.FromDate.Year >= 2018)
                {
                    int[] arr = new int[8];
                    int num = bus.LicenseNum;
                    for (int i = 7; i >= 0; i--)
                    {
                        arr[i] = num % 10;
                        num /= 10;
                    }
                    return String.Format("{0}{1}{2}-{3}{4}-{5}{6}{7}",
                        arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6], arr[7]);
                }
                else
                {
                    int[] arr = new int[7];
                    int num = bus.LicenseNum;
                    for (int i = 6; i >= 0; i--)
                    {
                        arr[i] = num % 10;
                        num /= 10;
                    }
                    return String.Format("{0}{1}-{2}{3}{4}-{5}{6}",
                        arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);
                }
            }
        }
        public Bus GetBus(int license)
        {
            throw new NotImplementedException();
        }
        public void AddBus(Bus busBO)
        {
            DO.Bus busDO = new DO.Bus();
            busBO.CopyPropertiesTo(busDO);
            dl.AddBus(busDO);
        }
        public void DeleteBus(int license)
        {
            try
            {
                dl.DeleteBus(license);
            }
            catch //create new exception for id
            {
                throw new NotImplementedException();
            }
        }
        public IEnumerable<Bus> GetAllBusses()
        {
            return from item in dl.GetAllBusses()
                   select BusBoDoAdapter(item);
        }
        public IEnumerable<Bus> GetBussesBy(Predicate<Bus> predicate)
        {
            throw new NotImplementedException();
        }
        public void UpdateBus(Bus bus)
        {
            DO.Bus busDO = new DO.Bus();
            bus.CopyPropertiesTo(busDO);
            dl.UpdateBus(busDO);
        }

        #endregion

        #region Line
        public double CalcTotalLineDistance(BO.Line line)
        {
            return (from dis in line.ListOfLineStations
                    where dis.NextStation != 0
                    select CalcDistance(GetStation(dis.Station), GetStation(dis.NextStation))).Sum()/1000;
        }
        public string CalcTotalLineTime(BO.Line line)
        {
            IEnumerable<TimeSpan> list = from dis in line.ListOfLineStations
                                         where dis.NextStation != 0
                                         select CalcTime(GetStation(dis.Station), GetStation(dis.NextStation));
            TimeSpan total = new TimeSpan(0,0,0);
            foreach (TimeSpan time in list)
                total += time;
            return total.ToString().Substring(0, 8);
        }
        BO.Line LineBoDoAdapter(DO.Line lineDO)
        {
            BO.Line lineBO = new BO.Line();
            lineDO.CopyPropertiesTo(lineBO);
            lineBO.ListOfLineStations = from item in GetAllLineStations()
                                        where item.LineID == lineBO.ID
                                        orderby item.LineStationIndex ascending
                                        select item;
            lineBO.LastStationName = LineNameConverter(lineBO);
            return lineBO;
        }
        string LineNameConverter(BO.Line line)
        {
            //try catch in case is empty
            return GetAllStations().ToList()
                .Find(s => s.Code == line.ListOfLineStations.Last().Station).Name;
        }
        public IEnumerable<BO.Station> GetAllStationsNotInLine(BO.Line line)
        {
            BO.Line lineB = GetLine(line.ID);
            return from station in GetAllStations()
                   where lineB.ListOfLineStations.ToList().
                   Find(s => s.Station == station.Code) == null
                   select station;
        }
        public IEnumerable<BO.Station> GetAllStationsInLine(BO.Line line)
        {
            BO.Line lineB = GetLine(line.ID);
            return from ls in lineB.ListOfLineStations.OrderBy(ls => ls.LineStationIndex)
                   select GetAllStations().ToList().Find(s => s.Code == ls.Station);
        }
        public void DeleteStationFromLine(BO.Line line, int toRemove)
        {
            IEnumerable<LineStation> list = new List<LineStation>();
            LineStation toDel = GetAllLineStations()
                .FirstOrDefault(ls => ls.LineID == line.ID && ls.Station == toRemove);
            LineStation prevStat = GetAllLineStations()
                .FirstOrDefault(ls => ls.LineID == line.ID && ls.Station == toDel.PrevStation);
            LineStation nextStat = GetAllLineStations()
                .FirstOrDefault(ls => ls.LineID == line.ID && ls.Station == toDel.NextStation);
            if (prevStat == null && nextStat == null)
            {
                DeleteLineStation(line.ID, toDel.Station);
                return;
            }
            if (prevStat != null)
                prevStat.NextStation = toDel.NextStation;
            else
                nextStat.PrevStation = 0;
            if (nextStat != null)
                nextStat.PrevStation = toDel.PrevStation;
            else
                prevStat.NextStation = 0;
            if (prevStat != null)
                UpdateLineStation(prevStat);
            if (nextStat != null)
            {
                UpdateLineStation(nextStat);
                list = from ls in GetAllLineStations()
                       where ls.LineID == line.ID && ls.LineStationIndex >= nextStat.LineStationIndex
                       select ls;
            }
            DeleteLineStation(line.ID, toDel.Station);

            foreach (LineStation ls in list)
                ls.LineStationIndex--;
        }
        public void AddStationToLine(BO.Line line, int toAdd, int addAfter)
        {
            LineStation prevStat = GetAllLineStations().FirstOrDefault(ls => ls.LineID == line.ID && ls.Station == addAfter);
            LineStation nextStat = GetAllLineStations().FirstOrDefault(ls => ls.LineID == line.ID && ls.Station == prevStat.NextStation);
            LineStation toInsert = new LineStation
            {
                LineID = line.ID,
                LineStationIndex = prevStat.LineStationIndex+1,
                Station = toAdd,
                PrevStation = prevStat.Station,
                NextStation = prevStat.NextStation
            };
            prevStat.NextStation = toInsert.Station;
            UpdateLineStation(prevStat);
            if (nextStat != null)
            {
                nextStat.LineStationIndex++;
                nextStat.PrevStation = toInsert.Station;

                IEnumerable<LineStation> list = from ls in GetAllLineStations()
                                                where ls.LineID == line.ID && ls.LineStationIndex >= nextStat.LineStationIndex
                                                select ls;
                foreach (LineStation ls in list)
                    ls.LineStationIndex++;
                UpdateLineStation(nextStat);
                AdjStations adjStations2 = new AdjStations
                {
                    Station1 = toInsert.Station,
                    Station2 = nextStat.Station,
                    Distance = CalcDistance(GetStation(toAdd), GetStation(nextStat.Station)),
                    Time = CalcTime(GetStation(toAdd), GetStation(nextStat.Station))
                };
                AddAdjStations(adjStations2);
            }
            AddLineStation(toInsert);
            AdjStations adjStations1 = new AdjStations
            {
                Station1 = prevStat.Station,
                Station2 = toInsert.Station,
                Distance = CalcDistance(GetStation(toAdd), GetStation(addAfter)),
                Time = CalcTime(GetStation(toAdd), GetStation(addAfter)),
            };
            AddAdjStations(adjStations1);
        }
        public void AddLine(Line line, LineStation first, LineStation last)
        {
            AddLineStation(first);
            AddLineStation(last);
            AdjStations adj = new AdjStations
            {
                Station1 = first.Station,
                Station2 = last.Station,
                Distance = CalcDistance(GetStation(first.Station), GetStation(last.Station)),
                Time = CalcTime(GetStation(first.Station), GetStation(last.Station))
            };
            AddAdjStations(adj);
            DO.Line lineDO = new DO.Line();
            line.CopyPropertiesTo(lineDO);
            dl.AddLine(lineDO);
        }
        public void DeleteLine(int id)
        {
            try
            {
                dl.DeleteLine(id);
            }
            catch(Exception)//create exception for bad id
            {
                throw new NotImplementedException();
            }
        }
        public IEnumerable<Line> GetAllLines()
        {
            return from item in dl.GetAllLines()
                   select LineBoDoAdapter(item);
        }
        public Line GetLine(int id)
        {
            return LineBoDoAdapter(dl.GetLine(id));
        }
        public IEnumerable<Line> GetLinesBy(Predicate<Line> predicate)
        {
            throw new NotImplementedException();
        }
        public void UpdateLine(Line line)
        {
            DO.Line lineDO = new DO.Line();
            line.CopyPropertiesTo(lineDO);
            UpdateLineStations(line);
            dl.UpdateLine(lineDO);
        }
        #endregion

        #region Station

        BO.Station StationBoDoAdapter(DO.Station stationDO)
        {
            BO.Station stationBO = new BO.Station();
            stationDO.CopyPropertiesTo(stationBO);
            stationBO.ListOfLines = from line in GetAllLines()
                                    from linestation in line.ListOfLineStations
                                    where linestation.Station == stationBO.Code
                                    select line;
            return stationBO;
        }
        public void AddStation(Station stationBO)
        {
            DO.Station stationDO = new DO.Station();
            stationBO.CopyPropertiesTo(stationDO);
            dl.AddStation(stationDO);
        }
        public void DeleteStation(int code)
        {
            try
            {
                dl.DeleteStation(code);
            }
            catch (Exception)//create exception for bad id
            {
                throw new NotImplementedException();
            }
        }
        public IEnumerable<Station> GetAllStations()
        {
            return from item in dl.GetAllStations()
                   select StationBoDoAdapter(item);
        }
        
        public Station GetStation(int code)
        {
            return StationBoDoAdapter(dl.GetStation(code));
        }
        public IEnumerable<Station> GetStationsBy()
        {
            throw new NotImplementedException();
        }
        public void UpdateStation(Station station)
        {
            DO.Station stationDO = new DO.Station();
            station.CopyPropertiesTo(stationDO);
            dl.UpdateStation(stationDO);
        }
        #endregion

        #region LineStation
        BO.LineStation LineStationBoDoAdapter(DO.LineStation lineStationDO)
        {
            BO.LineStation lineStationBO = new BO.LineStation();
            lineStationDO.CopyPropertiesTo(lineStationBO);
            return lineStationBO;
        }
        public IEnumerable<BO.Line> GetAllLinesInStation(BO.Station InStation)
        {
            return from line in InStation.ListOfLines
                   select line;
        }
        public IEnumerable<LineStation> GetAllLineStations()
        {
            return from ls in dl.GetAllLineStations()
                   select LineStationBoDoAdapter(ls);
        }
        public void UpdateLineStations(BO.Line line)
        {
            foreach (LineStation ls in line.ListOfLineStations)
                UpdateLineStation(ls);
        }
        void UpdateLineStation(BO.LineStation ls)
        {
            DO.LineStation lsDO = new DO.LineStation();
            ls.CopyPropertiesTo(lsDO);
            dl.UpdateLineStation(lsDO);
        }
        public void AddLineStation(LineStation ls)
        {
            DO.LineStation lsDO = new DO.LineStation();
            ls.CopyPropertiesTo(lsDO);
            dl.AddLineStation(lsDO);
            
        }
        public void DeleteLineStation(int lineID, int station)
        {
            dl.DeleteLineStation(lineID, station);
        }
        #endregion

        #region AdjStations
        double CalcDistance(BO.Station s1, BO.Station s2)
        {
            var g1 = new GeoCoordinate(s1.Latitude, s1.Longitude);
            var g2 = new GeoCoordinate(s2.Latitude, s2.Longitude);
            return g1.GetDistanceTo(g2);
        }
        TimeSpan CalcTime(BO.Station s1, BO.Station s2)
        {
            double distance = CalcDistance(s1, s2);
            int sec = (int)(distance + r.NextDouble() * 0.5 * distance) / 14;  // meter/sec
            return new TimeSpan(0, 0, sec);
        }
        public void AddAdjStations(BO.AdjStations adjBO)
        {
            DO.AdjacentStations adjDO = new DO.AdjacentStations();
            adjBO.CopyPropertiesTo(adjDO);
            dl.AddAdjStations(adjDO);
        }
        #endregion

        #region LineTrip
        BO.LineTrip LineTripBoDoAdapter(DO.LineTrip ltDO)
        {
            BO.LineTrip ltBO = new BO.LineTrip();
            ltDO.CopyPropertiesTo(ltBO);
            return ltBO;
        }
        public IEnumerable<LineTrip> GetLineTrips(Line line)
        {
            return from lt in dl.GetAllLineTrips()
                   where (line.ID == lt.LineID)
                   select LineTripBoDoAdapter(lt);
        }
        public void AddLineTrip(LineTrip lineTripBO)
        {
            
            DO.LineTrip lineTripDO = new DO.LineTrip();
            lineTripBO.CopyPropertiesTo(lineTripDO);
            dl.AddLineTrip(lineTripDO);
        }
        public void DeleteLineTrip(LineTrip lt)
        {
            try
            {
                dl.DeleteLineTrip(lt.LineID, lt.StartAt);
            }
            catch (Exception)//create exception for bad id
            {
                throw new NotImplementedException();
            }
        }
        #endregion
    }
}
