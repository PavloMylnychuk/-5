using System;

public class Chicken
{
    private string name;
    private int age;

    public Chicken(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty.");
            }
            name = value;
        }
    }

    public int Age
    {
        get => age;
        private set
        {
            if (value < 0 || value > 15)
            {
                throw new ArgumentException("Age should be between 0 and 15.");
            }
            age = value;
        }
    }

    public string ProductPerDay => $"{Name} (age {Age}) can produce {CalculateProductPerDay()} eggs per day.";

    private int CalculateProductPerDay()
    {
        return 1;
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            Chicken chicken = new Chicken("Mara", 10);
            Console.WriteLine(chicken.ProductPerDay);

        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
