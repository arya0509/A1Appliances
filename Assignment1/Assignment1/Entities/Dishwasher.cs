using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Dishwasher:Appliance
    {
        /// <summary>
        /// Constant for quietest sound rating
        /// </summary>
        public const string SoundRatingQuietest = "Qt";
        /// <summary>
        /// Constant for quieter sound rating
        /// </summary>
        public const string SoundRatingQuieter = "Qr";
        /// <summary>
        /// Constant for quiet sound rating
        /// </summary>
        public const string SoundRatingQuiet = "Qu";
        /// <summary>
        /// Constant for moderate sound rating
        /// </summary>
        public const string SoundRatingModerate = "M";

        /// <summary>
        /// Field that hold feature and oundrating 
        /// </summary>
        private string _feature;
        
        private string _soundRating;
     
        //Getters for feature and soundrating
        public string Feature
        {
            get
            {
                return _feature;
            }
        }
      
        public string SoundRating
        {
            get
            {
                return _soundRating;
            }
        }
        /// <summary>
        /// Property getter for sound rating
        /// </summary>
        public string SoundRatingDisplay
        {
            get
            {
                switch (_soundRating)
                {
                    case SoundRatingQuietest:
                        return "Quietest";
                    case SoundRatingQuieter:
                        return "Quieter";
                    case SoundRatingQuiet:
                        return "Quiet";
                    case SoundRatingModerate:
                        return "Moderate";
                    default:
                        return "(Unknown)";
                }
            }
        }
        //constructor
        public Dishwasher(long itemNumber, string brand, int quantity, decimal wattage, string color, decimal price, string feature, string soundRating) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this._feature = feature;
            this._soundRating = soundRating;
        }
        //formatting it so it can be stored in a file
        public override string FormatForFile()
        {
            string commonFormatted = base.FormatForFile();
            string formatted = string.Join(';', commonFormatted, Feature, SoundRating);

            return formatted;
        }
        //overriding the ToString() method
        public override string ToString()
        {
            string display =
                string.Format("Item Number: {0}", ItemNumber) + "\n" +
                string.Format("Brand: {0}", Brand) + "\n" +
                string.Format("Quantity: {0}", Quantity) + "\n" +
                string.Format("Wattage: {0}", Wattage) + "\n" +
                string.Format("Color: {0}", Color) + "\n" +
                string.Format("Price: {0}", Price) + "\n" +
                string.Format("Feature: {0}", Feature) + "\n" +
                string.Format("Sound Rating: {0}", SoundRatingDisplay);

            return display;
        }



    }
}
