using System;
struct Vector
{
    public double X;
    public double Y;
    public double Z;
    public static Vector operator +(Vector v1, Vector v2)
    {
        return new Vector { X = v1.X + v2.X, Y = v1.Y + v2.Y, Z = v1.Z + v2.Z };
    }

    public static Vector operator *(Vector v1, Vector v2)
    {
        return new Vector { X = v1.X * v2.X, Y = v1.Y * v2.Y, Z = v1.Z * v2.Z };
    }

    public static Vector operator *(Vector v, double scalar)
    {
        return new Vector { X = v.X * scalar, Y = v.Y * scalar, Z = v.Z * scalar };
    }
    public static bool operator >(Vector v1, Vector v2)
    {
        double v1Length = Math.Sqrt(v1.X * v1.X + v1.Y * v1.Y + v1.Z * v1.Z);
        double v2Length = Math.Sqrt(v2.X * v2.X + v2.Y * v2.Y + v2.Z * v2.Z);
        return v1Length > v2Length;
    }

    public static bool operator <(Vector v1, Vector v2)
    {
        double v1Length = Math.Sqrt(v1.X * v1.X + v1.Y * v1.Y + v1.Z * v1.Z);
        double v2Length = Math.Sqrt(v2.X * v2.X + v2.Y * v2.Y + v2.Z * v2.Z);
        return v1Length < v2Length;
    }
    public override string ToString()
    {
        return string.Format("({0}, {1}, {2})", X, Y, Z);
    }

}
class Program
{
    static void Main()
    {
        Vector v1 = new Vector();
        Console.WriteLine("v1 coordinates:");
        v1.X = double.Parse(Console.ReadLine());
        v1.Y = double.Parse(Console.ReadLine());
        v1.Z = double.Parse(Console.ReadLine());

        Console.WriteLine("v2 coordinates:");
        Vector v2 = new Vector();
        v2.X = double.Parse(Console.ReadLine());
        v2.Y = double.Parse(Console.ReadLine());
        v2.Z = double.Parse(Console.ReadLine());

        Vector sum = v1 + v2;
        Console.WriteLine("v1+v2={0}", sum);
        Vector product = v1 * v2;
        Console.WriteLine("v1*v2={0}", product);
        Vector multiplied = v1 * 2;
        Console.WriteLine("v1*2={0}", multiplied);

        bool v1IsGreater = v1 > v2;
        Console.WriteLine("v1>v2={0}", v1IsGreater);
        bool v1IsLess = v1 < v2;
        Console.WriteLine("v1<v2={0}", v1IsLess);
    }
}