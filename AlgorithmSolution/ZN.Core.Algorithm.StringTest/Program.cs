using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZN.Core.Algorithm.String;

namespace ZN.Core.Algorithm.StringTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] a = { "abv", "abd", "abc", "afr", "abt", "ayv", "bvc", "ayc" };
            var b = a;
            //LSD.Sort(a, 3);
            MSD.Sort(b);

            Console.ReadKey();
        }
    }
}
