using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Многопоточность1
{
    class BoobleSort
    {
        public static int[] SortB(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i+1; j <arr.Length; j++)
                {
                    if (arr[j] < arr[i])
                    {
                        int tmp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = tmp;
                    }
                }
            }
            return arr;
        }
        public static int[] ToInt(string[] str)
        {
            int[] res = new int[str.Length];
            for (int i = 0; i < str.Length;i++ )
            {
                res[i] = Convert.ToInt32(str[i]);
            }
            return res;
        }
    }
}
