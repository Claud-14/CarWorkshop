using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReferenceParametersExample
{
    class Program
    {
        internal static int Method(ref int a)
        {
            a = a + 255;
            return a;
        }/*
        internal int RefMethod(out int a) out alone is not enough to modify the method signature
        {
            return a + 255;
        }*/

        static int Method(int a)
        {
           a = a + 255;
            return a;
        }

        static void Main(string[] args)
        {
            int val = 1;

            int rm = Method(val);
            Console.Write("Method returned value: {0}\nVal value: {1}", rm, val);

            Console.ReadLine();

            rm = Method(ref val);
            Console.Write($"Ref Method returned value: {rm}\nVal value: {val}");

            Console.ReadLine();
        }
    }
}
