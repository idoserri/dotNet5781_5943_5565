using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace dotNet5781_01_5943_5565
{

    public class Bus
    {
        private int licenseNumber;
        private DateTime startDate;
        private int mileage;
        private int fuelKM;
        Bus(int license_Number, DateTime start_Date, int random_Mileage, int starting_Fuel_KM) 
        {
            if(license_Number < 99999999 )
                throw new Exception();
            licenseNumber = license_Number;
            startDate = start_Date;
            mileage = random_Mileage;
            fuelKM = starting_Fuel_KM;
        }

        public DateTime StartDate { get => startDate; }
        
        public int LicenseNumber
        {
            get { return licenseNumber; }
            private set
            { 
                if(value>99999999 || value< 1000000)
                    throw new Exception();
                licenseNumber = value; 
            }
        }
    }
}
