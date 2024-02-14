using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Assignment1
{
    public abstract class ModernAppliances

    {

        /// Location of appliances.txt file
        public string Appliances_file = "appliances.txt";

        /// Holds list of appliances
        private List<Appliance> appliances;
        //creating an enumeration that relate a type of appliance to a number
        public enum Options
        {
            None,
            Checkout = 1,
            Find = 2,
            DisplayType = 3,
            RandomList = 4,
            SaveExit = 5,
        }
        

 
        //creates a copy of the orignal appliance list,
        public List<Appliance> Appliances_
        {
            get { return new List<Appliance>(appliances); }
        }
        // Called when ModernAppliances instance is created
        public ModernAppliances()
        {
            this.appliances = this.ReadAppliances();
        }

        // Displays menu options
        public void DisplayMenu()
        {
            Console.WriteLine("Welcome to Modern Appliances!");
            Console.WriteLine("How May We Assist You ?");
            Console.WriteLine("1 – Check out appliance");
            Console.WriteLine("2 – Find appliances by brand");
            Console.WriteLine("3 – Display appliances by type");
            Console.WriteLine("4 – Produce random appliance list");
            Console.WriteLine("5 – Save & exit");
        }
        
        //reads the line poassed from another method 
        //Creates an object out of it 
        private Appliance CreateApplianceFromLine(string line)
        {
            string[] parts = line.Split(';');
            char firstDigit = parts[0][0];
            Appliance appliance = null;
            if (firstDigit == '1')
            {
                // Refrigerator
                appliance = CreateRefrigeratorFromParts(parts);
            }
            else if (firstDigit == '2')
            {
                // Vacuum
                appliance = CreateVacuumFromParts(parts);
            }
            else if (firstDigit == '3')
            {
                // Microwave
                appliance = CreateMicrowaveFromParts(parts);
            }
            else if (firstDigit == '4' || firstDigit == '5')
            {
                // Dishwasher
                appliance = CreateDishwasherFromParts(parts);
            }
            else
            {
                appliance = null;
            }

            return appliance;
        }


        //if the line is found to be that of the refrigerator
        //the CreateApplianceFromLine(string line) method then passes the line to this method which then creates an object
        private Refrigerator CreateRefrigeratorFromParts(string[] parts)
        {
            if (parts.Length != 9)
            {
                return null;
            }
            else
            {
                long itemNumber = long.Parse(parts[0]);
                string brand = parts[1];
                int quantity = int.Parse(parts[2]);
                decimal wattage = decimal.Parse(parts[3]);
                string color = parts[4];
                decimal price = decimal.Parse(parts[5]);
                short doors = short.Parse(parts[6]);
                int width = int.Parse(parts[7]);
                int height = int.Parse(parts[8]);


                Refrigerator refrigerator = new Refrigerator(itemNumber, brand, quantity, wattage, color, price, doors, width, height);

                return refrigerator;
            }

        }
        //if the line is found to be that of the vacuum
        //the CreateApplianceFromLine(string line) method then passes the line to this method which then creates an object
        private Vacuum CreateVacuumFromParts(string[] parts)
        {
            if (parts.Length != 8)
            {
                return null;
            }
            else
            {
                long itemNumber = long.Parse(parts[0]);
                string brand = parts[1];
                int quantity = int.Parse(parts[2]);
                decimal wattage = decimal.Parse(parts[3]);
                string color = parts[4];
                decimal price = decimal.Parse(parts[5]);
                string grade = parts[6];
                short batteryVoltage = short.Parse(parts[7]);

                Vacuum vacuum = new Vacuum(itemNumber, brand, quantity, wattage, color, price, grade, batteryVoltage);

                return vacuum;
            }

        }
        //if the line is found to be that of the Dishwahser
        //the CreateApplianceFromLine(string line) method then passes the line to this method which then creates an object
        private Dishwasher CreateDishwasherFromParts(string[] parts)
        {
            if (parts.Length != 8)
            {
                return null;
            }
            else
            {
                long itemNumber = long.Parse(parts[0]);
                string brand = parts[1];
                int quantity = int.Parse(parts[2]);
                decimal wattage = decimal.Parse(parts[3]);
                string color = parts[4];
                decimal price = decimal.Parse(parts[5]);
                string feature = parts[6];
                string soundRating = parts[7];

                Dishwasher dishwasher = new Dishwasher(itemNumber, brand, quantity, wattage, color, price, feature, soundRating);

                return dishwasher;
            }

        }

        //if the line is found to be that of the microvawe
        //the CreateApplianceFromLine(string line) method then passes the line to this method which then creates an object
        private Microwave CreateMicrowaveFromParts(string[] parts)
        {
            if (parts.Length != 8)
            {
                return null;
            }
            else
            {
                long itemNumber = long.Parse(parts[0]);
                string brand = parts[1];
                int quantity = int.Parse(parts[2]);
                decimal wattage = decimal.Parse(parts[3]);
                string color = parts[4];
                decimal price = decimal.Parse(parts[5]);
                float capacity = float.Parse(parts[6]);
                char roomType = char.Parse(parts[7]);

                Microwave microwave = new Microwave(itemNumber, brand, quantity, wattage, color, price, capacity, roomType);

                return microwave;
            }




        }
        //accepts a list and a max value to display appliance through Tostring method
        //the max is used to determine the number of appliance to be printed from the list
        public void DisplayAplianceFromList(List<Appliance> appliances, int max)
        {
            if (appliances.Count > 0)
            {
                Console.WriteLine("Found appliances");


                for (int i = 0; i < appliances.Count && (max == 0 || i < max); i++)
                {
                    Appliance appliance = appliances[i];
                    Console.WriteLine(appliance);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No Appliance Found");
                Console.WriteLine();
            }


        }
        //An abstract method that is used to display refrigerator
        public abstract void DisplayRefrigerators();

        //An abstract method that is used to display vaccum
        public abstract void DisplayVaccums();

        //An abstract method that is used to display microwaves
        public abstract void DisplayMicrowaves();

        //An abstract method that is used to display dishwasher
        public abstract void DisplayDishwahsers();

        //An abstract method that is used to display a random list of appliances
        public abstract void RandomList();
        //this method allows to dcheckout an appliance ie decrement the quantity of an appliance after a customer has purchased it
        public abstract void Checkout();

        //the find() method helps in searching for an appliance based on a given condition
        public abstract void find();

        //this method allows us to save any changes made in the appliance list to the appliances.txt file
        public void Save()
        {
            Console.WriteLine("Saving...");
            using (StreamWriter writer = new StreamWriter(Appliances_file))
            {
                foreach (Appliance appliance in Appliances_)
                {
                    writer.WriteLine(appliance.FormatForFile());
                }

            }
        }
        //A method which is used to read appliances information in the correct format,from the file
        private List<Appliance> ReadAppliances()
        {
            List<Appliance> appliances = new List<Appliance>();
            using (StreamReader reader = new StreamReader(Appliances_file))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Appliance appliance = this.CreateApplianceFromLine(line);
                    appliances.Add(appliance);
                }
                return appliances;
            }
        }

        //this method creates a menu for the user which allows them to see information on differnt types of appliance
        public void DisplayType()
        {
            Console.WriteLine("Appliance Types");
            Console.WriteLine("1 – Refrigerators");
            Console.WriteLine("2 – Vacuums");
            Console.WriteLine("3 – Microwaves");
            Console.WriteLine("4 – Dishwashers");

            Console.Write("Enter type of appliance:");
            string type = Console.ReadLine();
            int IntType = int.Parse(type);
            if (IntType == 1)
            {
                this.DisplayRefrigerators();
            }
            else if (IntType == 2)
            {
                this.DisplayVaccums();
            }
            else if (IntType == 3)
            {
                this.DisplayMicrowaves();
            }
            else if (IntType == 4)
            {
                this.DisplayDishwahsers();
            }
            else
            {
                Console.WriteLine("Invalid appliance type entered.");
                DisplayType();

            }

        }
        











    }

}
