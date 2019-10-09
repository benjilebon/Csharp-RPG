using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public static class RandomExtensions
    {
        public static double NextDouble(double MinValue, double MaxValue)
        {
            Random random = new Random();
            return random.NextDouble() * (MaxValue - MinValue) + MinValue;
        }
    }
}
