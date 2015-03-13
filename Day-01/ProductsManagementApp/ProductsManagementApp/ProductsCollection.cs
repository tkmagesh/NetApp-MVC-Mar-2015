using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ProductsManagementApp
{
    public class MyCollection<T> : IEnumerable, IEnumerable<T>, IEnumerator<T>, IEnumerator
    {
        ArrayList list = new ArrayList();

        public int Count
        {
            get { return list.Count; }
        }

        public void Add(T item)
        {
            list.Add(item);
        }

        public T Get(int index)
        {
            return (T) list[index];
        }

      
        /*public int Min(FieldSelectorDelegate<T, int> fsd)
        {
            var result = int.MaxValue;
            foreach (var item in list)
            {
                var p = (T) item;
                var fieldValue = fsd(p);
                if (result > fieldValue)
                    result = fieldValue;
            }
            return result;
        }

        public decimal Min(FieldSelectorDelegate<T, decimal> dsd)
        {
            var result = decimal.MaxValue;
            foreach (var item in list)
            {
                var p = (T)item;
                var fieldValue = dsd(p);
                if (result > fieldValue)
                    result = fieldValue;
            }
            return result;
        }*/

        //Filter
        //Min (int)
        //Min (cost)
        //Max (int)
        //Sum (int)
        //GroupBy (int)
        //GroupBy (string)

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        private int _index = -1;
        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            ++_index;
            if (_index < list.Count) return true;
            Reset();
            return false;
        }

        public void Reset()
        {
            _index = -1;
        }

        public T Current
        {
            get { return (T) list[_index]; }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }
    }

    public delegate TResult FieldSelectorDelegate<in T, out TResult>(T item)  where TResult : IComparable;
    
    public delegate int IntFieldSelectorDelegate<T>(T p);

    public delegate decimal DecimalFieldSelectorDelegate<T>(T p);

    //public delegate int CompareProductDelegate(Product p1, Product p2);
    public delegate int CompareItemDelegate<T>(T p1, T p2);

    public delegate bool FilterItemDelegate<T>(T p);

    public interface IItemCompare<T>
    {
        int Compare(T p1, T p2);
        
    }

    public class ProductComparerById : IItemCompare<Product>
    {
        public int Compare(Product p1, Product p2)
        {
            if (p1.Id < p2.Id) return -1;
            if (p1.Id > p2.Id) return 1;
            return 0;
        }
    }
    public class ProductComparerByCost : IItemCompare<Product>
    {
        public int Compare(Product p1, Product p2)
        {
            if (p1.Cost < p2.Cost) return -1;
            if (p1.Cost > p2.Cost) return 1;
            return 0;
        }
    }
    public class ProductComparerByUnits : IItemCompare<Product>
    {
        public int Compare(Product p1, Product p2)
        {
            if (p1.Units < p2.Units) return -1;
            if (p1.Units > p2.Units) return 1;
            return 0;
        }
    }
}