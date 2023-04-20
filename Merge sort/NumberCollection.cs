using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge_sort
{
    // template that allows us to create objects. Each object has its own methods and attributes. 
    class NumberCollection
    {
        // store all the values in the number collection
        List<int> values = new List<int>();
        NumberCollection left;
        NumberCollection right;

        // encapsulation: wrapping a private attribute in a public method
        /// <summary>
        /// Get the first value in the number collection
        /// </summary>
        public int First { get
            {
                return values[0];
            }
        }

        /// <summary>
        /// True if the number collection is empty
        /// </summary>
        public bool Empty
        {
            get
            {
                return values.Count == 0;
            }
        }

        /// <summary>
        /// Remove the first value from this number collection
        /// </summary>
        /// <returns>The first value from the list before it was removed</returns>
        private int RemoveFirst()
        {
            int v = values[0];
            values.RemoveAt(0);
            return v;
        }

        /// <summary>
        /// Add a new value to the number collection
        /// </summary>
        /// <param name="value">Value to add</param>
        public void Add(int value)
        {
            values.Add(value);
        }

        /// <summary>
        /// Recursively merge sort
        /// </summary>
        public void Sort()
        {

            // exit condition: when this number collection only has one value
            if (values.Count > 1)
            {
                Console.WriteLine($"Splitting [ {this}]");
                // only split if there's more than 1 value in the number collection
                Split();
                left.Sort();
                right.Sort();
                Merge();
            }
            
        }

        /// <summary>
        /// Divides the current number collection into two number collectsions (right and left)
        /// </summary>
        void Split()
        {
            // initialise the left and right number collections
            left = new NumberCollection();
            right = new NumberCollection();

            for (int i = 0; i < values.Count; i++)
            {
                if (i < values.Count / 2)
                {
                    left.Add(values[i]);
                }
                else
                {
                    right.Add(values[i]);
                }
            }
        }

        void Merge()
        {
            values.Clear();
            Console.WriteLine($"Merging left: [ {left}] with right [ {right}]");
            // merge smallest from either collection
            while (!left.Empty && !right.Empty)
            {
                if(left.First < right.First)
                {
                    values.Add(left.RemoveFirst());
                } else
                {
                    values.Add(right.RemoveFirst());
                }
            }

            // one collection may empty first so fill up with remaining values
            while(!left.Empty)
            {
                values.Add(left.RemoveFirst());
            }
            while (!right.Empty)
            {
                values.Add(right.RemoveFirst());
            }
            Console.WriteLine($"Result: [ {this}]");
        }

        // example of polymorphism: allowing a number collection to be converted to a string
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < values.Count; i++)
            {
                sb.Append($"{values[i]} ");
            }
            
            return sb.ToString();
        }
    }
}
