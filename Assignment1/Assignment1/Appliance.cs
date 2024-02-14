using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{

    public abstract class Appliance
    {
        public enum ApplianceTypes
        {
            Unknown,
            Refrigerator = 1,
            Vacuum = 2,
            Microwave = 3,
            Dishwasher = 4
        }
        //Definign all the fields for appliance class
        private string _brand;
        private string _color;
        private long _itemNumber;
        private decimal _price;
        private int _quantity;
        private decimal _wattage;

        //defining all the getter properties 
        public string Brand 
        { 
            get { return _brand; }
   
        }
        
        public string Color 
        {
            get { return _color; }

        }

    
        public bool IsAvailable {
            get
            {
                if (Quantity > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
        }

        public long ItemNumber 
        {
            get { return _itemNumber;}
            set { _itemNumber = ItemNumber; }
        }

        public decimal Price 
        {
            get { return _price; }
            set { _price = Price; }
        }

        public int Quantity 
        { 
          get { return _quantity; }
          set { _quantity = Quantity; }
        }

        public decimal Wattage
        {
            get { return _wattage;}
  
        }
        public string Type { get; set; }

        //Constructor for the appliance class
        public Appliance(long itemNumber, string brand, int quantity, decimal wattage, string color, decimal price)
        {
            _itemNumber = itemNumber;
            _brand = brand;
            _quantity = quantity;
            _wattage = wattage;
            _color = color;
            _price = price;
        }


       //checkout method is used when a customer checks out an appliance
       //It reduces the quantity of the appliance by 1 in the file,indicating
       //that a customer has checkoud out an appliance
        public void checkout()
        {
            this._quantity=this._quantity-1;
        }

        // Formats appliance to be stored in file    
        public virtual string FormatForFile() 
        {
            return string.Join(';', ItemNumber, Brand, Quantity, Wattage, Color, Price);

        }


           /// Determines appliance type from item number
        public static string DetermineApplianceTypeFromItemNumber(long itemNumber)
        {
            string firstDigitStr = itemNumber.ToString().Substring(0, 1);
            short firstDigit = short.Parse(firstDigitStr);

            if (firstDigit == 1)
            {
                // Refrigerator
                return "Refrigerator";
            }
            else if (firstDigit == 2)
            {
                // Vacuum
                return "Vacuum";
            }
            else if (firstDigit == 3)
            {
                // Microwave
                return "Microwave";
            }
            else if (firstDigit == 4 || firstDigit == 5)
            {
                // Dishwasher
                return "Dishwasher";
            }
            else
            {
                // Unknown
                return "Unknown";
            }
        }



    }




}
