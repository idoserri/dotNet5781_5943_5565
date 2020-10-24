using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;



namespace dotNet5781_01_5943_5565
{
    class Program
    {


        static void Main(string[] args)
        {
            List<Bus> busDatabase = new List<Bus>();
            string choice;
            bool menuLoop = true;            //since we want the menu to loop until the user chooses to exit
            while(menuLoop)
            {
                Console.WriteLine(              //show the menu for the user
@"Enter your choice: 
1 - add a buss
2 - Select a Bus to Drive
3 - Fuel or give treatment to the bus
4 - Show the mileage of every single bus
5 - Exit"); 
                choice = Console.ReadLine();//read the user's choice in the menu
                switch(choice)
                {
                    case "1": //EnterBus();
                        Bus a = new Bus(license_Number: 0, start_Date: DateTime.Now, _Mileage: 0, starting_Fuel_KM: 0);
                        a.EnterBus();
                        busDatabase.Add(a);
                        break;
                    case "2": //SelectBusToDrive();
                        break;
                    case "3": //FuelTreatment();
                        break;
                    case "4": //ShowMileage();
                        break;
                    case "5":
                        menuLoop = false;
                        break;
                    default:
                        Console.WriteLine("please enter a number between 1-5");
                        break;
                }
            }
        }

    }
}
