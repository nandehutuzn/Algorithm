using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZN.Core.Algorithm.Search;

namespace ZN.Core.Algorithm.SearchTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ST<string, string> st;
            st = new SequentialSearchST<string, string>();
            st.Put("a", "1");
            st.Put("b", "2");
            int size = st.Size();
            st.Delete("a");
            size = st.Size();

            Console.ReadKey();
        }
    }
}
