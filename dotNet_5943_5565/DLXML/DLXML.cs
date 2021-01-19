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
        string lineStationsPath = @"LineStationsXML.xml";

        string bussesPath = @"BussesXML.xml";
        string stationsPath = @"StationsXML.xml";
        string linesPath = @"LinesXML.xml";
        string adjStationsPath = @"AdjStationsXML.xml";
        string lineTripsPath = @"LineTripsXML.xml";
        #endregion

        #region Line Station
        public IEnumerable<LineStation> GetAllLineStations()
        {
            XElement lineStationsRootElem = XMLTools.LoadListFromXMLElement(lineStationsPath);

            return (from p in lineStationsRootElem.Elements()
                    select new LineStation
                    {
                        LineID = Int32.Parse(p.Element("LineID").Value),
                        LineStationIndex = Int32.Parse(p.Element("LineStationIndex").Value),
                        Station = Int32.Parse(p.Element("Station").Value),
                        PrevStation = Int32.Parse(p.Element("PrevStation").Value),
                        NextStation = Int32.Parse(p.Element("NextStation").Value),
                    }); 
        }
        public void AddLineStation(LineStation lineStation)
        {
            XElement lineStationsRootElem = XMLTools.LoadListFromXMLElement(lineStationsPath);

            XElement ls1 = (from ls in lineStationsRootElem.Elements()
                             where int.Parse(ls.Element("LineID").Value) == lineStation.LineID &&
                             int.Parse(ls.Element("Station").Value) == lineStation.Station
                             select ls).FirstOrDefault();

            if (ls1 != null) //already exists exception
                throw new NotImplementedException();
            XElement lsElem = new XElement("LineStation",
                       new XElement("LineID", lineStation.LineID.ToString()),
                       new XElement("LineStationIndex", lineStation.LineStationIndex.ToString()),
                       new XElement("NextStation", lineStation.NextStation.ToString()),
                       new XElement("PrevStation", lineStation.PrevStation.ToString()),
                       new XElement("Station", lineStation.Station.ToString()));

            lineStationsRootElem.Add(lsElem);

            XMLTools.SaveListToXMLElement(lineStationsRootElem, lineStationsPath);
        }
        public void DeleteLineStation(int lineID, int station)
        {
            XElement lineStationsRootElem = XMLTools.LoadListFromXMLElement(lineStationsPath);
            XElement ls1 = (from ls in lineStationsRootElem.Elements()
                            where int.Parse(ls.Element("LineID").Value) == lineID &&
                            int.Parse(ls.Element("Station").Value) == station
                            select ls).FirstOrDefault();
            if (ls1 != null)
            {
                ls1.Remove();
                XMLTools.SaveListToXMLElement(lineStationsRootElem, lineStationsPath);
            }
            else //bad id exception
                throw new NotImplementedException();
        }
        public void UpdateLineStation(LineStation lineStation)
        {
            XElement lineStationsRootElem = XMLTools.LoadListFromXMLElement(lineStationsPath);
            XElement ls1 = (from ls in lineStationsRootElem.Elements()
                            where int.Parse(ls.Element("LineID").Value) == lineStation.LineID &&
                            int.Parse(ls.Element("Station").Value) == lineStation.Station
                            select ls).FirstOrDefault();
            if (ls1 != null)
            {
                ls1.Element("LineID").Value = lineStation.LineID.ToString();
                ls1.Element("Station").Value = lineStation.Station.ToString();
                ls1.Element("LineStationIndex").Value = lineStation.LineStationIndex.ToString();
                ls1.Element("PrevStation").Value = lineStation.PrevStation.ToString();
                ls1.Element("NextStation").Value = lineStation.NextStation.ToString();
                XMLTools.SaveListToXMLElement(lineStationsRootElem, lineStationsPath);
            }
            else //throw bad id exception
                throw new NotImplementedException();
        }
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

        #region Station
        public void AddStation(Station station)
        {
            List<Station> listStations = XMLTools.LoadListFromXMLSerializer<Station>(stationsPath);
            if (listStations.FirstOrDefault(s => (station.Code == s.Code)) != null)
                throw new NotImplementedException(); //new exception needed
            listStations.Add(station);
            XMLTools.SaveListToXMLSerializer(listStations, stationsPath);
        }
        public IEnumerable<Station> GetAllStations()
        {
            List<Station> listStations = XMLTools.LoadListFromXMLSerializer<Station>(stationsPath);
            return from s in listStations
                   select s;
        }
        public void UpdateStation(Station station)
        {
            List<Station> listStations = XMLTools.LoadListFromXMLSerializer<Station>(stationsPath);
            Station toRemove = listStations.Find(s => s.Code == station.Code);
            if (toRemove != null)
            {
                listStations.Remove(toRemove);
                listStations.Add(station);
            }
            else //create exception for not exists
                throw new NotImplementedException();
            XMLTools.SaveListToXMLSerializer(listStations, stationsPath);
        }
        public void DeleteStation(int code)
        {
            List<Station> listStations = XMLTools.LoadListFromXMLSerializer<Station>(stationsPath);
            Station station = listStations.Find(s => s.Code == code);
            if (station != null)
                listStations.Remove(station);
            else //create bad license exception
                throw new NotImplementedException();
            XMLTools.SaveListToXMLSerializer(listStations, stationsPath);
        }
        public Station GetStation(int code)
        {
            List<Station> listStations = XMLTools.LoadListFromXMLSerializer<Station>(stationsPath);
            Station station = listStations.Find(s => s.Code == code);
            if (station != null)
                return station;
            else //throw bad code exception
                throw new NotImplementedException();
        }
        #endregion

        #region Line
        public IEnumerable<Line> GetAllLines()
        {
            List<Line> listLines = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);
            return from l in listLines
                   select l;
        }
        public void AddLine(Line line)
        {
            List<Line> listLines = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);
            if (listLines.FirstOrDefault(l => (line.ID == l.ID)) != null)
                throw new NotImplementedException(); //new exception needed
            listLines.Add(line);
            XMLTools.SaveListToXMLSerializer(listLines, linesPath);
        }
        public void DeleteLine(int id)
        {
            List<Line> listLines = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);
            Line line = listLines.Find(l => l.ID == id);
            if (line != null)
                listLines.Remove(line);
            else //create bad id exception
                throw new NotImplementedException();
            XMLTools.SaveListToXMLSerializer(listLines, linesPath);
        }
        public void UpdateLine(Line line)
        {
            List<Line> listLines = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);

            Line toRemove = listLines.Find(l => l.ID == line.ID);
            if (toRemove != null)
            {
                listLines.Remove(toRemove);
                listLines.Add(line);
            }
            else //create exception for not exists
                throw new NotImplementedException();
            XMLTools.SaveListToXMLSerializer(listLines, linesPath);
        }
        public Line GetLine(int id)
        {
            List<Line> listLines = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);
            Line line = listLines.Find(l => l.ID == id);
            if (line != null)
                return line;
            else //throw bad id excpetion
                throw new NotImplementedException();
        }
        #endregion

        #region Adjacent Stations
        public void AddAdjStations(AdjacentStations adjacentStations)
        {
            List<AdjacentStations> listAdjStations = XMLTools.LoadListFromXMLSerializer<AdjacentStations>(adjStationsPath);
            if (listAdjStations.FirstOrDefault(adj => (adjacentStations.Station1 == adj.Station1) && (adjacentStations.Station2 == adj.Station2)) != null)
                throw new NotImplementedException(); //new exception needed
            listAdjStations.Add(adjacentStations);
            XMLTools.SaveListToXMLSerializer(listAdjStations, adjStationsPath);
        }
        #endregion

        #region Line Trip
        public void AddLineTrip(LineTrip lineTrip)
        {
            List<LineTrip> listLineTrips = XMLTools.LoadListFromXMLSerializer<LineTrip>(lineTripsPath);

            if (listLineTrips
                .FirstOrDefault(b => (lineTrip.StartAt == b.StartAt && lineTrip.FinishAt == b.FinishAt && lineTrip.Frequency == b.Frequency)) != null)
                throw new NotImplementedException(); //new exception needed
            listLineTrips.Add(lineTrip);
            XMLTools.SaveListToXMLSerializer(listLineTrips, lineTripsPath);

        }
        public void DeleteLineTrip(int lineId, TimeSpan start)
        {
            List<LineTrip> listLineTrips = XMLTools.LoadListFromXMLSerializer<LineTrip>(lineTripsPath);

            LineTrip toRemove = listLineTrips.Find(lt => lt.LineID == lineId && lt.StartAt == start);
            if (toRemove != null)
                listLineTrips.Remove(toRemove);
            else //create bad id exception
                throw new NotImplementedException();
            XMLTools.SaveListToXMLSerializer(listLineTrips, lineTripsPath);

        }
        public IEnumerable<LineTrip> GetAllLineTrips()
        {
            List<LineTrip> listLineTrips = XMLTools.LoadListFromXMLSerializer<LineTrip>(lineTripsPath);

            return from lt in listLineTrips
                   select lt;
        }
        #endregion







        public void DeleteAdjStations(int station1, int station2)
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







        public IEnumerable<Line> GetAllLinesBy(Predicate<Line> predicate)
        {
            throw new NotImplementedException();
        }



        public IEnumerable<LineStation> GetAllLineStationsBy(Predicate<LineStation> predicate)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Station> GetAllStationsBy(Predicate<Station> predicate)
        {
            throw new NotImplementedException();
        }





        public LineStation GetLineStation(int lineID, int station)
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


        public void UpdateLine(int id, Action<Line> update)
        {
            throw new NotImplementedException();
        }



        public void UpdateLineStation(int lineID, int station, Action<LineStation> update)
        {
            throw new NotImplementedException();
        }



        public void UpdateStation(int code, Action<Station> update)
        {
            throw new NotImplementedException();
        }
    }
}
