using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace dotNet5781_01_5943_5565
{

    public class Bus
    {
        private int licenseNumber;
        private DateTime startDate;
        private DateTime lastTreatment;
        private int mileageSinceTreatment;
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
        public DateTime EnterDate() // function to enter a date by month/day/year
        {
            Console.WriteLine(@"Enter month/year/day:");    
            string date = Console.ReadLine();
            DateTime dateReturned = new DateTime();         //this is where the result of the parse enters
            DateTime.TryParse(date, out dateReturned);      //checking if it's possible to parse the string and putting the result into our desired date tp return
            return dateReturned;
        }
        public Bus EnterBus()      //the function we use to enter the bus into our database;
        {
            Bus result = new Bus(license_Number: 0, start_Date: DateTime.Now, _Mileage: 0, starting_Fuel_KM: 0); //a bus with default parameters
            Console.WriteLine("enter start date:");
            result.startDate = EnterDate();
            result.lastTreatment = result.startDate;
            result.mileageSinceTreatment = 0;
            if (result.startDate.Year < 2018)
            {
                Console.WriteLine("Enter 7 digits of license number:");
                int ln=Int32.Parse(Console.ReadLine());
                while (ln >= 10000000)
                {
                    Console.WriteLine("ERROR: please Enter 7 digits of license number:");
                    ln = Int32.Parse(Console.ReadLine());
                }   
                
                result.licenseNumber = ln;
            }
            else
            {
                Console.WriteLine("Enter 8 digits of license number:");
                int ln = Int32.Parse(Console.ReadLine());
                while (ln >= 100000000)
                {
                    Console.WriteLine("ERROR: please Enter 8 digits of license number:");
                    ln = Int32.Parse(Console.ReadLine());
                }
                    result.licenseNumber = ln;
            }
            return result;
        }

        public void FuelTreatment()
        {
            Console.WriteLine(              //show the menu for the user
@"Enter treatment kind: 
1 - fuel treatment
2 - regular treatment");
            int choice = Int32.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1: fuelKM = 1200;
                    break;
                case 2:
                    lastTreatment = DateTime.Now; ;
                    break;
                default:
                    Console.WriteLine("ERROR with treatment kind");
                    break;
            }



        }
        public void SelectBusToDrive(List<Bus> busDatabase)
        {
            Console.WriteLine("Enter the bus license number you wish to take the drive");
            int candidateNumber = Int32.Parse(Console.ReadLine());
            Random r = new Random();
            int KM_Ride = r.Next(1, 301);   // choosing random number between 1-300 KM 
            bool flag = false;
            foreach (Bus p in busDatabase)
            {
                // if license number found and there is enough fuel and the bus had treatment in time
                if (p.licenseNumber == candidateNumber && p.fuelKM < KM_Ride &&
                    mileageSinceTreatment+KM_Ride<=20000 && 
                    (DateTime.Now - lastTreatment).TotalDays <= 365)
                {
                    p.Mileage += KM_Ride;
                    p.mileageSinceTreatment += KM_Ride;
                    p.fuelKM -= KM_Ride;
                    flag = true;
                }                
            }
            if (!flag)
                Console.WriteLine("this bus is unable to take the drive");
        }

    }
}
