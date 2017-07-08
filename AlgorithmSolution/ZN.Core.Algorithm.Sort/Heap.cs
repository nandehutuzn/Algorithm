using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.Algorithm.Sort
{
    /// <summary>
    /// 堆排序   by zhangning  20170708
    /// </summary>
    public class Heap : Example
    {
        public override void Sort(IComparable[] a)
        {
            int N = a.Length;
            for (int k = N / 2 - 1; k >= 0; k--)
                Sink(a, k, N);

            //while (N > 0)
            //{
            //    Exch(a, 1, N--);
            //    Sink(a, 1, N);
            //}

            for (int i = a.Length - 1; i > 0; --i)
            {
                IComparable nTemp = a[0];
                a[0] = a[i];
                a[i] = nTemp;
                Sink(a, i, a.Length);
            }
        }

        private void Sink(IComparable[] a, int i, int nLen)
        {
            //while (2 * i <= nLen)
            //{
            //    int j = 2 * i;
            //    if (j < nLen && Less(j, j + 1)) j++;
            //    if (!Less(i, j)) break;
            //    Exch(a, i, j);
            //    i = j;
            //}
            int nChild = 0;
            IComparable nTemp;
            nTemp = a[i];  //父节点

            for (; (2 * i + 1) < nLen; i = nChild)
            {
                nChild = 2 * i + 1;
                if (nChild < nLen - 1 && Less(a[nChild], a[nChild + 1]))
                    ++nChild;

                if (Less(nTemp, a[nChild]))
                    a[i] = a[nChild];
                else
                    break;

                a[nChild] = nTemp;
            }
        }

        public new static void Exch(IComparable[] a, int i, int j)
        {
            IComparable temp = a[i - 1];
            a[i - 1] = a[j - 1];
            a[j - 1] = temp;
        }
    }
}
