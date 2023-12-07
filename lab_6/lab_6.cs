using System;

abstract class Figure
{
    protected double x1, y1, x2, y2;

    public Figure(double x1, double y1, double x2, double y2)
    {
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
    }

    public abstract void DisplayDimensions();

    public abstract bool ContainsPoint(double x, double y);
}

class Rectangle : Figure
{
    public Rectangle(double x1, double y1, double x2, double y2)
        : base(x1, y1, x2, y2)
    {
    }

    public override void DisplayDimensions()
    {
        Console.WriteLine($"Прямокутник: Вершина 1 ({x1}, {y1}), Вершина 2 ({x2}, {y2})");
    }

    public override bool ContainsPoint(double x, double y)
    {
        double minX = Math.Min(x1, x2);
        double maxX = Math.Max(x1, x2);
        double minY = Math.Min(y1, y2);
        double maxY = Math.Max(y1, y2);

        return x >= minX && x <= maxX && y >= minY && y <= maxY;
    }
}

class Parallelepiped : Figure
{
    private double z1, z2;

    public Parallelepiped(double x1, double y1, double z1, double x2, double y2, double z2)
        : base(x1, y1, x2, y2)
    {
        this.z1 = z1;
        this.z2 = z2;
    }

    public override void DisplayDimensions()
    {
        Console.WriteLine($"Паралелепіпед: Вершина 1 ({x1}, {y1}, {z1}), Вершина 2 ({x2}, {y2}, {z2})");
    }

    public override bool ContainsPoint(double x, double y)
    {
        double minX = Math.Min(x1, x2);
        double maxX = Math.Max(x1, x2);
        double minY = Math.Min(y1, y2);
        double maxY = Math.Max(y1, y2);

        return x >= minX && x <= maxX && y >= minY && y <= maxY;
    }

    public bool ContainsPoint(double x, double y, double z)
    {
        double minX = Math.Min(x1, x2);
        double maxX = Math.Max(x1, x2);
        double minY = Math.Min(y1, y2);
        double maxY = Math.Max(y1, y2);
        double minZ = Math.Min(z1, z2);
        double maxZ = Math.Max(z1, z2);

        return x >= minX && x <= maxX && y >= minY && y <= maxY && z >= minZ && z <= maxZ;
    }
}

class Program
{
    static void Main()
    {
        double x1 = 1, y1 = 2, z1 = 0, x2 = 3, y2 = 4, z2 = 5;
        Figure obj;

        Console.Write("Введіть 1 для створення прямокутника або будь яке інше ціле число для створення паралелепіпеда: ");
        Int32.TryParse(Console.ReadLine(), out int choose);

        if (choose == 1)
        {
            obj = new Rectangle(x1, y1, x2, y2);
        }
        else
        {
            obj = new Parallelepiped(x1, y1, z1, x2, y2, z2);
        }

        obj.DisplayDimensions();

        if (obj is Parallelepiped parallelepipedObj)
        {
            Console.WriteLine($"Введіть координати точки для {(choose == 1 ? "прямокутника" : "паралелепіпеда")} (x, y, z):");
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double z = double.Parse(Console.ReadLine());

            if (parallelepipedObj.ContainsPoint(x, y, z))
            {
                Console.WriteLine($"Точка належить {(choose == 1 ? "прямокутнику" : "паралелепіпеду")}.");
            }
            else
            {
                Console.WriteLine($"Точка НЕ належить {(choose == 1 ? "прямокутнику" : "паралелепіпеду")}.");
            }
        }
        else if (obj is Rectangle rectangleObj)
        {
            Console.WriteLine($"Введіть координати точки для {(choose == 1 ? "прямокутника" : "паралелепіпеда")} (x, y):");
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            if (rectangleObj.ContainsPoint(x, y))
            {
                Console.WriteLine($"Точка належить {(choose == 1 ? "прямокутнику" : "паралелепіпеду")}.");
            }
            else
            {
                Console.WriteLine($"Точка НЕ належить {(choose == 1 ? "прямокутнику" : "паралелепіпеду")}.");
            }
        }
    }
}
