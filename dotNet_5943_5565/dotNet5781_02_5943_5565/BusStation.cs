using System;
using System.Collections.Generic;
using System.Linq;
using System.Device.Location;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.InteropServices;

namespace dotNet5781_02_5943_5565
{
    class BusStation
    {
        
        // class to represent a bus station in the database 
        
        private int code;            // max 6 digit code
        private GeoCoordinate location;  // 2 values to describe location
        private string address;         

        public int Code
        {
            get => code;
            set => code = value;
        }

       public GeoCoordinate Location
        {
            get => location;
            set
            {
                if (value.Latitude > 90 || value.Latitude < -90 ||
                    value.Longitude > 180 || value.Longitude < -180)
                    throw new Exception("location is out of range");
                location.Latitude = value.Latitude; 
                location.Longitude = value.Longitude;
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
            double latit =  r.NextDouble() * (33.3 - 31) + 31; //random double between 31-33.3
            double longt = r.NextDouble() * (35.5 - 34.3) + 34.3; //random double between 34.3-35.5
            location = new GeoCoordinate(latit, longt);
        }
        //CTOR for a bus station that recieves just a station code
        public BusStation(int _code)
        {
            code = _code;
            Random r = new Random();
            double latit = r.NextDouble() * (33.3 - 31) + 31; //random double between 31-33.3
            double longt = r.NextDouble() * (35.5 - 34.3) + 34.3;//random double between 34.3-35.5
            location = new GeoCoordinate(latit, longt);
        }
        //function to print a station;
        public override string ToString() 
        {
            return "Bus Station Code: " + code + ", " +
                location.Latitude + "°N " + location.Longitude + "°E";
        }

    }

    class BusStationLine : BusStation
    {
        //CTOR that recieves code and address
        public BusStationLine(int _code, string _address)
            :base(_code,_address) {}

        //CTOR that recieves code
        public BusStationLine(int _code)
            :base(_code){}
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
        
        public bool ExistsTwice  //if theres a bus that's the reverse of the other = true
        {
            get => existsTwice;
            set => existsTwice = value;
        }
        public int Line
        {
            get => line;
            set => line = value;
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

        //ctor that receives list of stations, line number, firststation,laststation and area enum
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
                stations.Reverse(); //reverse to add to the end of the list
                stations.Add(FStation);
                stations.Reverse(); //reverse again so first station is at the top
            }
        }

        //CTOR that receives list and line number
        public BusLine(List<BusStationLine> course, int number)
        {
            area = Areas.General;
            stations = course;
            line = number;
            if (stations.Count != 0)
            {
                firstStation = stations[0];
                lastStation = stations[stations.Count - 1];
            }
        }

        //function to print the line and it's stations
        public override string ToString()
        {
            string str = "line: " + line.ToString() + "\n" +  "stations: ";
            foreach (BusStationLine item in stations) //append to the string the busses stations codes
                str += item.Code.ToString()+ " ";
            return str + "\n";
        }

        //function to add a station  to the bus line
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
            if (stations[0] != firstStation) //to change the first station
                firstStation = stations[0];
            if (stations[stations.Count - 1] != lastStation) //to change the last station
                lastStation = stations[stations.Count - 1];
        }

        //function to remoce a station from a bus line
        public void RemoveStation(BusStationLine toRemove)
        {
            if (!CheckStationExists(toRemove))  //if doesn't exist- throw exception
                throw new Exception("ERROR: station doesn't exist\n");
            stations.Remove(toRemove); //remove from the stations list
            if (stations[0] != firstStation)
                firstStation = stations[0];  //fix the first station
            if (stations[stations.Count - 1] != lastStation)
                lastStation = stations[stations.Count - 1]; //fix the last station
        }

        //funtion remove station by its code- basically same as the other one
        public void RemoveStation(int code)
        {
            if (!CheckStationExists(FindStation(code))) //if doesn't exist- throw exception
                throw new Exception("ERROR: station doesn't exist\n");
            BusStationLine toRemove = FindStation(code); 
            stations.Remove(toRemove);   //remove from stations list
            if (stations[0] != firstStation)
                firstStation = stations[0];  //fix the first station
            if (stations[stations.Count - 1] != lastStation)
                lastStation = stations[stations.Count - 1];  //fix the last station
        }

        //helper function to check if a station exists in a bus line
        public bool CheckStationExists(BusStationLine blurb)
        {
            foreach (BusStationLine item in stations) //if exists in the list- return true
                if (item.Code == blurb.Code)
                    return true;
            return false; //else- return false
        }

        //helper function that receives a station code and returns the station if its in the list
        public BusStationLine FindStation(int code)
        {
            foreach (BusStationLine item in stations) //if exists- return it
                if (item.Code == code)
                    return item;
            throw new Exception("ERROR: Station doesn't exist"); //else - throw exception
        }

