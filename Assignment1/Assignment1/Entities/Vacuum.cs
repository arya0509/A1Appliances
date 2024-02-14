using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Vacuum:Appliance
    {

        /// <summary>
        /// Field for vacuum grade
        /// </summary>
        private string _grade;

        /// <summary>
        /// Field for vacuum battery voltage
        /// </summary>
        private short _batteryVoltage;

        public const string BatteryVoltageLow = "Low";
        public const string BatteryVoltageHigh = "High";

        /// <summary>
        /// Property for vacuum grade
        /// </summary>
        public string Grade
        {
            get { return _grade; }
        }

        /// <summary>
        /// Property for vacuum battery voltage
        /// </summary>
        public short BatteryVoltage
        {
            get
            {
                return _batteryVoltage;
            }
        }

        /// <summary>
        /// Constructs Vacuum object
        /// </summary>
        public Vacuum(long itemNumber, string brand, int quantity, decimal wattage, string color, decimal price, string grade, short batteryVoltage) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this._grade = grade;
            this._batteryVoltage = batteryVoltage;
        }

        public override string FormatForFile()
        {
            string commonFormatted = base.FormatForFile();
            string formatted = string.Join(';', commonFormatted, Grade, BatteryVoltage);

            return formatted;
        }

        public override string ToString()
        {
            string display =
                string.Format("Item Number: {0}", ItemNumber) + "\n" +
                string.Format("Brand: {0}", Brand) + "\n" +
                string.Format("Quantity: {0}", Quantity) + "\n" +
                string.Format("Wattage: {0}", Wattage) + "\n" +
                string.Format("Color: {0}", Color) + "\n" +
                string.Format("Price: {0}", Price) + "\n" +
                string.Format("Grade: {0}", Grade) + "\n" +
                string.Format("Battery Voltage: {0}", BatteryVoltage);

            return display;
        }
    }
}
