using System;
using System.Collections.Generic;

public class Product
{
    public string Name { get; }
    public decimal Price { get; }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}

public class Person
{
    private string name;
    private decimal money;
    private List<Product> bag;

    public Person(string name, decimal money)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be empty.");
        }

        if (money < 0)
        {
            throw new ArgumentException("Money cannot be negative.");
        }

        this.name = name;
        this.money = money;
        this.bag = new List<Product>();
    }

    public string Name => name;

    public void BuyProduct(Product product)
    {
        if (money >= product.Price)
        {
            money -= product.Price;
            bag.Add(product);
            Console.WriteLine($"{Name} bought {product.Name}");
        }
        else
        {
            Console.WriteLine($"{Name} can't afford {product.Name}");
        }
    }

    public void ShowBag()
    {
        if (bag.Count == 0)
        {
            Console.WriteLine($"{Name} - Nothing bought");
        }
        else
        {
            Console.WriteLine($"{Name} - {string.Join(", ", bag)}");
        }
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            Person pesho = new Person("Pesho", 11);
            Product bread = new Product("Bread", 10);
            Product milk = new Product("Milk", 2);

            pesho.BuyProduct(bread);
            pesho.BuyProduct(milk);
            pesho.BuyProduct(milk); // Buying again

            pesho.ShowBag();

            Person mimi = new Person("Mimi", 0);
            mimi.BuyProduct(new Product("Kafence", 2));

            Person jeko = new Person("Jeko", -3); // This will throw an exception
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
