using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace ProductsManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var productsCollection = new MyCollection<Product>();
            productsCollection.Add(new Product() {Id = 104, Name = "Pen", Cost = 12.00M, Units = 60, Category = 1});
            productsCollection.Add(new Product() { Id = 106, Name = "Zen", Cost = 42.00M, Units = 90, Category = 2 });
            productsCollection.Add(new Product() { Id = 103, Name = "Ken", Cost = 92.00M, Units = 50, Category = 1 });
            productsCollection.Add(new Product() { Id = 109, Name = "Den", Cost = 32.00M, Units = 30, Category = 2 });
            productsCollection.Add(new Product() { Id = 105, Name = "Len", Cost = 62.00M, Units = 60, Category = 1 });
            productsCollection.Add(new Product() { Id = 102, Name = "Ten", Cost = 22.00M, Units = 80, Category = 2 });

            Print("Default list", productsCollection);
            // public delegate int CompareProductDelegate(Product p1, Product p2);

            //productsCollection.Sort(ProductComparisons.ById);

            Print("Default sorting [by id]", productsCollection);

            var costlyProducts = productsCollection.Filter(p => p.Cost > 50);
            Print("All costly products", costlyProducts);

            Console.WriteLine("Minimum cost = {0}", productsCollection.Min(p => p.Cost));
            Console.WriteLine("Minimum id = {0}", productsCollection.Min(p => p.Id));

            var x = productsCollection.Filter(p => p.Cost > 50).Min(p => p.Cost);
            x = MyUtils.Min(MyUtils.Filter(productsCollection, p => p.Cost > 50), p => p.Cost);
            Console.ReadLine();
        }

        
        private static void Print(string title, IEnumerable<Product> productsCollection)
        {
            Console.WriteLine(title);
            foreach (var product in productsCollection)
            {
                Console.WriteLine(product.FormatForPrint());
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    public interface IPrintable
    {
        
    }

    public abstract class ProductComparisons
    {
        public static Func<Product,Product, int> ById = (p1, p2) => (p1.Id - p2.Id);
        public static Func<Product, Product, int> ByCost = (p1, p2) => (int)(p1.Cost - p2.Cost);
        public static Func<Product, Product, int> ByUnits = (p1, p2) => (p1.Units - p2.Units);
    }
}