        //funcition the recieves 2 stations and returns a sub line with those 2 stations as the first and last ones
        public BusLine GetSubLine(BusStationLine a, BusStationLine b)
        { 
            BusLine toReturn = new BusLine(new List<BusStationLine>(stations),line,firstStation,lastStation,area);
            if (!CheckStationExists(a) || !CheckStationExists(b)) //if either don't exist- throw exceptions
                throw new Exception("ERROR: station doesn't exist\n");
            int indexa = 0, indexb = 0; //to see which is ahead in the list
            while (toReturn.Stations[indexa] != a)
                indexa++;
            while (toReturn.Stations[indexb] != b)
                indexb++;
            if (indexa <= indexb) //case a is before b
            {
                while (toReturn.stations[0] != a)
                    toReturn.RemoveStation(toReturn.stations[0]);
                while (toReturn.stations[toReturn.stations.Count - 1] != b)
                    toReturn.RemoveStation(toReturn.stations[toReturn.stations.Count - 1]);
            }
            else//case b is before a
            {
                while (toReturn.stations[0] != b)
                    toReturn.RemoveStation(toReturn.stations[0]);
                while (toReturn.stations[toReturn.stations.Count - 1] != a)
                    toReturn.RemoveStation(toReturn.stations[toReturn.stations.Count - 1]);
            }
            return toReturn;
        }
        //function retrns total ride time of a bus in hours
        public double GetTotalRideTime()
        {
            double toReturn = 0;
            for (int i = 0; i < stations.Count-1; i++)
                toReturn += (GetDistance(stations[i], stations[i + 1])/60000); //avg speed of a bus 60 km/h
            return toReturn;
        }

        //function to implement the IComparable interface
        public int CompareTo(object obj)
        {
            return GetTotalRideTime().CompareTo(((BusLine)obj).GetTotalRideTime());
        }

        //function to calculate the distance between 2 stations
        public double GetDistance(BusStationLine a, BusStationLine b)
        {
            var sCoord = new GeoCoordinate(a.Location.Latitude, a.Location.Longitude); 
            var eCoord = new GeoCoordinate(b.Location.Latitude, b.Location.Latitude);

            return sCoord.GetDistanceTo(eCoord); //calculate distance using System.Device.Location
        }
    }

    class BusLineCollection : IEnumerable
    {
        private List<BusLine> lines;
        private int count = 0;
        
        public int Count
        {
            get => count;
            private set => count = value;
        }
        public BusLineCollection()
        {
            lines = new List<BusLine>();
        }
        public bool CheckLineExists(BusLine toCheck)
        {
            foreach (BusLine item in lines) // check if line exists in the list of line
                if (item.Line == toCheck.Line)
                    return true;
            return false;
        }
        public IEnumerator GetEnumerator() // returns enumerator 
        {
            return lines.GetEnumerator();
        }

        public BusLine FindBusLine(BusLine toFind)
        {
            foreach (BusLine item in lines) // check every line and return the match
                if (item.Line == toFind.Line)
                    return item;
            throw new Exception("ERROR: Bus Doesn't exist in the collection\n");
        }
        public void AddBusLine(BusLine toAdd)
        {
            if (CheckLineExists(toAdd)) // if item to add already exist 
            {
                BusLine temp = FindBusLine(toAdd);
                if (temp.FirstStation == toAdd.LastStation //check if the item to add exists in the opposite direction
                    && temp.LastStation == toAdd.FirstStation && !temp.ExistsTwice)
                {
                    // add and update ExistsTwice fields in both of the bus lines
                    temp.ExistsTwice = true;
                    toAdd.ExistsTwice = true;
                    lines.Add(toAdd);
                }
                else // bus exist but doesn't match the item to add
                    throw new Exception("ERROR: Bus already exists in the Collection\n");
            }
            else // bus doesn't exist so add new bus
                lines.Add(toAdd);
            count++; //update amount of lines
        }
        public void RemoveBusLine(BusLine toRemove)
        {
            if (!CheckLineExists(toRemove)) // Check if line exists
                throw new Exception("ERROR: Bus doesn't exist in the collection\n");

            while (CheckLineExists(toRemove)) // while the list contains the line to delete
            {
                lines.Remove(FindBusLine(toRemove)); //remove first occurrence 
                count--;        // set count of lines list 
            }
        }
        public List<BusLine> GetLinesInStation(int code)
        {
            List<BusLine> toReturn = new List<BusLine>();
            foreach(BusLine item in lines)
            {
                foreach(BusStationLine station in item.Stations)
                {
                    if(station.Code == code) //search in every list of station in every bus line the item
                    {
                        toReturn.Add(item); // adds bus line if matches the code
                        break;      // no further search in this list because we already find the item
                    }
                }
            }
            if (toReturn.Count == 0)  // if we didn't find at all throw exeption
                throw new Exception("ERROR: station doesn't have any lines going through it");
            return toReturn;
        }
        public List<BusLine> SortBusList() // function to sort the bus list
        {
            lines.Sort();
            return lines;
        }

        // properties
        public BusLine this[int i]
        {
            get => lines[i];
            set => lines[i] = value;
        }

    }
}