using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class RandomComparer : IComparer<Appliance>
    {
        private Random _random = new Random();
        public int Compare(Appliance x, Appliance y)
        {
            if (x == y) { return 0; }
            else { return _random.Next(-1, 2); }
        }
    }
}
