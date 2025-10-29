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
                Console.WriteLine("�� �������� �������� [a, b] ������ ���� ��� �� ����� �������.");
                return;
            }

            if (Math.Abs(f(a)) < Eps)
            {
                Console.WriteLine($"��������� (���): x = {a}, ʳ������ �������� = {Lich}");
                return;
            }
            if (Math.Abs(f(b)) < Eps)
            {
                Console.WriteLine($"��������� (���): x = {b}, ʳ������ �������� = {Lich}");
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
            Console.WriteLine($"��������� (���): x = {(a + b) / 2}, ʳ������ �������� = {Lich}");
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
                Console.WriteLine("������� ������ ������� �� ����������� ��� ���������� ���������.");
                return;
            }

            for (int i = 1; i <= Kmax; i++)
            {
                double fx = f(x);
                double fpx = fp(x);

                if (Math.Abs(fpx) < 1e-12) 
                {
                    Console.WriteLine("�������: ������� ������� �� ����.");
                    return;
                }

                double Dx = fx / fpx;
                x = x - Dx;

                if (Math.Abs(Dx) < Eps)
                {
                    Console.WriteLine($"��������� (��): x = {x}, ʳ������ �������� = {i}");
                    return;
                }
            }

            Console.WriteLine($"�� {Kmax} �������� ����� � ������� {Eps} �� ��������.");
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("г������: f(x) = x^2 - 4");
                Console.WriteLine("������ ����� ��� ����'������:");
                Console.WriteLine("1. ����� ĳ����� ����� (���)");
                Console.WriteLine("2. ����� ������� (��)");
                Console.WriteLine("3. �����");
                Console.Write("��� ����: ");

                string choice = Console.ReadLine();
                double a, b, Eps;
                int Kmax;

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\n--- ����� ĳ����� ����� ---");
                        Console.WriteLine("������ a (��� ����):");
                        a = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("������ b (����� ����):");
                        b = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("������ ������� Eps:");
                        Eps = Convert.ToDouble(Console.ReadLine());

                        SolveBisection(a, b, Eps); 
                        break;

                    case "2":
                        Console.WriteLine("\n--- ����� ������� ---");
                        Console.WriteLine("������ a (��� ���� ��� �����. ����������):");
                        a = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("������ b (����� ���� ��� �����. ����������):");
                        b = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("������ ������� Eps:");
                        Eps = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("������ ����. ������� �������� Kmax:");
                        Kmax = Convert.ToInt32(Console.ReadLine());

                        SolveNewton(a, b, Eps, Kmax); 
                        break;

                    case "3":
                        Console.WriteLine("���������� ������...");
                        return;

                    default:
                        Console.WriteLine("������� ����. ���� �����, ������ 1, 2 ��� 3.");
                        break;
                }

                Console.WriteLine("�������� Enter ��� ���������� � ����...");
                Console.ReadLine();
            }
        }
    }
}