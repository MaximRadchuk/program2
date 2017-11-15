using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Многопоточность1
{
    class SortOne
    {
        int[] mas;
        int j;
        int p;
        int n;
        public SortOne(int[] mas, int j, int p)
        {
            this.mas = mas;
            this.j = j;
            this.p = p;
            n = mas.Length;
        }

        /// <summary>
        /// Сортирует пузырьком часть массива mas
        /// начиная с элемента с номером n - j -1
        /// Сортируемые элементы отстоят на расстоянии p
        /// </summary>
        public void BubbleSortPart(object t)
        {
            int i0 = n - j - 1, m = i0 / p;
            int temp;
            //цикл по числу проходов m
            for (int k = 0; k < m; k++)
            {
                //цикл всплытия легкого элемента на k-м проходе
                for (int i = i0; i - p >= k * p; i = i - p)
                {
                    if (mas[i] < mas[i - p])
                    {//swap
                        temp = mas[i];
                        mas[i] = mas[i - p];
                        mas[i - p] = temp;
                    }
                }
            }
        }
    }
}
