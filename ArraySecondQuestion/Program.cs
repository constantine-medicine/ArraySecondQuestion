using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace secondQuestion
{
    class Program
    {

        public static int row = 25;
        public static int[,] traingle = new int[row, row];
        public const int cellWidth = 5;

        static void Main(string[] args)
        {
            EnteredRow();

            FillTraingle();

            Print();

            Delay();
        }

        private static void EnteredRow()
        {
            int count = 0;

            while (count < 1)
            {
                Console.Write("Введите количество строк треугольника Паскаля: ");
                row = int.Parse(Console.ReadLine());

                count++;

                if (row > 25)
                {
                    Console.WriteLine("Число строк не должно превышать 25! Повторите ввод");
                    count--;
                }
            }
            Console.Clear();
        }

        private static void FillTraingle()
        {
            for (int i = 0; i < traingle.GetLength(0); i++)
            {
                traingle[i, 0] = 1;
                traingle[i, i] = 1;
            }

            for (int i = 2; i < traingle.GetLength(1); i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    traingle[i, j] = traingle[i - 1, j - 1] + traingle[i - 1, j];
                }
            }
        }

        private static void Print()
        {
            int col = cellWidth * row;

            for (int i = 0; i < traingle.GetLength(0); i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.SetCursorPosition(col, i + 1);
                    if (traingle[i, j] != 0) Console.Write($"{traingle[i, j],cellWidth}");
                    col += cellWidth * 2;
                }

                col = cellWidth * row - cellWidth * (i + 1);

                Console.WriteLine();
            }
        }

        private static void Delay()
        {
            Console.ReadKey();
        }


    }
}
