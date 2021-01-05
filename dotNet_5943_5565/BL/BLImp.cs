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
            throw new NotImplementedException();
        }
        public IEnumerable<Bus> GetAllBusses()
        {
            throw new NotImplementedException();
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
            return lineBO;
        }
        public void AddLine(Line line)
        {
            throw new NotImplementedException();
        }
        public void DeleteLine(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
    }
}
