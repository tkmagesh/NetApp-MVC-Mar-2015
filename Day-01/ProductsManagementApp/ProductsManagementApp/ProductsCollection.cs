using System.Collections;

namespace ProductsManagementApp
{
    public class ProductsCollection
    {
        ArrayList list = new ArrayList();

        public int Count
        {
            get { return list.Count; }
        }

        public void Add(Product product)
        {
            list.Add(product);
        }

        public Product Get(int index)
        {
            return (Product) list[index];
        }

        public void Sort(IProductCompare productComparer)
        {
            for(var i=0; i<list.Count-1; i++)
                for (var j = i + 1; j < list.Count; j++)
                {
                    var left = (Product) list[i];
                    var right = (Product) list[j];
                    if (productComparer.Compare(left, right) > 0)
                    {
                        list[i] = list[j];
                        list[j] = left;
                    }
                }
        }

        public void Sort(CompareProductDelegate compareProduct)
        {
            for (var i = 0; i < list.Count - 1; i++)
                for (var j = i + 1; j < list.Count; j++)
                {
                    var left = (Product)list[i];
                    var right = (Product)list[j];
                    if (compareProduct(left, right) > 0)
                    {
                        list[i] = list[j];
                        list[j] = left;
                    }
                }
        }

        //Filter
        //Min (int)
        //Min (cost)
        //Max (int)
        //Sum (int)
        //GroupBy (int)
        //GroupBy (string)

    }

    public delegate int CompareProductDelegate(Product p1, Product p2);
    
    public interface IProductCompare
    {
        int Compare(Product p1, Product p2);
        
    }

    public class ProductComparerById : IProductCompare
    {
        public int Compare(Product p1, Product p2)
        {
            if (p1.Id < p2.Id) return -1;
            if (p1.Id > p2.Id) return 1;
            return 0;
        }
    }
    public class ProductComparerByCost : IProductCompare
    {
        public int Compare(Product p1, Product p2)
        {
            if (p1.Cost < p2.Cost) return -1;
            if (p1.Cost > p2.Cost) return 1;
            return 0;
        }
    }
    public class ProductComparerByUnits : IProductCompare
    {
        public int Compare(Product p1, Product p2)
        {
            if (p1.Units < p2.Units) return -1;
            if (p1.Units > p2.Units) return 1;
            return 0;
        }
    }
}