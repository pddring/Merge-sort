using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge_sort
{
    class NumberCollection
    {
        List<int> values = new List<int>();
        NumberCollection left;
        NumberCollection right;

        public int First { get
            {
                return values[0];
            }
        }

        public bool Empty
        {
            get
            {
                return values.Count == 0;
            }
        }

        public int RemoveFirst()
        {
            int v = values[0];
            values.RemoveAt(0);
            return v;
        }

        public NumberCollection()
        {
            values = new List<int>();
        }

        public void Add(int value)
        {
            values.Add(value);
        }

        public void Sort()
        {
            
            if(values.Count > 1)
            {
                Console.WriteLine($"Splitting [ {this}]");
                Split();
                left.Sort();
                right.Sort();
                Merge();
            }
            
        }

        void Split()
        {
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
