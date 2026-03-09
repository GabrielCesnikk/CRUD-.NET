using CrudProducts;
using CrudProducts.Data;
using CrudProducts.Models;
using CrudProducts.Repositories;

var db = new Database();
db.InitializeBank();
var repo = new ProductRepository();

while (true)
{
    Console.Clear();
    Console.WriteLine("=== CRUD of Products ===");
    Console.WriteLine("1 - List Product");
    Console.WriteLine("2 - Add Product");
    Console.WriteLine("3 - Update Product");
    Console.WriteLine("4 - Remove Product");
    Console.WriteLine("0 - Sair");
    Console.Write("\nEscolha: ");
    string option = Console.ReadLine();

    if (option == "1")
    {
        var products = repo.AllList();
        Console.Clear();
        if (products.Count == 0)
        {
            Console.WriteLine("No products found.");
        }
        else
        {
            foreach (var product in products)
            {
                Console.WriteLine($"[{product.Id}] {product.Name} - R$ {product.Price:F2}");
            }
        }
    }
    else if (option == "2")
    {
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Price: ");
        double price = double.Parse(Console.ReadLine());
        repo.Add(new Product { Name = name, Price = price });
        Console.WriteLine("Product Added!");
    }
    else if (option == "3")
    {

        Console.Write("Product Id for update: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("New Name: ");
        string name = Console.ReadLine();
        Console.Write("New Price: ");
        double price = double.Parse(Console.ReadLine());
        repo.Update(new Product { Id = id, Name = name, Price = price });
        Console.WriteLine("Product updated!");
    }
    else if (option == "4")
    {
    
        var products = repo.AllList();

        if (products.Count == 0)
        {
            Console.WriteLine("No products found.");
        }
        else
        {
            foreach (var product in products)
            {
                Console.WriteLine($"[{product.Id}] {product.Name} - R$ {product.Price:F2}");
            }

            Console.Write("\nProduct Id to remove: ");
            int id = int.Parse(Console.ReadLine());

            bool removed = repo.Remove(id);
            if (removed)
            {
                Console.WriteLine("Product removed!");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
    }
    else if (option == "0")
    {
        break;
    }

    else
    {
        Console.WriteLine("Invalid option. Please try again.");
    }

    Console.WriteLine("\nPress any key to continue...");
    Console.ReadLine();
}