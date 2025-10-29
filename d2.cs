using System;
using System.Text;

namespace d2
{
    class Program
    {
        static Program()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
        }

        public static double f(double x)
        {
            return x * x - 4;
        }

        public static (double a, double b) FindRootInterval(double startX, double step, int maxSteps)
        {
            double a = startX;
            double b = startX + step;

            Console.WriteLine("\n--- Процес Табулювання ---");
            Console.WriteLine($"Крок |   a   |   b   |  f(a)  |  f(b)  | f(a)*f(b)");

            for (int i = 0; i < maxSteps; i++)
            {
                double fa = f(a);
                double fb = f(b);
                double product = fa * fb;

                Console.WriteLine($" {i,-4} | {a,-5:F2} | {b,-5:F2} | {fa,-6:F2} | {fb,-6:F2} | {product,-8:F2}");

                if (product < 0)
                {
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine($"ЗНАЙДЕНО! f(a) та f(b) мають різні знаки.");
                    return (a, b);
                }

                a = b;
                b += step;
            }

            Console.WriteLine("---------------------------------");
            Console.WriteLine("Інтервал не знайдено за вказану кількість кроків.");
            return (double.NaN, double.NaN);
        }

        public static void SolveBisection(double a, double b, double Eps)
        {
            Console.WriteLine($"\n--- Запуск МДН для інтервалу [{a}, {b}] ---");
            int Lich = 0;

            if (Math.Abs(f(a)) < Eps)
            if (Math.Abs(f(b)) < Eps) 

            while (Math.Abs(b - a) > Eps)
            {
                double c = (a + b) / 2;
                Lich++;
                if (Math.Abs(f(c)) < Eps) { break; }
                else if (f(a) * f(c) < 0) { b = c; }
                else { a = c; }
            }
            Console.WriteLine($"РЕЗУЛЬТАТ: x = {(a + b) / 2}, Кількість ітерацій = {Lich}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Рівняння: f(x) = x^2 - 4");

            Console.WriteLine("\nВведіть початкову точку для пошуку (startX):");
            double startX = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введіть крок пошуку (step):");
            double step = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введіть максимальну кількість кроків (maxSteps):");
            int maxSteps = Convert.ToInt32(Console.ReadLine());

            (double a, double b) = FindRootInterval(startX, step, maxSteps);

            if (!double.IsNaN(a))
            {
                Console.WriteLine("\nВведіть точність Eps для МДН (наприклад, 1e-7):");
                double Eps = Convert.ToDouble(Console.ReadLine());

                SolveBisection(a, b, Eps);
            }

            Console.WriteLine("\nНатисніть Enter для виходу...");
            Console.ReadLine();
        }
    }
}