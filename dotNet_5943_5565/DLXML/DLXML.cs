using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
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
        string lineStationsPath = @"LineStationsXML.xml"; //XElement
        string adjStationsPath = @"AdjStationsXML.xml"; //XElement
        string lineTripsPath = @"LineTripsXML.xml"; //XElement

        string bussesPath = @"BussesXML.xml"; //XMLSerializer
        string stationsPath = @"StationsXML.xml"; //XMLSerializer
        string linesPath = @"LinesXML.xml"; //XMLSerializer
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
                             where Int32.Parse(ls.Element("LineID").Value) == lineStation.LineID &&
                             Int32.Parse(ls.Element("Station").Value) == lineStation.Station
                             select ls).FirstOrDefault();

            if (ls1 != null) //already exists exception
                return;
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
                            where Int32.Parse(ls.Element("LineID").Value) == lineStation.LineID &&
                            Int32.Parse(ls.Element("Station").Value) == lineStation.Station
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
            XElement adjStationsRootElem = XMLTools.LoadListFromXMLElement(adjStationsPath);
            XElement adj1 = (from adj in adjStationsRootElem.Elements()
                            where int.Parse(adj.Element("Station1").Value) == adjacentStations.Station1 &&
                            int.Parse(adj.Element("Station1").Value) == adjacentStations.Station2
                            select adj).FirstOrDefault();
            if (adj1 != null) //already exists exception
                throw new NotImplementedException();
            XElement adjElem = new XElement("AdjacentStations",
            new XElement("Station1", adjacentStations.Station1.ToString()),
            new XElement("Station2", adjacentStations.Station2.ToString()),
            new XElement("Distance", adjacentStations.Distance.ToString()),
            new XElement("Time", XmlConvert.ToString(adjacentStations.Time)));
            adjStationsRootElem.Add(adjElem);
            XMLTools.SaveListToXMLElement(adjStationsRootElem, adjStationsPath);
        }
        #endregion

        #region Line Trip
        public void AddLineTrip(LineTrip lineTrip)
        {
            XElement lineTripRootElem = XMLTools.LoadListFromXMLElement(lineTripsPath);
            XElement lt1 = (from lt in lineTripRootElem.Elements()
                             where int.Parse(lt.Element("LineID").Value) == lineTrip.LineID &&
                             XmlConvert.ToTimeSpan(lt.Element("StartAt").Value) == lineTrip.StartAt
                             select lt).FirstOrDefault();
            if (lt1 != null) //already exists exception
                throw new NotImplementedException();
            XElement ltElem = new XElement("LineTrip",
                               new XElement("LineID", lineTrip.LineID.ToString()),
                               new XElement("StartAt", XmlConvert.ToString(lineTrip.StartAt)),
                               new XElement("FinishAt", XmlConvert.ToString(lineTrip.FinishAt)),
                               new XElement("Frequency", XmlConvert.ToString(lineTrip.Frequency)));
            lineTripRootElem.Add(ltElem);
            XMLTools.SaveListToXMLElement(lineTripRootElem, lineTripsPath);
        }
        public void DeleteLineTrip(int lineId, TimeSpan start)
        {
            XElement ltRootElem = XMLTools.LoadListFromXMLElement(lineTripsPath);
            XElement lt1 = (from lt in ltRootElem.Elements()
                            where int.Parse(lt.Element("LineID").Value) == lineId &&
                            XmlConvert.ToTimeSpan(lt.Element("StartAt").Value) == start
                            select lt).FirstOrDefault();
            if (lt1 != null)
            {
                lt1.Remove();
                XMLTools.SaveListToXMLElement(ltRootElem, lineTripsPath);
            }
            else //bad id exception
                throw new NotImplementedException();

        }
        public IEnumerable<LineTrip> GetAllLineTrips()
        {
            XElement ltRootElem = XMLTools.LoadListFromXMLElement(lineTripsPath);

            return (from lt in ltRootElem.Elements()
                    select new LineTrip
                    {
                        LineID = Int32.Parse(lt.Element("LineID").Value),
                        StartAt = XmlConvert.ToTimeSpan(lt.Element("StartAt").Value),
                        FinishAt = XmlConvert.ToTimeSpan(lt.Element("FinishAt").Value),
                        Frequency = XmlConvert.ToTimeSpan(lt.Element("Frequency").Value),
                    });
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
