using System;
using System.Collections.Generic;
using System.Linq;
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
            set { location.Latitude = value.Latitude; location.Longitude = value.Longitude; }
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
            double latit = r.Next(-90, 91);
            double longt = r.Next(-180, 181);
            location.Latitude = latit;
            location.Longitude = longt;
        }
    }
}
