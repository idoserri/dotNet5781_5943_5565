using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
    class BusLine
    {
        private List<BusStationLine> stations;
        private int line;
        private BusStationLine firstStation;
        private BusStationLine lastStation;
        private Areas area;

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
    }
}
