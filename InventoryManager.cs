using System;
using System.Collections.Generic;

public class InventoryManager
{
    private List<Product> products = new List<Product>();
    private int nextId = 1;

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\nInventory Management System");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Update Stock");
            Console.WriteLine("3. View All Products");
            Console.WriteLine("4. Remove Products");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option (1-5): ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    UpdateStock();
                    break;
                case "3":
                    ViewProducts();
                    break;
                case "4":
                    RemoveProduct();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    private void AddProduct()
    {
        Console.Write("Enter product name: ");
        string name = Console.ReadLine();

        Console.Write("Enter product price: ");
        decimal price = decimal.Parse(Console.ReadLine());

        Console.Write("Enter initial stock quantity: ");
        int quantity = int.Parse(Console.ReadLine());

        Product product = new Product
        {
            Id = nextId++,
            Name = name,
            Price = price,
            Quantity = quantity
        };

        products.Add(product);
        Console.WriteLine("Product added successfully!");
    }

    private void UpdateStock()
    {
        Console.Write("Enter product ID: ");
        int id = int.Parse(Console.ReadLine());

        Product product = products.Find(p => p.Id == id);
        if (product == null)
        {
            Console.WriteLine("Product not found.");
            return;
        }

        Console.Write("Enter quantity to add (use negative number to subtract): ");
        int change = int.Parse(Console.ReadLine());

        if (product.Quantity + change < 0)
        {
            Console.WriteLine("Not enough stock.");
            return;
        }

        product.Quantity += change;
        Console.WriteLine("Stock updated successfully!");

    }

    private void ViewProducts()
    {
        Console.WriteLine("\nProduct List:");
        foreach (var product in products)
        {
            Console.WriteLine($"ID: {product.Id} | Name: {product.Name} | Price: {product.Price} | Quantity: {product.Quantity}");
        }
    }

    private void RemoveProduct()
    {
        Console.Write("Enter product ID to remove: ");
        int id = int.Parse(Console.ReadLine());

        Product product = products.Find(p => p.Id == id);
        if (product != null)
        {
            products.Remove(product);
            Console.WriteLine("Product removed.");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

}