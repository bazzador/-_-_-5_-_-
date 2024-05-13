using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РГР_ЧМІ__5_Прості_Ітерації
{
    internal class Program
    {
        const double eps = 0.01; // Точність вимірювання.
        static double fx(double x) // Введення ф-ції.
        {
            return Math.Sin(x) - Math.Cos(Math.Pow(x, 3));
        }
        static double IterativeMethod(double x0) // Реалізація методу простих ітерацій.
        {
            double x1 = x0;
            int i = 0;
            while (true)
            {
                double temp = fx(x1);
                x1 = x0 - temp; // Використовуємо простий метод ітерацій: x_{n+1} = x_n-f(x_n).
            if (Math.Abs(x1 - x0) < eps || i > 1000) // Перевірка збіжності.
                    break;
                x0 = x1;
                i++;
            }
            return x1;
        }
        static void Main(string[] args)
        {
            List<double> result = new List<double>();
            double a = -2;
            double b = 2;
            double c = (Math.Abs(a - b) / 10000.0);
            List<double> intervals = new List<double>();
            for (double i = a; i <= b; i += c) // Заповнення списку інтервалів.
            {
                intervals.Add(i);
            }
            for (int i = 0; i < intervals.Count - 1; i++) // Заповнення списку коренів.
            {
                if (fx(intervals[i]) * fx(intervals[i + 1]) <= 0)
                {
                    result.Add(IterativeMethod(intervals[i]));
                }
            }
            for (int i = 0; i < result.Count; i++) // Виведення результату.
            {
                Console.Write($"{i + 1} ");
                Console.WriteLine(result[i]);
            }
        }
    }
}
