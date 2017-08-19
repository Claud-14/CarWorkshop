using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YieldIterator
{
    class Program
    {
        static IEnumerable<int> Yielder()
        {
            yield return 3;
            yield return 6;
            yield return 9;
        }
        static void Main(string[] args)
        {
            for (int i = 0; i < 0; i++)
            {
                Console.WriteLine(Yielder().ElementAt(i));
            }

            Console.ReadLine();
        }
    }
}
