using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Base_Nullable
{
    class Program
    {

        // 迭代器中yield关键字
        public static IEnumerable Power(int number, int exponent)
        {
            int counter = 0;
            int result = 1;
            while (counter++ < exponent)
            {
                result = result * number;
                yield return result;
            }
        }


        static void Main(string[] args)
        {
            int? x = 2;
            int xValue = x.GetValueOrDefault();
            if (x.HasValue)
                xValue = x.Value;           
            
            int y = x ?? -2;
            Console.WriteLine(y+","+xValue);
            //Console.ReadKey();


            foreach (int i in Power(2, 8))
            {
                Console.Write("{0} ", i);
            }
            Console.ReadKey();
        }
    }
}
