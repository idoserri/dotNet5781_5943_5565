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
            
            busBO.LicenseNum = busDO.LicenseNum;
            busBO.Mileage = busDO.Mileage;
            busBO.FuelRemain = busDO.FuelRemain;
            busBO.FromDate = busDO.FromDate;
            busBO.BusStatus = BusEnumAdapter(busDO.BusStatus);
            return busBO;
        }

        public Status BusEnumAdapter(DO.Status statusDO)
        {
            if (DO.Status.Ready == statusDO)
                return Status.Ready;

            if (DO.Status.Fueling == statusDO)
                return Status.Fueling;

            if (DO.Status.Driving == statusDO)
                return Status.Driving;

            if (DO.Status.Treatment == statusDO)
                return Status.Treatment;

            else 
                return Status.Unavailable;



        }
        public Bus GetBus(int license)
        {
            throw new NotImplementedException();
        }
        public void AddBus(Bus bus)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
        #endregion

        #region Line

        BO.Line lineBoDoAdapter(DO.Line lineDO)
        {
            BO.Line lineBO = new BO.Line();
            lineBO.ID = lineDO.ID;
            lineBO.LastStation = lineDO.LastStation;
            lineBO.LineNum = lineDO.LineNum;
            lineBO.Area = AreasEnumAdapter(lineDO.Area);
            return lineBO;
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
                   select lineBoDoAdapter(item);
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
            throw new NotImplementedException();
        }
        #endregion

        #region Station

        BO.Station StationBoDoAdapter(DO.Station stationDO)
        {
            BO.Station stationBO = new BO.Station();
            stationBO.Name = stationDO.Name;
            stationBO.Longitude = stationDO.Longitude;
            stationBO.Latitude = stationDO.Latitude;
            stationBO.Code = stationDO.Code;
            stationBO.Area = AreasEnumAdapter(stationDO.Area);
            return stationBO;
        }
        public void AddStation(Station station)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
        #endregion

        #region Misc Functions
        public Areas AreasEnumAdapter(DO.Areas areaDO)
        {
            switch (areaDO)
            {
                case DO.Areas.General:
                    return BO.Areas.General;

                case DO.Areas.North:
                    return BO.Areas.North;

                case DO.Areas.South:
                    return BO.Areas.South;

                case DO.Areas.Center:
                    return BO.Areas.Center;

                case DO.Areas.Jerusalem:
                    return BO.Areas.Jerusalem;

                default:
                    return BO.Areas.General;
            }
        }
        #endregion
    }
}
