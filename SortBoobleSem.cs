using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace Многопоточность1
{
    class SortBoobleSem
    {
        /// <summary>
        /// Версия параллельного алгоритма
        /// пузырьковой сортировки с введением потоков
        /// для сортировки подмножеств массива
        /// </summary>
        /// <param name="mas">сортируемый массив</param>
        /// <param name="processors">число подмножеств</param>
        public void BubbleSortWithTreads(int[] mas, int processors)
        {
            Thread[] threads = new Thread[processors];
            SortOne[] sorts = new SortOne[processors];
            //Создание объектов SortOne,
            //передаваемых создаваемым потокам
            for (int i = 0; i < processors; i++)
            {
                sorts[i] = new SortOne(mas, i, processors);
               // ThreadPool.QueueUserWorkItem(sorts[i].BubbleSortPart);
                threads[i] = new Thread(sorts[i].BubbleSortPart);               
                threads[i].Start();
            }
            // Thread.Sleep(15);
            //Синхронизация
            for (int i = 0; i < processors; i++)
            {
                threads[i].Join();                
            }     
            //Слияние отсортированных последовательностей
            Merge(mas, processors);
            Console.WriteLine("Многопоточная сортировка");
            foreach(int i in mas)
            {
                Console.Write(i.ToString()+ ' ');
            }
        }
        /// <summary>
        /// Слияние упорядоченных последовательностей
        /// Последовательности представляют отрезки с шагом p
        /// Используется дополнительная память
        /// </summary>
        /// <param name="mas">сортируемый массив</param>
        /// <param name="p">число процессоров</param>
        public void Merge(int[] mas, int p)
        {
            int n = mas.Length;
            int m = n / p;
            int index_min = 0;
            int min = 0;
            int i = 0;
            int[] tmas = new int[n];
            int[] start = new int[p], finish = new int[p];
            for (i = 1; i <= p; i++)
            {
                finish[p - i] = n - i;
                start[p - i] = finish[p - i] % p;
            }
            for (int k = 0; k < n; k++)
            {//пересылка k-ого элемента
                //поиск кандидата
                i = 0;
                while (start[i] > finish[i]) i++;
                index_min = i; min = mas[start[i]];

                for (int j = i + 1; j < p; j++)
                {
                    //цикл по кандидатам
                    if (start[j] <= finish[j])
                    {
                        if (mas[start[j]] < min)
                        {
                            min = mas[start[j]];
                            index_min = j;
                        }
                    }
                }
                //pass                        
                tmas[k] = mas[start[index_min]];
                start[index_min] += p;
            }
            for (i = 0; i < n; i++)
                mas[i] = tmas[i];
        }

    }
}
