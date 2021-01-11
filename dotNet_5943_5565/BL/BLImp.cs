using System;
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

        BO.Line LineBoDoAdapter(DO.Line lineDO)
        {
            BO.Line lineBO = new BO.Line();
            lineDO.CopyPropertiesTo(lineBO);
            lineBO.ListOfLineStations = from item in dl.GetAllLineStations()
                                        where item.LineID == lineBO.ID
                                        select LineStationBoDoAdapter(item);
            lineBO.ListOfStations = from station in dl.GetAllStations()
                                    from linestat in lineBO.ListOfLineStations
                                    where station.Code == linestat.Station
                                    select StationBoDoAdapter(station);
            lineBO.LastStationName = LineNameConverter(lineBO);
            return lineBO;
        }
        string LineNameConverter(BO.Line line)
        {
            return (from station in line.ListOfStations
                    where line.LastStation == station.Code
                    select station.Name).First();
        }
        public IEnumerable<BO.Station> GetAllStationsNotInLine(BO.Line line)
        {
            return from station in GetAllStations()
                   where line.ListOfStations.ToList().Find(s => s.Code == station.Code) == null
                   select station;
        }
        public IEnumerable<BO.Station> GetAllStationsInLine(BO.Line line)
        {
            return from station in line.ListOfStations
                   select station;
        }
        public void AddStationToLine(BO.Line line, BO.Station toAdd, BO.Station addAfter)
        {
            
            for (int index = 0; index < line.ListOfStations.Count(); index++)
            {
                if (line.ListOfStations.ToList()[index].Code == addAfter.Code)
                {
                    line.ListOfStations.ToList().Add(toAdd);
                    if (line.ListOfStations.ToList()[index + 1] != null)
                    {
                        line.ListOfStations.ToList().Add(toAdd);
                        for (int j = line.ListOfStations.Count()-1; j > index + 1; j--)
                        {
                            BO.Station temp = line.ListOfStations.ToList()[j];
                            line.ListOfStations.ToList()[j] = line.ListOfStations.ToList()[j-1];
                            line.ListOfStations.ToList()[j - 1] = temp;
                        }
                   
                    }
                    UpdateLineStations(line);
                    break;
                }
            }
        }
        public void AddLine(Line line)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
        public IEnumerable<Line> GetLinesBy(Predicate<Line> predicate)
        {
            throw new NotImplementedException();
        }
        public void UpdateLine(Line line)
        {
            DO.Line lineDO = new DO.Line();
            line.CopyPropertiesTo(lineDO);
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
            throw new NotImplementedException();
        }
        public IEnumerable<Station> GetAllStations()
        {
            return from item in dl.GetAllStations()
                   select StationBoDoAdapter(item);
        }
        public Station GetStation(int code)
        {
            throw new NotImplementedException();
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
        public IEnumerable<LineStation> GetAllLineStations()
        {
            return from ls in dl.GetAllLineStations()
                   select LineStationBoDoAdapter(ls);
        }
        public void UpdateLineStations(BO.Line line)
        {

            line.ListOfLineStations = StationsToLineStations(line.ListOfStations, line);
            foreach (LineStation ls in line.ListOfLineStations)
                UpdateLineStation(ls);
        }
        void UpdateLineStation(BO.LineStation ls)
        {
            DO.LineStation lsDO = new DO.LineStation();
            ls.CopyPropertiesTo(lsDO);
            dl.UpdateLineStation(lsDO);
        }
        IEnumerable<LineStation> StationsToLineStations(IEnumerable<Station> stations, Line line)
        {
            IEnumerable<LineStation> toReturn = new List<LineStation>();
            for(int i = 0; i < stations.Count(); i++)
            {
                int prev,next;
                if (i == 0)
                    prev = 0;
                else
                    prev = stations.ToList()[i - 1].Code;
                if (i == stations.Count() - 1)
                    next = 0;
                else
                    next = stations.ToList()[i + 1].Code;
                toReturn.ToList().Add(new LineStation
                {
                    LineID = line.ID,
                    Station = stations.ToList()[i].Code,
                    PrevStation = prev,
                    NextStation = next,
                    LineStationIndex = i
                });
            }
            return toReturn;
        }
        #endregion
    }
}
