using System;
using System.Collections.Generic;
using System.Configuration;
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
        public Bus(int license_Number, DateTime start_Date, int _Mileage, int starting_Fuel_KM) 
        {
            if(license_Number>99999999 || starting_Fuel_KM>1200)
                throw new Exception();
            licenseNumber = license_Number;
            startDate = start_Date;
            mileage = _Mileage;
            fuelKM = starting_Fuel_KM;
        }

        public DateTime StartDate
        {
            get => startDate;
            private set
            {
                startDate = EnterDate();
            }
        }

        public int Mileage
        {
            get => mileage;
            private set => mileage = value;
        }

        public int FuelKM
        {
            get => fuelKM;
            private set
            {
                if(fuelKM>1200)
                    throw new Exception();
                fuelKM = value;
            }
        }
        
        public int LicenseNumber
        {
            get { return licenseNumber; }
            private set 
            {
                if(value > 99999999)     //because at max there are 8 digits on a bus
                    throw new Exception();
                licenseNumber = value; 
            }
        }
        public DateTime EnterDate() // function to enter a date by year/month/day
        {
            Console.WriteLine("Enter year: ");
            int year = Console.Read();
            Console.WriteLine("Enter month: ");
            int month = Console.Read();
            Console.WriteLine("Enter day: ");
            int day = Console.Read();
            return new DateTime(year,month,day);
        }
        public Bus AddBus()
        {

            Console.WriteLine("enter start date:");
            this.startDate = EnterDate();
            return this;
        }
    }
}
