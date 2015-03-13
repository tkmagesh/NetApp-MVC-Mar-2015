using System;
using System.Collections.Generic;

namespace ProductsManagementApp
{
    public static class MyUtils
    {
        public static string FormatForPrint( this IPrintable obj)
        {
            var t = obj.GetType();
            var result = string.Empty;
            var propertyInfos = t.GetProperties();
            foreach (var propertyInfo in propertyInfos)
            {
                var value = propertyInfo.GetValue(obj, null);
                result += value.ToString() + "\t";
            }
            return result;
        }

       /* public static void Sort<T>(this IEnumerable<T> list, IItemCompare<T> itemComparer)
        {
            for (var i = 0; i < list.Count - 1; i++)
                for (var j = i + 1; j < list.Count; j++)
                {
                    var left = (T)list[i];
                    var right = (T)list[j];
                    if (itemComparer.Compare(left, right) > 0)
                    {
                        list[i] = list[j];
                        list[j] = left;
                    }
                }
        }

        //public void Sort(CompareItemDelegate<T> compareItem)
        public void Sort(Func<T, T, int> compareItem)
        {
            for (var i = 0; i < list.Count - 1; i++)
                for (var j = i + 1; j < list.Count; j++)
                {
                    var left = (T)list[i];
                    var right = (T)list[j];
                    if (compareItem(left, right) > 0)
                    {
                        list[i] = list[j];
                        list[j] = left;
                    }
                }
        }*/

        public static IEnumerable<T> Filter<T>( this IEnumerable<T> list, Func<T, bool> fp)
        {
            var result = new MyCollection<T>();
            foreach (var item in list)
            {
                var p = (T)item;
                if (fp(p))
                    result.Add(p);
            }
            return result;
        }

        /*public static TResult Min<T, TResult>(this IEnumerable<T> list, Func<T, TResult> fsd) where TResult : IComparable
        {
            var result = fsd((T)(list[0]));
            foreach (var item in list)
            {
                var p = (T)item;
                var fieldValue = fsd(p);
                if (result.CompareTo(fieldValue) > 0)
                    result = fieldValue;
            }
            return result;
        }*/

        public static int Min<T>(this IEnumerable<T> list, Func<T, int> fsd)
        {
            var result = int.MaxValue;
            foreach (var item in list)
            {
                var p = (T)item;
                var fieldValue = fsd(p);
                if (result > fieldValue)
                    result = fieldValue;
            }
            return result;
        }
        public static decimal Min<T>(this IEnumerable<T> list, Func<T, decimal> fsd)
        {
            var result = decimal.MaxValue;
            foreach (var item in list)
            {
                var p = (T)item;
                var fieldValue = fsd(p);
                if (result > fieldValue)
                    result = fieldValue;
            }
            return result;
        }

    }
}