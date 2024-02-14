using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Refrigerator:Appliance
    {
        /// <summary>
        /// Field that holds number of fridge doors
        /// </summary>
        private int _doors;
        /// <summary>
        /// Width of fridge
        /// </summary>
        private int _width;
        /// <summary>
        /// Height of fridge
        /// </summary>
        private int _height;
        /// <summary>
        /// Property for doors
        /// </summa
        public int Doors { get { return _doors; } set { _doors = value; } }

        /// <summary>
        /// Property for width
        /// </summary>
        public int Width { get { return _width; } set { _width = value; } }


        /// <summary>
        /// Property for height
        /// </summary>
        public int Height { get { return _height; } set { _height = value; } }


        /// <summary>
        /// Constructs Refrigerator object
        /// </summary>
        public Refrigerator(long itemNumber, string brand, int quantity, decimal wattage, string color, decimal price,int doors, int width, int height) : base(itemNumber, brand, quantity, wattage, color, price)
        {
  
            Doors = doors;
            Width = width;
            Height = height;

        }

        public override string FormatForFile()
        {
            return string.Join(';', ItemNumber, Brand, Quantity, Wattage, Color, Price,Doors,Height,Width);
        }

        public override string ToString()
        {
            return $"Item Number:{ItemNumber} \nBrand:{Brand}\nQuantity:{Quantity}\nWattage:{Wattage}\nColor:{Color}\nPrice:{Price}\nDoors:{Doors}\nWidth:{Width}\nHeight:{Height}";
        }

    }
}
