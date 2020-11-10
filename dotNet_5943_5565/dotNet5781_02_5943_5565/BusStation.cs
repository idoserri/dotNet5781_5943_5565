using System;
using System.Collections.Generic;
using System.Linq;
using System.Device.Location;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace dotNet5781_02_5943_5565
{

    class Location
    {
        /// <summary>
        /// this class represent location acccording to latitude and longitude 
        /// for the major class to bus station.
        /// </summary>
        private double latitude;
        private double longitude;


        //properties
        public double Latitude
        {
            get => latitude;
            set => latitude = value;
        }
        public double Longitude
        {
            get => longitude;
            set => longitude = value;
        }

        public Location(double latit, double longt)
        {
            if (latit > 90 || latit < -90 || longt > 180 || longt < -180)
                throw new Exception("location is out of range");

            latitude = latit;
            longitude = longt;
        }
    }


    class BusStation
    {
        
        // class to represent a bus station in the database 
        
        private int code;            // max 6 digit code
        private Location location;  // 2 values to describe location
        private string address;

        public int Code
        {
            get => code;
            set => code = value;
        }

       public Location Location
        {
            get => location;
            set
            {
                if (value.Latitude > 90 || value.Latitude < -90 ||
                    value.Longitude > 180 || value.Longitude < -180)
                    throw new Exception("location is out of range");
                location.Latitude = value.Latitude; location.Longitude = value.Longitude;
            }
        }

        public string Address
        {
            get => address;
            set => address = value;
        }
        // this ctor receives code and address and randomly chooses a location 
        public BusStation(int _code, string _address)
        {
            code = _code;
            address = _address;
            Random r = new Random();
            double latit =  r.NextDouble() * (33.3 - 31) + 31;
            double longt = r.NextDouble() * (35.5 - 34.3) + 34.3; 
            location.Latitude = latit;
            location.Longitude = longt;
        }
        public BusStation(int _code)
        {
            code = _code;
            Random r = new Random();
            double latit = r.NextDouble() * (33.3 - 31) + 31;
            double longt = r.NextDouble() * (35.5 - 34.3) + 34.3;
            location.Latitude = latit;
            location.Longitude = longt;
        }
        public override string ToString()
        {
            return "Bus Station Code: " + code + ", " +
                location.Latitude + "°N " + location.Longitude + "°E\n";
        }

    }

    class BusStationLine : BusStation
    {
        private double distanceFromLastStationKM;
        private TimeSpan timeFromLastStation;
        public BusStationLine(double distance, TimeSpan time, int _code, string _address)
            : base(_code, _address)
        {

            distanceFromLastStationKM = distance;
            timeFromLastStation = time;
        }

        public double DistanceFromLastStationKM
        {
            get => distanceFromLastStationKM;
            set => distanceFromLastStationKM = value;
        }

        public TimeSpan TimeFromLastStation
        {
            get => timeFromLastStation;
            set => timeFromLastStation = value;
        }
    }

    enum Areas { General, North, South, Center, Jerusalem }
    class BusLine : IComparable
    {
        private List<BusStationLine> stations;
        private int line;
        private BusStationLine firstStation;
        private BusStationLine lastStation;
        private Areas area;
        private bool existsTwice = false;  //for the bus collection add
        
        public bool ExistsTwice
        {
            get => existsTwice;
            set => existsTwice = value;
        }
        public int Line
        {
            get => line;
            private set => line = value;
        }

        public BusStationLine FirstStation
        {
            get => firstStation;
            private set => firstStation = value;
        }

        public BusStationLine LastStation
        {
            get => lastStation;
            private set => lastStation = value;
        }

        public List<BusStationLine> Stations
        {
            get => stations;
            private set => stations = value;
        }
        public BusLine(List<BusStationLine> course, int number, BusStationLine FStation, BusStationLine LStation,Areas a)
        {
            area = a;
            stations = course;
            line = number;
            firstStation = FStation;
            lastStation = LStation;

            if (stations.Last<BusStationLine>() != LStation)
                stations.Add(LStation);
            if (stations.First<BusStationLine>() != FStation)
            {
                stations.Reverse();
                stations.Add(FStation);
                stations.Reverse();
            }
        }
        public override string ToString()
        {
            string str = "line: " + line.ToString() + "\n" + "area: " + area + "\n" + "stations: ";
            foreach (BusStationLine item in stations)
                str += item.Code.ToString()+ " ";
            return str + "\n";
        }
        public void AddStation(int index, BusStationLine toAdd)
        {
            Stack<BusStationLine> s = new Stack<BusStationLine>(); //temporary stack
            while(index < stations.Count) //while the items left are still there
            {
                //s.push(stations.pop)
                s.Push(stations[stations.Count]);   
                stations.RemoveAt(stations.Count);
            }
            stations.Add(toAdd);    //add the desired line
            while (s.Count!=0)      //while the stack isnt empty, add back the items we removed from the list
                stations.Add(s.Pop());
        }

        public void RemoveStation(BusStationLine toRemove)
        {
            if (!CheckStationExists(toRemove))
                throw new Exception("ERROR: station doesn't exist\n");
            stations.Remove(toRemove);
        }
        
        public bool CheckStationExists(BusStationLine blurb)
        {
            foreach (BusStationLine item in stations)
                if (item == blurb)
                    return true;
            return false;
        }

        public double GetDistance(BusStationLine a, BusStationLine b)
        {
            var sCoord = new GeoCoordinate(a.Location.Latitude, a.Location.Longitude);
            var eCoord = new GeoCoordinate(b.Location.Latitude, b.Location.Latitude);

            return sCoord.GetDistanceTo(eCoord);
        }

        public BusLine GetSubLine(BusStationLine a, BusStationLine b)
        {
            //a is before b
            BusLine toReturn = new BusLine(stations,line,firstStation,lastStation,area);
            if (!CheckStationExists(a) || !CheckStationExists(b))
                throw new Exception("ERROR: station doesn't exist\n");
            while (toReturn.stations[0] != a)
                toReturn.RemoveStation(stations[0]);
            while (toReturn.stations[toReturn.stations.Count] != b)
                toReturn.RemoveStation(stations[toReturn.stations.Count]);
            return toReturn;
        }

        public TimeSpan GetTotalRideTime()
        {
            TimeSpan toReturn = new TimeSpan();
            foreach (BusStationLine item in stations)
                toReturn += item.TimeFromLastStation;
            return toReturn;
        }

        public int CompareTo(object obj)
        {
            return GetTotalRideTime().CompareTo(((BusLine)obj).GetTotalRideTime());
        }
    }

    class BusLineCollection : IEnumerable
    {
        private List<BusLine> lines;
        public BusLineCollection()
        {
            lines = new List<BusLine>();
        }
        public bool CheckLineExists(BusLine toCheck)
        {
            foreach (BusLine item in lines)
                if (item.Line == toCheck.Line)
                    return true;
            return false;
        }
        public IEnumerator GetEnumerator()
        {
            return lines.GetEnumerator();
        }

        public BusLine FindBusLine(BusLine toFind)
        {
            foreach (BusLine item in lines)
                if (item.Line == toFind.Line)
                    return item;
            throw new Exception("ERROR: Bus Doesn't exist in the collection\n");
        }
        public void AddBusLine(BusLine toAdd)
        {
            if (CheckLineExists(toAdd))
            {
                BusLine temp = FindBusLine(toAdd);
                if (temp.FirstStation == toAdd.LastStation
                    && temp.LastStation == toAdd.FirstStation && !temp.ExistsTwice)
                {
                    temp.ExistsTwice = true;
                    toAdd.ExistsTwice = true;
                    lines.Add(toAdd);
                }
                else
                    throw new Exception("ERROR: Bus already exists in the Collection\n");
            }
            else
                lines.Add(toAdd);
        }
        public void RemoveBusLine(BusLine toRemove)
        {
            if (!CheckLineExists(toRemove))
                throw new Exception("ERROR: Bus doesn't exist in the collection\n");
            while(CheckLineExists(toRemove))
                lines.Remove(FindBusLine(toRemove));
        }
        public List<BusLine> GetLinesInStation(int code)
        {
            List<BusLine> toReturn = new List<BusLine>();
            foreach(BusLine item in lines)
            {
                foreach(BusStationLine station in item.Stations)
                {
                    if(station.Code == code)
                    {
                        toReturn.Add(item);
                        break;
                    }
                }
            }
            if (toReturn.Count == 0)
                throw new Exception("ERROR: station doesn't have any lines going through it");
            return toReturn;
        }
        public List<BusLine> SortBusList()
        {
            lines.Sort();
            return lines;
        }

        public BusLine this[int i]
        {
            get => lines[i];
            set => lines[i] = value;
        }

    }
}