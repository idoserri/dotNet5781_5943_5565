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
        
        public Bus(int license_Number=0, DateTime start_Date , int random_Mileage=0, int starting_Fuel_KM=0) 
        {
            if(license_Number > 99999999 )
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
                if (value > 99999999)
                    throw new Exception();
                licenseNumber = value; 
            }
        }
    }
}
