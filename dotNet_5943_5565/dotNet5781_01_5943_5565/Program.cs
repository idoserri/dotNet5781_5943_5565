﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// assumptions :
/// drive in one ride can be between 1-1200 KM (full tank)
/// </summary>
namespace dotNet5781_01_5943_5565
{
    class Program
    {


        static void Main(string[] args)
        {
            List<Bus> busDatabase = new List<Bus>();   //our list of busses in our database
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
                            Bus a = new Bus(license_Number: 0, start_Date: DateTime.Now,
                                _Mileage: 0, starting_Fuel_KM: 1200);    //set a new bus with default parameters
                            a = a.EnterBus();         //enter the start date and the license number of the new bus
                            busDatabase.Add(a);   //add the new bus to our database                                           
                        break;

                    case "2": //SelectBusToDrive();
                        Bus b = new Bus(license_Number: 0, start_Date: DateTime.Now,
                                _Mileage: 0, starting_Fuel_KM: 1200); //set a new bus with default parameters to access function in class
                        b.SelectBusToDrive(busDatabase); //if the bus is able to take the ride then it's going to have a random drive between 1-1200 KM
                        break;

                    case "3": //FuelTreatment();
                        Bus c = new Bus(license_Number: 0, start_Date: DateTime.Now,
                          _Mileage: 0, starting_Fuel_KM: 1200);//set a new bus with default parameters to access the function
                        c.FuelTreatment(busDatabase);     //gives the user the choice to either fuel or treat the bus                   
                        break;

                    case "4": //ShowMileage();
                        Bus d = new Bus(license_Number: 0, start_Date: DateTime.Now,
                                _Mileage: 0, starting_Fuel_KM: 1200); 
                        d.ShowMileage(busDatabase); //show the license number and the mileage since treatment of every bus in the database
                        break;

                    case "5":
                        menuLoop = false;    //user chose exit that's why we're ending the loop
                        break;
                    default:
                        Console.WriteLine("please enter a number between 1-5");   // the case where the user entered a choice that's invalid
                        break;
                }
            }
            Console.WriteLine("goodbye"); // program ends
        }

    }
}
