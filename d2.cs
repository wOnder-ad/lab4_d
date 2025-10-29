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

            Console.WriteLine("\n--- ������ ����������� ---");
            Console.WriteLine($"���� |   a   |   b   |  f(a)  |  f(b)  | f(a)*f(b)");

            for (int i = 0; i < maxSteps; i++)
            {
                double fa = f(a);
                double fb = f(b);
                double product = fa * fb;

                Console.WriteLine($" {i,-4} | {a,-5:F2} | {b,-5:F2} | {fa,-6:F2} | {fb,-6:F2} | {product,-8:F2}");

                if (product < 0)
                {
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine($"��������! f(a) �� f(b) ����� ��� �����.");
                    return (a, b);
                }

                a = b;
                b += step;
            }

            Console.WriteLine("---------------------------------");
            Console.WriteLine("�������� �� �������� �� ������� ������� �����.");
            return (double.NaN, double.NaN);
        }

        public static void SolveBisection(double a, double b, double Eps)
        {
            Console.WriteLine($"\n--- ������ ��� ��� ��������� [{a}, {b}] ---");
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
            Console.WriteLine($"���������: x = {(a + b) / 2}, ʳ������ �������� = {Lich}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("г������: f(x) = x^2 - 4");

            Console.WriteLine("\n������ ��������� ����� ��� ������ (startX):");
            double startX = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("������ ���� ������ (step):");
            double step = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("������ ����������� ������� ����� (maxSteps):");
            int maxSteps = Convert.ToInt32(Console.ReadLine());

            (double a, double b) = FindRootInterval(startX, step, maxSteps);

            if (!double.IsNaN(a))
            {
                Console.WriteLine("\n������ ������� Eps ��� ��� (���������, 1e-7):");
                double Eps = Convert.ToDouble(Console.ReadLine());

                SolveBisection(a, b, Eps);
            }

            Console.WriteLine("\n�������� Enter ��� ������...");
            Console.ReadLine();
        }
    }
}