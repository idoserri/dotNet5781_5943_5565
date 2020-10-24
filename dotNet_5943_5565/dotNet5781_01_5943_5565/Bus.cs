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
            Console.WriteLine(@"Enter month/year/day");
            string date = Console.ReadLine();
            DateTime dateReturned = new DateTime();
            DateTime.TryParse(date, out dateReturned);
            return dateReturned;
        }
        public Bus EnterBus()      //the function we use to enter the bus into our database;
        {
            Bus toReturn = new Bus(license_Number: 0, start_Date: DateTime.Now, _Mileage: 0, starting_Fuel_KM: 0);
            Console.WriteLine("enter start date:");
            toReturn.startDate = EnterDate();
            if(toReturn.startDate.Year<2018)
            {
                Console.WriteLine("Enter 7 digits of license number:");
                int ln = Console.Read();
                if(ln>=10000000)
                    throw new Exception();
                toReturn.licenseNumber = ln;
            }
            else
            {
                Console.WriteLine("Enter 8 digits of license number:");
                int ln = Console.Read();
                if(ln>=100000000)
                    throw new Exception();
                toReturn.licenseNumber = ln;
            }
            return toReturn;
        }

    }
}
