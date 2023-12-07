using System;
using System.Collections.Generic;

class CubicPolynomial
{
    public double A3 { get; set; }
    public double A2 { get; set; }
    public double A1 { get; set; }
    public double A0 { get; set; }

    public CubicPolynomial(double a3, double a2, double a1, double a0)
    {
        A3 = a3;
        A2 = a2;
        A1 = a1;
        A0 = a0;
    }

    public double Evaluate(double x)
    {
        return A3 * Math.Pow(x, 3) + A2 * Math.Pow(x, 2) + A1 * x + A0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введіть початок відрізка a: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Введіть кінець відрізка b: ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("Введіть точність e: ");
        double e = double.Parse(Console.ReadLine());

        List<CubicPolynomial> polynomials = new List<CubicPolynomial>();

        bool continueInput = true;
        while (continueInput)
        {
            Console.WriteLine("Введіть коефіцієнти для нового кубічного многочлена:");
            Console.Write("a3: ");
            double a3 = double.Parse(Console.ReadLine());

            Console.Write("a2: ");
            double a2 = double.Parse(Console.ReadLine());

            Console.Write("a1: ");
            double a1 = double.Parse(Console.ReadLine());

            Console.Write("a0: ");
            double a0 = double.Parse(Console.ReadLine());

            polynomials.Add(new CubicPolynomial(a3, a2, a1, a0));

            Console.Write("Бажаєте ввести ще один кубічний многочлен? (Y/N): ");
            string input = Console.ReadLine();
            continueInput = input.Equals("Y", StringComparison.OrdinalIgnoreCase);
        }

        double minResult = double.MaxValue;
        CubicPolynomial minPolynomial = null;

        for (int i = 0; i < polynomials.Count; i++)
        {
            for (double x = a; x <= b; x += e)
            {
                double result = polynomials[i].Evaluate(x);
                if (result < minResult)
                {
                    minResult = result;
                    minPolynomial = polynomials[i];
                }
            }
        }

        Console.WriteLine("Мінімальне значення: " + minResult);
        Console.WriteLine("Многочлен, який приймає найменше мінімальне значення: " + $"{minPolynomial.A3}x^3 + {minPolynomial.A2}*x^2 + {minPolynomial.A1}*x + {minPolynomial.A0}");
    }
}
