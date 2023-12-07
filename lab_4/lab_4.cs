using System;

class Rectangle
{
    protected double x1, y1, x2, y2;

    public Rectangle(double x1, double y1, double x2, double y2)
    {
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
    }

    public void DisplayDimensions()
    {
        Console.WriteLine($"Прямокутник: Вершина 1 ({x1}, {y1}), Вершина 2 ({x2}, {y2})");
    }

    public bool ContainsPoint(double x, double y)
    {
        double minX = Math.Min(x1, x2);
        double maxX = Math.Max(x1, x2);
        double minY = Math.Min(y1, y2);
        double maxY = Math.Max(y1, y2);

        return x >= minX && x <= maxX && y >= minY && y <= maxY;
    }
}

class Parallelepiped : Rectangle
{
    private double z1, z2;

    public Parallelepiped(double x1, double y1, double z1, double x2, double y2, double z2)
        : base(x1, y1, x2, y2)
    {
        this.z1 = z1;
        this.z2 = z2;
    }

    public new void DisplayDimensions()
    {
        base.DisplayDimensions();
        Console.WriteLine($"Паралелепіпед: Вершина 1 ({x1}, {y1}, {z1}), Вершина 2 ({x2}, {y2}, {z2})");
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
        double x1, y1, z1, x2, y2, z2;
        Console.WriteLine("Введіть послідовно точки x1, y1, x2, y2 (вершини прямокутника):");
        x1 = double.Parse(Console.ReadLine());
        y1 = double.Parse(Console.ReadLine());
        x2 = double.Parse(Console.ReadLine());
        y2 = double.Parse(Console.ReadLine());
        Rectangle rectangle = new Rectangle(x1, y1, x2, y2);

        Console.WriteLine("Введіть додатково точки z1 і z2:");
        z1 = double.Parse(Console.ReadLine());
        z2 = double.Parse(Console.ReadLine());
        Parallelepiped parallelepiped = new Parallelepiped(x1, y1, x2, y2, z1, z2);

        Console.WriteLine("Введіть координати точки для прямокутника (x, y):");
        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());

        if (rectangle.ContainsPoint(x, y))
        {
            Console.WriteLine("Точка належить прямокутнку.");
        }
        else
        {
            Console.WriteLine("Точка НЕ належить прямокутнку.");
        }

        Console.WriteLine("Введіть координати точки для паралелепіпеда (x, y, z):");
        x = double.Parse(Console.ReadLine());
        y = double.Parse(Console.ReadLine());
        double z = double.Parse(Console.ReadLine());

        if (parallelepiped.ContainsPoint(x, y, z))
        {
            Console.WriteLine("Точка належить паралелепіпеду.");
        }
        else
        {
            Console.WriteLine("Точка НЕ належить паралелепіпеду.");
        }
    }
}
