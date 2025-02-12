﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace dotNet5781_03B_5943_5565
{
    public enum State
    { Ready, Driving, Fueling, Treatment, Unavailable}
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
        private DateTime stateTimer;
        private string untilReady;

        public Bus() { }
        public int MileageSinceTreatment
        {
            get => mileageSinceTreatment;
            set => mileageSinceTreatment = value;
        }
        public DateTime StateTimer
        {
            get { return stateTimer; }
            set { stateTimer = value; }
        }
        public DateTime LastTreatment
        {
            get => lastTreatment;
            set => lastTreatment = value;
        }

        public State State{get=>state;
            set=>state=value;}

        public Bus(int license_Number, DateTime start_Date, int _Mileage,
            int starting_Fuel_KM, DateTime _lastTreatment, int _mileageSinceTreatment, State _state = State.Ready)
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
            if (!this.checkTime() || this.mileageSinceTreatment > 20000 || fuelKM <= 0)
                state = State.Unavailable;

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
        public string UntilReady
        {
            get { return untilReady; }
            set { untilReady = value; }
        }

        public string LicenseNumber
        {
            get 
            {
                if (this.StartDate.Year >= 2018)
                {
                    int[] arr = new int[8];
                    int num = this.licenseNumber;
                    for (int i = 7; i >= 0; i--)
                    {
                        arr[i] = num % 10;
                        num /= 10;
                    }
                    return String.Format("{0}{1}{2}-{3}{4}-{5}{6}{7}",
                        arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6], arr[7]);
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
                    return String.Format("{0}{1}-{2}{3}{4}-{5}{6}",
                        arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);
                }
            }
            set
            {
                if (Int32.Parse(value) > 99999999)     //because at max there are 8 digits on a bus
                    throw new Exception();
                licenseNumber = Int32.Parse(value);
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
        /*public override string ToString()
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
                string _mileage = this.mileageSinceTreatment.ToString();
                int temp = this.mileageSinceTreatment;
                while (temp < 100000 && temp != 0)
                {
                    _mileage = "0" + mileage;
                    temp *= 10;
                }
                if (temp == 0)
                    _mileage = "00000";
                toReturn = arr[0] + "" + arr[1] + "" + arr[2] + "-" + arr[3] + "" + arr[4] + "-" + arr[5] + "" + arr[6] + "" + arr[7];
                toReturn = String.Format("{0,-20}{1,-10}  {2,-10}",toReturn, _mileage, state);
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
                string _mileage = this.mileageSinceTreatment.ToString();
                int temp = this.mileageSinceTreatment;
                while (temp < 10000)
                {
                    _mileage = "0" + mileage;
                    temp *= 10;
                }
                toReturn = arr[0] + "" + arr[1] + "-" + arr[2] + "" + arr[3] + "" + arr[4] + "-" + arr[5] + "" + arr[6] +" ";
                toReturn = String.Format("{0,-20} {1,-10}  {2,-10}", toReturn, _mileage, state);
            }
            
            return toReturn;
        }*/
        public void timeUntillReady(DateTime now)
        {
            int seconds;
            int minutes = 0;
            int totalseconds = (int)(now - stateTimer).TotalSeconds * -1;
            if (totalseconds < 0)
            {
                seconds = 0;
            }
            else
            {
                minutes = totalseconds / 60;
                seconds = totalseconds % 60;
            }
            if (seconds > 9)
            {

                untilReady = String.Format("{0}:{1}", minutes, seconds);
            }
            else
            {
                untilReady = String.Format("{0}:0{1}", minutes, seconds);
            }
        }
      
        public void updateState(DateTime userTime)
        {
            if (checkTime() == false || mileageSinceTreatment > 20000)
            {
                changeState(State.Unavailable);
            }
            else
            {
                if ((userTime - StateTimer).TotalSeconds > 0)
                    changeState(State.Ready);
            }
        }
        public void changeState(State newState, int distance)
        {
            state = State.Driving;
            StateTimer = DateTime.Now.AddSeconds((distance / r.Next(20, 50)) * 6);
        }
        public void changeState(State newState)
        {
            switch (newState)
            {
                case State.Ready:
                    state = State.Ready;
                    break;
                case State.Fueling:
                    state = State.Fueling;
                    StateTimer = DateTime.Now.AddSeconds(12);
                    break;
                case State.Treatment:
                    state = State.Treatment;
                    StateTimer = DateTime.Now;
                    StateTimer = DateTime.Now.AddSeconds(144);
                    break;
                case State.Unavailable:
                    state = State.Unavailable;
                    break;
                default:
                    break;
            }
        }
        public bool checkTime()
        {
            return DateTime.Now.AddDays(-365) < lastTreatment;
        }
        public bool checkDistance(int newDistance)
        {
            return (newDistance + mileageSinceTreatment) < 20000;
            
        }
        public void addDistance(int newDistance)
        {
            mileageSinceTreatment += newDistance;
            mileage += newDistance;
            fuelKM -= newDistance;
        }
    }
}
