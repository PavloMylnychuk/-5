using System;
using System.Collections.Generic;

public class Dough
{
    private string flourType;
    private string bakingTechnique;
    private int weight;

    public Dough(string flourType, string bakingTechnique, int weight)
    {
        FlourType = flourType;
        BakingTechnique = bakingTechnique;
        Weight = weight;
    }

    public string FlourType
    {
        get => flourType;
        private set
        {
            if (value != "White" && value != "Wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            flourType = value;
        }
    }

    public string BakingTechnique
    {
        get => bakingTechnique;
        private set
        {
            if (value != "Crispy" && value != "Chewy" && value != "Homemade")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            bakingTechnique = value;
        }
    }

    public int Weight
    {
        get => weight;
        private set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            weight = value;
        }
    }

    public double Calories => (2 * Weight) * GetFlourModifier() * GetBakingModifier();

    private double GetFlourModifier()
    {
        return FlourType == "White" ? 1.5 : 1.0;
    }

    private double GetBakingModifier()
    {
        return BakingTechnique == "Crispy" ? 0.9 : BakingTechnique == "Chewy" ? 1.1 : 1.0;
    }
}

public class Topping
{
    private string type;
    private int weight;

    public Topping(string type, int weight)
    {
        Type = type;
        Weight = weight;
    }

    public string Type
    {
        get => type;
        private set
        {
            if (value != "Meat" && value != "Veggies" && value != "Cheese" && value != "Sauce")
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            type = value;
        }
    }

    public int Weight
    {
        get => weight;
        private set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{Type} weight should be in the range [1..50].");
            }
            weight = value;
        }
    }

    public double Calories => (2 * Weight) * GetTypeModifier();

    private double GetTypeModifier()
    {
        return type == "Meat" ? 1.2 : type == "Veggies" ? 0.8 : type == "Cheese" ? 1.1 : 0.9;
    }
}

public class Pizza
{
    private string name;
    private Dough dough;
    private List<Topping> toppings;

    public Pizza(string name)
    {
        Name = name;
        toppings = new List<Topping>();
    }

    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 characters.");
            }
            name = value;
        }
    }

    public Dough Dough
    {
        get => dough;
        set
        {
            dough = value;
        }
    }

    public void AddTopping(Topping topping)
    {
        if (toppings.Count >= 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
        toppings.Add(topping);
    }

    public double TotalCalories => dough.Calories + toppings.Sum(t => t.Calories);
}

public class Program
{
    public static void Main()
    {
        try
        {
            Pizza pizza = new Pizza("Meatless");
            pizza.Dough = new Dough("Wholegrain", "Crispy", 100);
            pizza.AddTopping(new Topping("Veggies", 50));
            pizza.AddTopping(new Topping("Cheese", 50)); // This should be fine

            Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories} Calories.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
