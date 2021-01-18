using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace DLAPI
{
    public interface IDL
    {

        #region Bus
        void AddBus(Bus bus);
        Bus GetBus(int license);
        IEnumerable<Bus> GetAllBusses();
        IEnumerable<Bus> GetAllBussesBy(Predicate<Bus> predicate);
        void UpdateBus(Bus bus);
        void UpdateBus(int license, Action<Bus> update);
        void DeleteBus(int license);
        #endregion

        #region Station
        void AddStation(Station station);
        Station GetStation(int code);
        IEnumerable<Station> GetAllStations();
        IEnumerable<Station> GetAllStationsBy(Predicate<Station> predicate);
        void UpdateStation(Station station);
        void UpdateStation(int code, Action<Station> update);
        void DeleteStation(int code);
        #endregion

        #region Line
        void AddLine(Line line);
        Line GetLine(int id);
        IEnumerable<Line> GetAllLines();
        IEnumerable<Line> GetAllLinesBy(Predicate<Line> predicate);
        void UpdateLine(Line line);
        void UpdateLine(int id, Action<Line> update);
        void DeleteLine(int id);
        #endregion

        #region LineStation
        void AddLineStation(LineStation lineStation);
        LineStation GetLineStation(int lineID, int station);
        IEnumerable<LineStation> GetAllLineStations();
        IEnumerable<LineStation> GetAllLineStationsBy(Predicate<LineStation> predicate);
        void UpdateLineStation(LineStation lineStation);
        void UpdateLineStation(int lineID, int station, Action<LineStation> update);
        void DeleteLineStation(int lineID, int station);
        #endregion

        #region AdjacentStations
        void AddAdjStations(AdjacentStations adjacentStations);
        AdjacentStations GetAdjacentStations(int station1, int station2);
        IEnumerable<AdjacentStations> GetAllAdjacentStations();
        IEnumerable<AdjacentStations> GetAllAdjacentStationsBy(Predicate<AdjacentStations> predicate);
        void UpdateAdjStations(AdjacentStations adjacentStations);
        void UpdateAdjStations(int station1, int station2, Action<LineStation> update);
        void DeleteAdjStations(int station1, int station2);
        #endregion

        #region LineTrip
        IEnumerable<LineTrip> GetAllLineTrips();
        #endregion
    }
}
