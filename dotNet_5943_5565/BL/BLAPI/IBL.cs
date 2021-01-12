﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace BLAPI
{
    public interface IBL
    {
        #region Bus
        Bus GetBus(int license);
        IEnumerable<Bus> GetAllBusses();
        IEnumerable<Bus> GetBussesBy(Predicate<Bus> predicate);
        void AddBus(Bus bus);
        void UpdateBus(Bus bus);
        void DeleteBus(int license);
        #endregion

        #region Line
        Line GetLine(int id);
        IEnumerable<Line> GetAllLines();
        IEnumerable<Line> GetAllLinesInStation(BO.Station line);
        IEnumerable<Line> GetLinesBy(Predicate<Line> predicate);
        IEnumerable<BO.Station> GetAllStationsNotInLine(BO.Line line);
        IEnumerable<BO.Station> GetAllStationsInLine(BO.Line line);
        void AddStationToLine(BO.Line line, BO.Station toAdd, BO.Station addAfter);
        void AddLine(Line line);
        void UpdateLine(Line line);
        void DeleteLine(int id);
        #endregion

        #region Station
        Station GetStation(int code);
        IEnumerable<Station> GetAllStations();
        IEnumerable<Station> GetStationsBy();
        void AddStation(Station station);
        void UpdateStation(Station station);
        void DeleteStation(int code);
        #endregion

        #region LineStation
        IEnumerable<LineStation> GetAllLineStations();
        void AddLineStation(LineStation ls);
        void UpdateLineStations(Line line);
        #endregion

        #region AdjStations
        void AddAdjStations(BO.AdjStations adj);
        #endregion
    }
}
