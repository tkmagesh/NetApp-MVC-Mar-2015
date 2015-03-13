using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductsManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var productsCollection = new ProductsCollection();
            productsCollection.Add(new Product() {Id = 104, Name = "Pen", Cost = 12.00M, Units = 60, Category = 1});
            productsCollection.Add(new Product() { Id = 106, Name = "Zen", Cost = 42.00M, Units = 90, Category = 2 });
            productsCollection.Add(new Product() { Id = 103, Name = "Ken", Cost = 92.00M, Units = 50, Category = 1 });
            productsCollection.Add(new Product() { Id = 109, Name = "Den", Cost = 32.00M, Units = 30, Category = 2 });
            productsCollection.Add(new Product() { Id = 105, Name = "Len", Cost = 62.00M, Units = 60, Category = 1 });
            productsCollection.Add(new Product() { Id = 102, Name = "Ten", Cost = 22.00M, Units = 80, Category = 2 });

            Print("Default list", productsCollection);
            // public delegate int CompareProductDelegate(Product p1, Product p2);

            productsCollection.Sort(( p1, p2) => (int)(p1.Cost - p2.Cost));

            Print("Default sorting [by id]", productsCollection);
            Console.ReadLine();
        }

        
        private static void Print(string title, ProductsCollection productsCollection)
        {
            Console.WriteLine(title);
            for (var i = 0; i < productsCollection.Count; i++)
                Console.WriteLine(productsCollection.Get(i));
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    public abstract class ProductComparisons
    {
        public static CompareProductDelegate ById = (p1, p2) => (p1.Id - p2.Id);
        public static CompareProductDelegate ByCost = (p1, p2) => (int)(p1.Cost - p2.Cost);
        public static CompareProductDelegate ByUnits = (p1, p2) => (p1.Units - p2.Units);
    }
}
