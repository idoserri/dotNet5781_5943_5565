using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLAPI;
using DO;
using DS;

namespace DL
{
    sealed class DLObject : IDL
    {
        #region singelton
        static readonly DLObject instance = new DLObject();
        static DLObject() { }// static ctor to ensure instance init is done just before first usage
        DLObject() { } // default => private
        public static DLObject Instance { get => instance; }// The public Instance property to use
        #endregion

        #region Bus
        public Bus GetBus(int liscense)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Bus> GetAllBusses()
        {
            return from bus in DataSource.listBusses
                   select bus.Clone();
        }
        public IEnumerable<Bus> GetAllBussesBy(Predicate<Bus> predicate)
        {
            throw new NotImplementedException();
        }
        public void UpdateBus(Bus bus)
        {
            Bus toRemove = DataSource.listBusses.Find(b => b.LicenseNum == bus.LicenseNum);
            if (toRemove != null)
            {
                DataSource.listBusses.Remove(toRemove);
                DataSource.listBusses.Add(bus.Clone());
            }
            else //create exception for not exists
                throw new NotImplementedException();
        }
        public void UpdateBus(int liscense, Action<Bus> update)
        {
            throw new NotImplementedException();
        }
        public void AddBus(Bus bus)
        {
            if (DataSource.listBusses.FirstOrDefault(b => (bus.LicenseNum == b.LicenseNum)) != null)
                throw new NotImplementedException(); //new exception needed
            DataSource.listBusses.Add(bus);
        }   
        public void DeleteBus(int liscense)
        {
            DO.Bus bus = DataSource.listBusses.Find(b => b.LicenseNum == liscense);
            if (bus != null)
                DataSource.listBusses.Remove(bus);
            else //create bad license exception
                throw new NotImplementedException(); 
        }
        #endregion

        #region Station
        public void AddStation(Station station)
        {
           /* if (DataSource.listStations.FirstOrDefault(b => (station.Code == b.Code)) != null)
               throw new NotImplementedException(); ///new exception needed*/
            DataSource.listStations.Add(station);
        }
        public IEnumerable<Station> GetAllStations()
        {
            return from station in DataSource.listStations
                   select station.Clone();
        }
        public IEnumerable<Station> GetAllStationsBy(Predicate<Station> predicate)
        {
            throw new NotImplementedException();
        }
        public void DeleteStation(int code)
        {
            throw new NotImplementedException();
        }
        public Station GetStation(int code)
        {
            throw new NotImplementedException();
        }
        public void UpdateStation(Station station)
        {
            Station toRemove = DataSource.listStations.Find(b => b.Code == station.Code);
            if (toRemove != null)
            {
                DataSource.listStations.Remove(toRemove);
                DataSource.listStations.Add(station.Clone());
            }
            else //create exception for not exists
                throw new NotImplementedException();
        }
        public void UpdateStation(int code, Action<Station> update)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Line
        public void AddLine(Line line)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Line> GetAllLines()
        {
            return from line in DataSource.listLines
                   select line.Clone(); 
        }
        public IEnumerable<Line> GetAllLinesBy(Predicate<Line> predicate)
        {
            throw new NotImplementedException();
        }
        public void DeleteLine(int id)
        {
            DO.Line line = DataSource.listLines.Find(b => b.ID == id);
            if (line != null)
                DataSource.listLines.Remove(line);
            else //create bad id exception
                throw new NotImplementedException();

        }
        public Line GetLine(int id)
        {
            throw new NotImplementedException();
        }
        public void UpdateLine(Line line)
        {
            Line toRemove = DataSource.listLines.Find(b => b.ID == line.ID);
            if (toRemove != null)
            {
                DataSource.listLines.Remove(toRemove);
                DataSource.listLines.Add(line.Clone());
            }
            else //create exception for not exists
                throw new NotImplementedException();
        }
        public void UpdateLine(int id, Action<Line> update)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region LineStation
        public void AddLineStation(LineStation lineStation)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<LineStation> GetAllLineStations()
        {
            return from linestation in DataSource.listLineStations
                   select linestation;
        }
        public IEnumerable<LineStation> GetAllLineStationsBy(Predicate<LineStation> predicate)
        {
            throw new NotImplementedException();
        }
        public void DeleteLineStation(int lineID, int Station)
        {
            throw new NotImplementedException();
        }
        public LineStation GetLineStation(int lineID, int Station)
        {
            throw new NotImplementedException();
        }
        public void UpdateLineStation(LineStation lineStation)
        {
            LineStation toRemove = DataSource.listLineStations
                .Find(ls => (ls.LineID == lineStation.LineID) && (ls.Station == lineStation.Station));
            if (toRemove != null)
                DataSource.listLineStations.Remove(toRemove);
            DataSource.listLineStations.Add(lineStation.Clone());
        }
        public void UpdateLineStation(int lineID, int station, Action<LineStation> update)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region AdjacentStations
        public void AddAdjStations(AdjacentStations adjacentStations)
        {
            throw new NotImplementedException();
        }
        public void DeleteAdjStations(int station1, int station2)
        {
            throw new NotImplementedException();
        }
        public AdjacentStations GetAdjacentStations(int station1, int station2)
        {
            throw new NotImplementedException();
        }
        public void UpdateAdjStations(AdjacentStations adjacentStations)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<AdjacentStations> GetAllAdjacentStations()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<AdjacentStations> GetAllAdjacentStationsBy(Predicate<AdjacentStations> predicate)
        {
            throw new NotImplementedException();
        }
        public void UpdateAdjStations(int station1, int station2, Action<LineStation> update)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}