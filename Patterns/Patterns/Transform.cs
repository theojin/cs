using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public delegate T Transformer<T>(T arg);

    class Transform
    {
        public static void TransformArray<T>(T[] values, Transformer<T> t)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = t.Invoke(values[i]);
            }
        }

#if false
        private static void Main()
        {
            int[] values = { 1, 2, 3, 4 };
            TransformArray(values, Square);
            foreach (int i in values)
                Console.WriteLine(i);
        }
#endif

        static int Square(int x) => x * x;
    }
}
