using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newton_s_method
{
    public class Program
    {
        const double eps = 0.01;

        static double fx(double x)
        {
            return Math.Cos(x * x - x + 1);
        }

        static double dfx(double x)
        {
            return (fx(x + eps) - fx(x)) / eps;
        }

        // Метод Ньютона для знаходження коренів функції
        static double Solve(double x0)
        {
            // Ініціалізуємо x1 як перше припущення
            double x1 = x0 - fx(x0) / dfx(x0);

            int i = 0;
            while (Math.Abs(x1 - x0) > eps)
            {
                x0 = x1;
                x1 = x0 - fx(x0) / dfx(x0);
                i++;
            }

            return x1;
        }

        public static List<double> NewtonsMethod(double a, double b)
        {
            List<double> result = new List<double>();
            List<double> intervals = new List<double>();
            // Визначаємо крок для створення інтервалів
            double c = (double)(Math.Abs(a - b) / 300);

            // Створюємо інтервали та оцінюємо значення функції на кожній точці інтервалу
            for (double i = a; i <= b; i += c)
            {
                // Перевіряємо особливі випадки, коли функція може бути не визначена
                if (i - c < 0 && i > 0)
                {
                    intervals.Add(double.NaN); // Додаємо NaN для цих випадків
                    continue;
                }
                intervals.Add(i);
                //Console.WriteLine($"f({i:f4}) = {fx(i):f4}"); // Виводимо значення функції в точках інтервалу
            }

            // Ітеруємося по інтервалам для знаходження коренів
            for (int i = 0; i < intervals.Count - 1; i++)
            {
                // Перевіряємо, чи є корінь у цьому інтервалі
                if ((fx(intervals[i]) <= 0 && fx(intervals[i + 1]) > 0)
                 || (fx(intervals[i]) > 0 && fx(intervals[i + 1]) <= 0))
                {
                    // Додаємо знайдений корінь у цьому інтервалі до списку результатів
                    result.Add(Solve(intervals[i]));
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            double a = -3;
            double b = 3;

            var result = NewtonsMethod(a, b);

            for (int i = 0; i < result.Count; i++)
            {
                Console.Write($"{i + 1} ");
                Console.WriteLine(result[i]);
            }

            // Чекаємо на введення користувача перед завершенням програми
            Console.ReadKey();
        }
    }
}