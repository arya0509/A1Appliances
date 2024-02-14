using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static System.Net.Mime.MediaTypeNames;

namespace Assignment1
{
    /// <summary>
    /// Manager class for Modern Appliances
    /// </summary>
    /// <remarks>Author: Ailton Ribeiro Junior,Arya Perbhaker - Group 05 </remarks>
    /// <remarks>Date: Feb, 13, 2024 </remarks>
    public class MyModernAppliances:ModernAppliances
    {
        /// <summary>
        /// Option 1: Performs a checkout.ie allows the customer to buy the appliance and also deals
        ///with any scenario that may arise such as non availability of an appliance
        /// </summary>
        public override void Checkout()
        {
            Console.WriteLine("Enter the Item Number of the appliance: ");
            // Creates a long variable to hold item number
            long itemnumber;
            // Gets user input as string and assign to variable.
            string stringItemNum = Console.ReadLine();
            // Convert user input from string to long and store as item number variable.
            itemnumber = long.Parse(stringItemNum);

            Appliance foundAppliance = null;
            // Loops through the Appliances
            foreach (Appliance appliance in Appliances_)
            {
                // Tests if the  appliance item number equals entered item number
                if (appliance.ItemNumber == itemnumber)
                {
                    foundAppliance = appliance;
                    break;
                }

            }
            //gets executed when no appliance was found
            if (foundAppliance == null)
            {
                Console.WriteLine("No appliance was found with that number");
            }

            else
            {
                if (foundAppliance.IsAvailable)
                {
                    foundAppliance.checkout();
                    Console.WriteLine("Appliance has been checked out");
                }
                else
                {
                    Console.WriteLine("The appliance is not available to be checked out");
                }
            }

        }

        /// <summary>
        /// Option 2: Finds appliances by taking in the brand name from the user and searching for it in the provided list
        /// </summary>
        public override void find()
        {
            // Write "Enter brand to search for:"
            Console.WriteLine("Enter brand to search for:");

            // Create string variable to hold entered brand
            // Get user input as string and assign to variable.
            string brand;
            brand = Console.ReadLine();
            // Create list to hold found Appliance objects
            List<Appliance> foundAppliances = new List<Appliance>();
            // Iterates through loaded appliances
            
            foreach (Appliance appliance in Appliances_)
            {
                // Test current appliance brand matches what user entered
                if (appliance.Brand == brand)
                { foundAppliances.Add(appliance); }
            }
            // Display found appliances
            DisplayAplianceFromList(foundAppliances, 0);



        }
        /// <summary>
        /// Generates random list of appliances by first taking in the user input on what type of appliance they want to view. 
        /// </summary>
        public override void RandomList()
        {
            Console.WriteLine("Appliance type");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - refrigerator");
            Console.WriteLine("2 - Microwaves");
            Console.WriteLine("3 - Dishwasher");
            Console.WriteLine("enter the type of appliance");
            string ApplianceType= Console.ReadLine();
            Console.WriteLine("Enter number of appliances: ");
            // Get user input as string and assign to variable

            // Convert user input from string to int

            // Create variable to hold list of found appliances
            string num = Console.ReadLine();
            int intNum=int.Parse(num);
            List<Appliance> foundAppliances = new List<Appliance>();
            foreach (Appliance appliance in Appliances_)
            {
                if (ApplianceType == "0") 
                {
                    foundAppliances.Add(appliance);
                }
                else if (ApplianceType == "1") 
                {
                    if(appliance is Refrigerator) 
                    {
                        foundAppliances.Add(appliance);
                    }
                }
                else if (ApplianceType == "2")
                {
                    if (appliance is Vacuum)
                    {
                        foundAppliances.Add(appliance);
                    }
                }
                else if (ApplianceType == "3")
                {
                    if (appliance is Microwave)
                    {
                        foundAppliances.Add(appliance);
                    }
                }
                else if (ApplianceType == "4")
                {
                    if (appliance is Dishwasher)
                    {
                        foundAppliances.Add(appliance);
                    }
                }
                // Randomize list of found appliances
                foundAppliances.Sort(new RandomComparer());
                
            }
            // Display found appliances (up to max. nu
            DisplayAplianceFromList(foundAppliances, intNum);


        }
        // <summary>
        /// Displays Refridgerators:based on what type of fridge the user wants to purchase:Single door,double door etc
        /// </summary>
        public override void DisplayRefrigerators()
        {
            Console.WriteLine("possible options");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Double Doors");
            Console.WriteLine("2 - Three Doors");
            Console.WriteLine("3 - Four Doors");
            Console.WriteLine("Enter number of doors: ");

            

            // Creating variable to hold entered number of doors

            // Geting user input as string and assign to variable

            string doorNum =Console.ReadLine();
            int IntdoorNum=int.Parse(doorNum);

      

            // Creating list to hold found Appliance objects
            List<Appliance> foundAppliances = new List<Appliance>();
            // Iterate/loop through Appliances
            // Test that current appliance is a refrigerator
            // Down cast Appliance to Refrigerator
            // Refrigerator refrigerator = (Refrigerator) appliance;

            // Test user entered 0 or refrigerator doors equals what user entered.
            // Add current appliance in list to found list
            foreach ( Appliance appliance in Appliances_ )
            {
                if(appliance is Refrigerator)
                {
                    Refrigerator refrigerator = (Refrigerator)appliance;
                    if(IntdoorNum==0)
                    {
                        foundAppliances.Add(refrigerator) ;
                    }
                    else if(IntdoorNum==1)
                    {
                        if (refrigerator.Doors == 2) 
                        {
                            foundAppliances.Add(refrigerator);
                        }
                    }
                    else if (IntdoorNum == 2)
                    {
                        if (refrigerator.Doors == 3)
                        {
                            foundAppliances.Add(refrigerator);
                        }
                    }
                    else if (IntdoorNum == 3)
                    {
                        if (refrigerator.Doors == 4)
                        {
                            foundAppliances.Add(refrigerator);
                        }
                    }
                }

            }
            // Display found appliances
            DisplayAplianceFromList(foundAppliances, 0);

        }

