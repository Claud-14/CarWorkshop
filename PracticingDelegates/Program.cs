using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticingDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        public delegate int Multiplier(int a, int b);

        public Multiplier Multiply(int a, int b)
        {
            return a * b;
        }
    }
}
