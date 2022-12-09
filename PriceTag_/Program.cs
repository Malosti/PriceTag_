using PriceTag.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace PriceTag
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();

            Console.Write("Enter the number of products: ");
            short n = short.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Product #{i} data:");
                Console.Write("Common, used or imported (c/u/i) ? ");
                char option = char.Parse(Console.ReadLine().ToLower());

                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                switch (option)
                {
                    case 'c':
                        list.Add(new Product(name, price));
                        break;

                    case 'u':
                        Console.Write("Manufacture date (DD/MM/YYYY): ");
                        DateTime date = DateTime.Parse(Console.ReadLine());
                        list.Add(new UsedProduct(name, price, date));
                        break;

                    case 'i':
                        Console.Write("Customs fee: ");
                        double fee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        list.Add(new ImportedProduct(name, price, fee));
                        break;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Price Tags:");
            foreach (Product item in list)
            {
                Console.WriteLine(item.PriceTag());
            }
        }
    }
}
