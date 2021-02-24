using System;
using System.Collections.Generic;

namespace AMS.Mobile.Extensions
{
    public static class CollectionExtensions
    {
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            foreach (var i in items)
            {
                collection.Add(i);
            }
        }

        /// <summary>
        /// Clears the current collection and replaces it with the specified collection.
        /// </summary>
        public static void ReplaceRange<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (collection.Count > 0)
            {
                collection.Clear();
            }
            collection.AddRange(items);
        }
    }
}