        /// <summary>
        /// Displays Vacuums
        /// </summary>
        public override void DisplayVaccums()
        {
            Console.WriteLine("possible options");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Residential");
            Console.WriteLine("2 - Coomercial");
            Console.WriteLine("Enter grade: ");
            // Get user input as string and assign to variable

            // Create grade variable to hold grade to find (Any, Residential, or Commercial
            string input = Console.ReadLine();
            string grade;
            if (input == "0")
            {
                grade = "Any";
            }
            else if (input == "1")
            {
                grade = "Residential";
            }
            else if (input == "2")
            {
                grade = "Commercial";
            }
            else
            {
                {
                    Console.WriteLine("Invalid option");
                    return;
                }
            }

            Console.WriteLine("possible options");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - 18 Volt");
            Console.WriteLine("2 - 24 Volt");
            Console.WriteLine("Enter Voltage: ");
            // Get user input as string
            // Create variable to hold voltage
            string input2 = Console.ReadLine();
            int voltage;
            if (input2 == "0")
            {
                voltage = 0;
            }
            else if (input2 == "1")
            {
                voltage = 18;
            }
            else if (input2 == "2")
            {
                voltage = 24;
            }
            else
            {
                Console.WriteLine("Invalid option");
                return;
            }
            List<Appliance> found = new List<Appliance>();

            // Loop through Appliances
            // Checks if current appliance is vacuum
            
            foreach (Appliance appliance in Appliances_)
            {
                if (appliance is Vacuum)
                {
                    // Down cast current Appliance to Vacuum object
                    Vacuum vacuum = (Vacuum)appliance;
                    if (grade == "Any")
                    {
                        if (voltage == 0)
                        {
                            found.Add(vacuum);
                        }
                        else if (voltage == vacuum.BatteryVoltage)
                        {
                            found.Add(vacuum);
                        }
                    }
                    else if (grade == vacuum.Grade)
                    {
                        if (voltage == 0)
                        {
                            found.Add(vacuum);
                        }
                        else if (voltage == vacuum.BatteryVoltage)
                        {
                            found.Add(vacuum);
                        }


                    }

                }
                
            }
            DisplayAplianceFromList(found, 0);

        }
        /// <summary>
        /// Displays microwaves
        /// </summary>
        public override void DisplayMicrowaves()
        {
            Console.WriteLine("possible options");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Kitchen");
            Console.WriteLine("2 - Work site");
            Console.WriteLine("Enter room type: ");
            // Get user input as string and assign to variable

            // Create character variable that holds room type
            string input =Console.ReadLine();
            char RoomType;
            if(input=="0")
            {
                RoomType = 'A';
            }
            else if(input=="1")
            {
                RoomType = 'K';
            }
            else if (input=="2")
            {
                RoomType = 'W';
            }
            else
            {
                Console.WriteLine("Invalid option");
                return;
            }
            // Create variable that holds list of 'found' appliances
            List<Appliance> found = new List<Appliance>();

            
           

          
            // Loop through Appliances
            foreach (Appliance appliance in  Appliances_)
            {
                // Test current appliance is Microwave
                if (appliance is Microwave)
                {
                    // Down cast Appliance to Microwave
                    Microwave microwave = (Microwave)appliance;
                    if(RoomType == 'A'||RoomType.Equals(microwave.RoomType))
                    {
                        found.Add(microwave);
                    }
                }
            }

            // Display found appliances
            DisplayAplianceFromList(found, 0);


        }
        //displayDishwashers,theis method displays dishwasher base off their rating-quitest,quieter,quiet,moderate

        public override void DisplayDishwahsers()
        {
            Console.WriteLine("possible options");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Quietest");
            Console.WriteLine("2 - Quieter");
            Console.WriteLine("3 - Quiet: ");
            Console.WriteLine("4 - Moderate");
            Console.WriteLine("Enter sound rating:");
            // Get user input as string and assign to variable

            // Creating variable that holds sound rating
            string input = Console.ReadLine();
            string SoundRating;

            if (input == "0") 
            {
                SoundRating = "Any";
            }
            else if(input == "1")
            {
                SoundRating = "Qt";

            }
            else if (input == "2")
            {
                SoundRating = "Qr";
            }
            else if (input == "3")
            {
                SoundRating = "Qu";
            }
            else if (input=="4")
            {
                SoundRating = "M";
            }
            else
            { 
                Console.WriteLine("Invalid option.");
                return;
            }
            // Create variable that holds list of found appliances
            List<Appliance> found = new List<Appliance>();

            
            

            /
            // Loop through Appliances
            foreach (Appliance appliance in Appliances_)
            {
                // Test if current appliance is dishwasher
                if (appliance is Dishwasher) 
                {
                    // Down cast current Appliance to Dishwasher
                    Dishwasher dishwasher = (Dishwasher)appliance;
                    if(SoundRating=="Any"||SoundRating==dishwasher.SoundRating )
                    {
                        found.Add(dishwasher);
                    }

                }
            
            }
            // Display found appliances (up to max. number inputted)
            DisplayAplianceFromList(found, 0);

        }









    }
}

