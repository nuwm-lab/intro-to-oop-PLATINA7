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

    public virtual void DisplayDimensions()
    {
        Console.WriteLine($"Прямокутник: Вершина 1 ({x1}, {y1}), Вершина 2 ({x2}, {y2})");
    }

    public virtual bool ContainsPoint(double x, double y, double z)
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

    public override void DisplayDimensions()
    {
        base.DisplayDimensions();
        Console.WriteLine($"Паралелепіпед: Вершина 1 ({x1}, {y1}, {z1}), Вершина 2 ({x2}, {y2}, {z2})");
    }

    public override bool ContainsPoint(double x, double y, double z)
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
        Rectangle obj;

        Console.Write("Введіть 1 для створення прямокутника або будь яке інше ціле число для створення паралелепіпеда: ");
        Int32.TryParse(Console.ReadLine(), out int choose);

        if (choose == 1)
        {
            double z = 0;
            obj = new Rectangle(x1, y1, x2, y2);

            obj.DisplayDimensions();

            Console.WriteLine("Введіть координати точки для прямокутника (x, y):");

            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            if (obj.ContainsPoint(x, y, z))
            {
                Console.WriteLine("Точка належить прямокутнку.");
            }
            else
            {
                Console.WriteLine("Точка НЕ належить прямокутнку.");
            }
        }
        else
        {
            obj = new Parallelepiped(x1, y1, z1, x2, y2, z2);

            obj.DisplayDimensions();

            Console.WriteLine("Введіть координати точки для паралелепіпеда (x, y, z):");

            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double z = double.Parse(Console.ReadLine());

            if (obj.ContainsPoint(x, y, z))
            {
                Console.WriteLine("Точка належить паралелепіпеду.");
            }
            else
            {
                Console.WriteLine("Точка НЕ належить паралелепіпеду.");
            }
        }
    }
}
