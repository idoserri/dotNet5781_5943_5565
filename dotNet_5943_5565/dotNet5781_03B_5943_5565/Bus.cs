using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace dotNet5781_03B_5943_5565
{
    public enum State
    { ready, driving, fueling, treatment }
    public class Bus
    {
        private int licenseNumber;
        private DateTime startDate;
        private DateTime lastTreatment;
        private int mileageSinceTreatment;
        private int mileage;
        private int fuelKM;
        private State state;
        public static Random r = new Random(DateTime.Now.Millisecond);

        public Bus() { }
        public int MileageSinceTreatment
        {
            get => mileageSinceTreatment;
            set => mileageSinceTreatment = value;
        }
        public DateTime LastTreatment
        {
            get => lastTreatment;
            set => lastTreatment = value;
        }

        public Bus(int license_Number, DateTime start_Date, int _Mileage,
            int starting_Fuel_KM, DateTime _lastTreatment, int _mileageSinceTreatment, State _state = State.ready)
        {
            if (license_Number > 99999999 || starting_Fuel_KM > 1200)
                throw new Exception();
            licenseNumber = license_Number;
            startDate = start_Date;
            mileage = _Mileage;
            fuelKM = starting_Fuel_KM;
            lastTreatment = _lastTreatment;
            mileageSinceTreatment = _mileageSinceTreatment;
            state = _state;
        }

        public DateTime StartDate
        {
            get => startDate;
            set => startDate = value;
        }

        public int Mileage
        {
            get => mileage;
            set => mileage = value;
        }

        public int FuelKM
        {
            get => fuelKM;
            set => fuelKM = value;

        }

        public int LicenseNumber
        {
            get { return licenseNumber; }
            set
            {
                if (value > 99999999)     //because at max there are 8 digits on a bus
                    throw new Exception();
                licenseNumber = value;
            }
        }
        public static DateTime EnterDate() // function to enter a date by month/day/year
        {
            Console.WriteLine("Enter month/day/year:");
            string date = Console.ReadLine();
            DateTime dateReturned = new DateTime();         //this is where the result of the parse enters
            DateTime.TryParse(date, out dateReturned);      //checking if it's possible to parse the string and putting the result into our desired date tp return
            return dateReturned;
        }
        /*  public static Bus EnterBus()      //the function we use to enter the bus into our database;
          {
              Bus result = new Bus(license_Number: 0, start_Date: DateTime.Now, _Mileage: 0, starting_Fuel_KM: 1200); //a bus with default parameters
              Console.WriteLine("enter start date:");
              result.startDate = EnterDate();
              result.lastTreatment = DateTime.Now;
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
        */
        public static void FuelTreatment(List<Bus> Database)
        {
            Console.WriteLine("Enter the bus license number you wish to treat");
            int candidateNumber = Int32.Parse(Console.ReadLine()); // turning string read from user into int

            Console.WriteLine(               //show the menu for the user
@"Enter treatment kind: 
1 - fuel treatment
2 - regular treatment");
            int choice = Int32.Parse(Console.ReadLine()); // turning string read from user into int

            bool exist = false;             // variable to check if bus exists
            foreach (Bus p in Database)
            {
                if (p.licenseNumber == candidateNumber)
                {
                    switch (choice)
                    {
                        case 1: // set fuel field and confirm the bus exists in the database
                            p.fuelKM = 1200;
                            exist = true;
                            break;

                        case 2: // set last treatment date and mileage since last treatment 
                                // and confirm the bus exists in the database
                            p.lastTreatment = DateTime.Now;
                            p.mileageSinceTreatment = 0;
                            exist = true;
                            break;

                        default:
                            Console.WriteLine("ERROR with treatment kind");
                            break;
                    }
                }
            }
            if (!exist)
                Console.WriteLine("ERROR - bus does not exist");
        }

        public void SelectBusToDrive(List<Bus> busDatabase)
        {
            Console.WriteLine("Enter the bus license number you wish to take the drive");
            int candidateNumber = Int32.Parse(Console.ReadLine()); // turning string read from user into int


            int KM_Ride = r.Next(1, 1201);   // choosing random number between 1-1200 KM 
            bool flag = false;
            foreach (Bus p in busDatabase)
            {
                // if license number found and there is enough fuel and the bus had treatment in time
                if (p.licenseNumber == candidateNumber && p.fuelKM >= KM_Ride &&
                    mileageSinceTreatment + KM_Ride <= 20000 &&
                    (DateTime.Now - p.lastTreatment).TotalDays <= 365)
                {  // set mileage and fuel tank and confirm the bus is able to take the ride
                    p.Mileage += KM_Ride;
                    p.mileageSinceTreatment += KM_Ride;
                    p.fuelKM -= KM_Ride;
                    flag = true;
                }
            }
            if (!flag)
                Console.WriteLine("this bus is unable to take the drive");
        }
        public static void ShowMileage(List<Bus> busDatabase)
        {
            foreach (Bus p in busDatabase)
            {


                if (p.StartDate.Year >= 2018)
                {
                    int[] arr = new int[8];
                    int num = p.licenseNumber;
                    for (int i = 7; i >= 0; i--)
                    {
                        arr[i] = num % 10;
                        num /= 10;
                    }
                    Console.WriteLine("{0}{1}{2}-{3}{4}-{5}{6}{7}   {8}",
                        arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6], arr[7], p.mileageSinceTreatment);
                }
                else
                {
                    int[] arr = new int[7];
                    int num = p.licenseNumber;
                    for (int i = 6; i >= 0; i--)
                    {
                        arr[i] = num % 10;
                        num /= 10;
                    }
                    Console.WriteLine("{0}{1}-{2}{3}{4}-{5}{6}    {7}",
                        arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6], p.mileageSinceTreatment);
                }
            }
        }
        public override string ToString()
        {
            string toReturn;
            if (this.StartDate.Year >= 2018)
            {
                int[] arr = new int[8];
                int num = this.licenseNumber;
                for (int i = 7; i >= 0; i--)
                {
                    arr[i] = num % 10;
                    num /= 10;
                }
                toReturn = arr[0] + "" + arr[1] + "" + arr[2] + "-" + arr[3] + "" + arr[4] + "-" + arr[5] + "" + arr[6] + "" + arr[7];
                toReturn += "           " + this.MileageSinceTreatment;
            }
            else
            {
                int[] arr = new int[7];
                int num = this.licenseNumber;
                for (int i = 6; i >= 0; i--)
                {
                    arr[i] = num % 10;
                    num /= 10;
                }
                toReturn = arr[0] + "" + arr[1] + "-" + arr[2] + "" + arr[3] + "" + arr[4] + "-" + arr[5] + "" + arr[6];
                toReturn += "             " + this.MileageSinceTreatment;
            }
            
            return toReturn;
        }
    }
}
