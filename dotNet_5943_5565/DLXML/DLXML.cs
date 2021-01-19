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
        #region singelton
        static readonly DLXML instance = new DLXML();
        static DLXML() { }// static ctor to ensure instance init is done just before first usage
        DLXML() { } // default => private
        public static DLXML Instance { get => instance; }// The public Instance property to use
        #endregion

        #region DS XML Files
        string bussesPath = @"BussesXML.xml";
        string stationsPath = @"Stations.xml";
        #endregion

        #region Bus
        public void AddBus(Bus bus)
        {
            List<Bus> listBusses = XMLTools.LoadListFromXMLSerializer<Bus>(bussesPath);
            if (listBusses.FirstOrDefault(b => (bus.LicenseNum == b.LicenseNum)) != null)
                throw new NotImplementedException(); //new exception needed
            listBusses.Add(bus);
            XMLTools.SaveListToXMLSerializer(listBusses, bussesPath);
        }
        public void DeleteBus(int license)
        {
            List<Bus> listBusses = XMLTools.LoadListFromXMLSerializer<Bus>(bussesPath);
            DO.Bus bus = listBusses.Find(b => b.LicenseNum == license);
            if (bus != null)
                listBusses.Remove(bus);
            else //create bad license exception
                throw new NotImplementedException();
            XMLTools.SaveListToXMLSerializer(listBusses, bussesPath);
        }
        public IEnumerable<Bus> GetAllBusses()
        {
            List<Bus> listBusses = XMLTools.LoadListFromXMLSerializer<Bus>(bussesPath);
            return from bus in listBusses
                   select bus;
        }
        public IEnumerable<Bus> GetAllBussesBy(Predicate<Bus> predicate)
        {
            throw new NotImplementedException();
        }
        public Bus GetBus(int license)
        {
            throw new NotImplementedException();
        }
        public void UpdateBus(Bus bus)
        {
            List<Bus> listBusses = XMLTools.LoadListFromXMLSerializer<Bus>(bussesPath);
            Bus toRemove = listBusses.Find(b => b.LicenseNum == bus.LicenseNum);
            if (toRemove != null)
            {
                listBusses.Remove(toRemove);
                listBusses.Add(bus);
            }
            else //create exception for not exists
                throw new NotImplementedException();
            XMLTools.SaveListToXMLSerializer(listBusses, bussesPath);
        }
        public void UpdateBus(int license, Action<Bus> update)
        {
            throw new NotImplementedException();
        }
        #endregion
        public void AddAdjStations(AdjacentStations adjacentStations)
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
