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