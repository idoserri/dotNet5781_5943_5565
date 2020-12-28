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
        Bus GetBus(int liscense);
        void UpdateBus(Bus bus);
        void DeleteBus(int liscense);
        #endregion

        #region Station
        void AddStation(Station station);
        Station GetStation(int code);
        void UpdateStation(Station station);
        void DeleteStation(int code);
        #endregion

        #region Line
        void AddLine(Line line);
        Line GetLine(int id);
        void UpdateLine(Line line);
        void DeleteLine(int id);
        #endregion

        #region LineStation
        void AddLineStation(LineStation lineStation);
        LineStation GetLineStation(int lineID, int Station);
        void UpdateLineStation(LineStation lineStation);
        void DeleteLineStation(int lineID, int Station);
        #endregion

        #region AdjacentStations
        void AddAdjStations(AdjacentStations adjacentStations);
        AdjacentStations GetAdjacentStations(int station1, int station2);
        void UpdateAdjStations(AdjacentStations adjacentStations);
        void DeleteAdjStations(int station1, int station2);
        #endregion
    }
}
