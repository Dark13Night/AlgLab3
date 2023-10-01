# AlgLab3
Лабораторная работа №3
«Перегрузка операторов, преобразование типов»

# Цели работы:
Научиться синтаксису и принципам перегрузки операторов языка C#.

# Задание№1
Создайте структуру Vector с тремя полями X, Y и Z. 
Для созданной структуры переопределите операторы сложения векторов, умножения векторов, умножения вектора на число, а также логические операторы. Для логических операторов используйте сравнение по длине от начала координат.

```
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
```

# Задание№2
Создайте класс Car со свойствами Name, Engine, MaxSpeed. Переопределите оператор ToString() таким образом, чтобы он возвращал название машины(Name). Реализуйте возможность сравнения объектов Car, реализовав интерфейс IEquatable<Car>. 
Создайте класс CarsCatalog, содержащий коллекцию машин – элементов типа Car и переопределите для него индексатор таким образом, чтобы он возвращал строку с названием машины и типом двигателя.

```
using System;
using System.Collections.Generic;

public class Car : IEquatable<Car>
{
    public string Name { get; set; }
    public string Engine { get; set; }
    public int MaxSpeed { get; set; }

    public Car(string name, string engine, int maxSpeed)
    {
        Name = name;
        Engine = engine;
        MaxSpeed = maxSpeed;
    }

    public override string ToString()
    {
        return Name;
    }

    public bool Equals(Car other)
    {
        if (other == null)
            return false;

        return Name == other.Name && Engine == other.Engine && MaxSpeed == other.MaxSpeed;
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;

        Car car = obj as Car;
        if (car == null)
            return false;
        else
            return Equals(car);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode() ^ Engine.GetHashCode() ^ MaxSpeed.GetHashCode();
    }

    public static bool operator ==(Car car1, Car car2)
    {
        if (ReferenceEquals(car1, car2))
            return true;

        if (ReferenceEquals(car1, null) || ReferenceEquals(car2, null))
            return false;

        return car1.Equals(car2);
    }

    public static bool operator !=(Car car1, Car car2)
    {
        return !(car1 == car2);
    }
}

public class CarsCatalog
{
    private List<Car> cars;

    public CarsCatalog()
    {
        cars = new List<Car>();
    }

    public Car this[int index]
    {
        get { return cars[index]; }
        set { cars[index] = value; }
    }

    public void AddCar(Car car)
    {
        cars.Add(car);
    }

    public void RemoveCar(Car car)
    {
        cars.Remove(car);
    }

    public override string ToString()
    {
        string result = "";
        foreach (Car car in cars)
        {
            result += $"{car.Name} - {car.Engine}\n";
        }
        return result;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Car car1 = new Car("Ford", "V6", 200);
        Car car2 = new Car("Tesla", "Electric", 250);
        Car car3 = new Car("BMW", "V8", 300);
        Car car4 = new Car("BMW", "V8", 300);

        Console.WriteLine(car1); // Output: Ford

        Console.WriteLine(car1 == car2); // Output: False
        Console.WriteLine(car1 == car3); // Output: False
        Console.WriteLine(car3 == car4); // Output: True

        Console.WriteLine(car1 != car2); // Output: True
        Console.WriteLine(car1 != car3); // Output: True
        Console.WriteLine(car3 != car4); // Output: False

        CarsCatalog catalog = new CarsCatalog();
        catalog.AddCar(car1);
        catalog.AddCar(car2);
        catalog.AddCar(car3);

        Console.WriteLine(catalog); // Output: Ford - V6, Tesla - Electric, BMW - V8
    }
}
```

# Задание№3
Создайте базовый класс Currency со свойством Value. Создайте 3 производных от Currency класса – CurrencyUSD, CurrencyEUR и CurrencyRUB со свойствами, соответствующими обменному курсу. В каждом из производных классов переопределите операторы преобразования типов таким образом, чтобы можно было явно или неявно преобразовать одну валюту в другую по курсу, заданному пользователем при запуске программы.
```
using System;

class Currency
{
    public decimal Value { get; set; }
}

class CurrencyUSD : Currency
{
    public static implicit operator CurrencyEUR(CurrencyUSD usd)
    {
        decimal conversionRate = 0.85m; // курс USD к EUR
        CurrencyEUR eur = new CurrencyEUR();
        eur.Value = usd.Value * conversionRate;
        return eur;
    }

    public static implicit operator CurrencyRUB(CurrencyUSD usd)
    {
        decimal conversionRate = 72.52m; // курс USD к RUB
        CurrencyRUB rub = new CurrencyRUB();
        rub.Value = usd.Value * conversionRate;
        return rub;
    }
}

class CurrencyEUR : Currency
{
    public static implicit operator CurrencyUSD(CurrencyEUR eur)
    {
        decimal conversionRate = 1.18m; // курс EUR к USD
        CurrencyUSD usd = new CurrencyUSD();
        usd.Value = eur.Value * conversionRate;
        return usd;
    }

    public static implicit operator CurrencyRUB(CurrencyEUR eur)
    {
        decimal conversionRate = 86.36m; // курс EUR к RUB
        CurrencyRUB rub = new CurrencyRUB();
        rub.Value = eur.Value * conversionRate;
        return rub;
    }
}

class CurrencyRUB : Currency
{
    public static implicit operator CurrencyUSD(CurrencyRUB rub)
    {
        decimal conversionRate = 0.014m; // курс RUB к USD
        CurrencyUSD usd = new CurrencyUSD();
        usd.Value = rub.Value * conversionRate;
        return usd;
    }

    public static implicit operator CurrencyEUR(CurrencyRUB rub)
    {
        decimal conversionRate = 0.012m; // курс RUB к EUR
        CurrencyEUR eur = new CurrencyEUR();
        eur.Value = rub.Value * conversionRate;
        return eur;
    }
}

class Program
{
    static void Main(string[] args)
    {
        CurrencyUSD usd = new CurrencyUSD();
        usd.Value = 100;

        CurrencyEUR eur = usd; // неявное преобразование из USD в EUR
        Console.WriteLine(eur.Value); // выведет 85

        CurrencyRUB rub = (CurrencyRUB)eur; // явное преобразование из EUR в RUB
        Console.WriteLine(rub.Value); // выведет 7338.6
    }
}
```


