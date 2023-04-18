using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int MAX_VAL = 10000;
            int MIN_VAL = 0;

            // use custom class which implements a recursive merge sort
            NumberCollection data = new NumberCollection();

            // choose 32 random values
            Random r = new Random();
            for (int i = 0; i < 32; i++)
            {
                data.Add(r.Next(MIN_VAL, MAX_VAL));
            }


            // Merge sort
            data.Sort();


            // display the values
            Console.WriteLine(data);
        }
        
    }
}
