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

            SortedST<string, string> sortedSt;
            sortedSt = new BST<string, string>();
            sortedSt.Put("r", "1");
            sortedSt.Put("b", "2");
            sortedSt.Put("h", "3");
            sortedSt.Put("t", "4");
            sortedSt.Delete("b");

            st = new SeparateChainingHashST<string, string>();
            st.Put("f", "1");
            st.Put("a", "3");
            st.Put("d", "4");
            st.Put("h", "9");
            st.Put("k", "8");
            var v = st.Get("h");

            st = new LinearProbingHashST<string, string>();
            st.Put("f", "1");
            st.Put("a", "3");
            st.Put("d", "4");
            st.Put("h", "9");
            st.Put("u", "8");
            v = st.Get("u");

            Console.ReadKey();
        }
    }
}
