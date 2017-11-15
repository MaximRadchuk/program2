using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Многопоточность1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*FileStream fs = new FileStream("Text.txt",FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string inp = null;
            for (int i = 0; i < 2; i++)
            {
                inp += sr.ReadLine();
            }
            string[] str = inp.Split(' ');*/
            Console.WriteLine("Введите массив через пробел:");
            string[] str = (Console.ReadLine()).Split(' ');
            int[] arr = BoobleSort.ToInt(str);
           // Semaphore sm = new Semaphore(3,3);
            SortBoobleSem sbs = new SortBoobleSem();
            sbs.BubbleSortWithTreads(arr,3);
            Console.WriteLine();
            arr = BoobleSort.SortB(arr);
            Console.WriteLine("Сортировка в один поток");
            foreach (int i in arr)
            {
                Console.Write(i.ToString()+ ' ');
            }                    
            Console.ReadKey();
        }
    }
}
