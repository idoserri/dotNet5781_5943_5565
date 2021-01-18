using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DLAPI;
using DO;

namespace DL
{
    sealed class DLXML : IDL
    {
        public void AddAdjStations(AdjacentStations adjacentStations)
        {
            throw new NotImplementedException();
        }

        public void AddBus(Bus bus)
        {
            throw new NotImplementedException();
        }

        public void AddLine(Line line)
        {
            throw new NotImplementedException();
        }

        public void AddLineStation(LineStation lineStation)
        {
            throw new NotImplementedException();
        }

        public void AddLineTrip(LineTrip lineTrip)
        {
            throw new NotImplementedException();
        }

        public void AddStation(Station station)
        {
            throw new NotImplementedException();
        }

        public void DeleteAdjStations(int station1, int station2)
        {
            throw new NotImplementedException();
        }

        public void DeleteBus(int license)
        {
            throw new NotImplementedException();
        }

        public void DeleteLine(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteLineStation(int lineID, int station)
        {
            throw new NotImplementedException();
        }

        public void DeleteLineTrip(int lineId, TimeSpan start)
        {
            throw new NotImplementedException();
        }

        public void DeleteStation(int code)
        {
            throw new NotImplementedException();
        }

        public AdjacentStations GetAdjacentStations(int station1, int station2)
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

        public IEnumerable<Bus> GetAllBusses()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bus> GetAllBussesBy(Predicate<Bus> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Line> GetAllLines()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Line> GetAllLinesBy(Predicate<Line> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LineStation> GetAllLineStations()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LineStation> GetAllLineStationsBy(Predicate<LineStation> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LineTrip> GetAllLineTrips()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Station> GetAllStations()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Station> GetAllStationsBy(Predicate<Station> predicate)
        {
            throw new NotImplementedException();
        }

        public Bus GetBus(int license)
        {
            throw new NotImplementedException();
        }

        public Line GetLine(int id)
        {
            throw new NotImplementedException();
        }

        public LineStation GetLineStation(int lineID, int station)
        {
            throw new NotImplementedException();
        }

        public Station GetStation(int code)
        {
            throw new NotImplementedException();
        }

        public void UpdateAdjStations(AdjacentStations adjacentStations)
        {
            throw new NotImplementedException();
        }

        public void UpdateAdjStations(int station1, int station2, Action<LineStation> update)
        {
            throw new NotImplementedException();
        }

        public void UpdateBus(Bus bus)
        {
            throw new NotImplementedException();
        }

        public void UpdateBus(int license, Action<Bus> update)
        {
            throw new NotImplementedException();
        }

        public void UpdateLine(Line line)
        {
            throw new NotImplementedException();
        }

        public void UpdateLine(int id, Action<Line> update)
        {
            throw new NotImplementedException();
        }

        public void UpdateLineStation(LineStation lineStation)
        {
            throw new NotImplementedException();
        }

        public void UpdateLineStation(int lineID, int station, Action<LineStation> update)
        {
            throw new NotImplementedException();
        }

        public void UpdateStation(Station station)
        {
            throw new NotImplementedException();
        }

        public void UpdateStation(int code, Action<Station> update)
        {
            throw new NotImplementedException();
        }
    }
}
