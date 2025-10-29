using System;
using System.Text;

namespace d1
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

        public static double fp(double x)
        {
            return 2 * x;
        }

        public static double f2p(double x)
        {
            return 2;
        }

        public static void SolveBisection(double a, double b, double Eps)
        {
            int Lich = 0;

            if (f(a) * f(b) > 0)
            {
                Console.WriteLine("На заданому інтервалі [a, b] кореня немає або їх парна кількість.");
                return;
            }

            if (Math.Abs(f(a)) < Eps)
            {
                Console.WriteLine($"Результат (МДН): x = {a}, Кількість ітерацій = {Lich}");
                return;
            }
            if (Math.Abs(f(b)) < Eps)
            {
                Console.WriteLine($"Результат (МДН): x = {b}, Кількість ітерацій = {Lich}");
                return;
            }

            while (Math.Abs(b - a) > Eps)
            {
                double c = (a + b) / 2;
                Lich++;

                if (Math.Abs(f(c)) < Eps)
                {
                    a = c;
                    b = c;
                    break;
                }
                else if (f(a) * f(c) < 0)
                {
                    b = c;
                }
                else
                {
                    a = c;
                }
            }
            Console.WriteLine($"Результат (МДН): x = {(a + b) / 2}, Кількість ітерацій = {Lich}");
        }

        public static void SolveNewton(double a, double b, double Eps, int Kmax)
        {
            double x = b; 

            if (f(x) * f2p(x) < 0)
            {
                x = a;
            }
            if (f(x) * f2p(x) <= 0)
            {
                Console.WriteLine("Збіжність методу Ньютона не гарантується для початкових наближень.");
                return;
            }

            for (int i = 1; i <= Kmax; i++)
            {
                double fx = f(x);
                double fpx = fp(x);

                if (Math.Abs(fpx) < 1e-12) 
                {
                    Console.WriteLine("Помилка: Похідна близька до нуля.");
                    return;
                }

                double Dx = fx / fpx;
                x = x - Dx;

                if (Math.Abs(Dx) < Eps)
                {
                    Console.WriteLine($"Результат (МН): x = {x}, Кількість ітерацій = {i}");
                    return;
                }
            }

            Console.WriteLine($"За {Kmax} ітерацій корінь з точністю {Eps} не знайдено.");
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Рівняння: f(x) = x^2 - 4");
                Console.WriteLine("Оберіть метод для розв'язання:");
                Console.WriteLine("1. Метод Ділення Навпіл (МДН)");
                Console.WriteLine("2. Метод Ньютона (МН)");
                Console.WriteLine("3. Вихід");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();
                double a, b, Eps;
                int Kmax;

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\n--- Метод Ділення Навпіл ---");
                        Console.WriteLine("Введіть a (ліва межа):");
                        a = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Введіть b (права межа):");
                        b = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Введіть точність Eps:");
                        Eps = Convert.ToDouble(Console.ReadLine());

                        SolveBisection(a, b, Eps); 
                        break;

                    case "2":
                        Console.WriteLine("\n--- Метод Ньютона ---");
                        Console.WriteLine("Введіть a (ліва межа для почат. наближення):");
                        a = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Введіть b (права межа для почат. наближення):");
                        b = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Введіть точність Eps:");
                        Eps = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Введіть макс. кількість ітерацій Kmax:");
                        Kmax = Convert.ToInt32(Console.ReadLine());

                        SolveNewton(a, b, Eps, Kmax); 
                        break;

                    case "3":
                        Console.WriteLine("Завершення роботи...");
                        return;

                    default:
                        Console.WriteLine("Невірний вибір. Будь ласка, введіть 1, 2 або 3.");
                        break;
                }

                Console.WriteLine("Натисніть Enter для повернення в меню...");
                Console.ReadLine();
            }
        }
    }
}