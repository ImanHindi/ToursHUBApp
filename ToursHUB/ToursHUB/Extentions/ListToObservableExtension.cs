using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ToursHUB.Extensions
{
    public static class ListToObservableExtension
    {
        public static ObservableCollection<T> ListToObservableCollection<T>(this List<T> source)
        {
            ObservableCollection<T> collection = new ObservableCollection<T>();

            foreach (T item in source)
            {
                collection.Add(item);
            }

            return collection;

        }
    }
}