namespace UtilsCSharp
{
    public static class ArrayUtils
    {
        /// <summary>
        /// Gets the count of every value in the array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns>A dictionary of the item counts.</returns>
        public static Dictionary<T, int> Counts<T>(this T[] array) where T : notnull
        {
            Dictionary<T, int> result = new();
    
            foreach (T item in array)
            {
                if (!result.TryAdd(item, 1))
                {
                    ++result[item];
                }
            }
    
            return result;
        }

        /// <summary>
        /// Makes a group of the items with the minimum sepcified value
        /// </summary>
        /// <typeparam name="TInput"/>
        /// <typeparam name="TResult"/>
        /// <param name="input"></param>
        /// <param name="selector"></param>
        /// <returns>The items in the enumerable that have the lowest specified value</returns>
        /// <exception cref="ArgumentNullException"/>
        public static IEnumerable<TInput> MinGroup<TInput, TResult>(this IEnumerable<TInput> input, Func<TInput, TResult> selector)
            where TResult : IComparable // If you want to get the lowest values in a number array, remove the selector argument
        {
            // Some check, you may not need it.
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }
        
            List<TInput> result = new();
            TResult min = selector(input.FirstOrDefault()!); // Rename max if you want a MaxGroup function
        
            for (int i = 1; i < input.Count(); ++i)
            {
                int compared = selector(input.ElementAt(i)).CompareTo(min);
        
                // If you want a MaxGroup function replace '<' by '>'
                if (compared <= 0)
                {
                    if (compared < 0)
                    {
                        result.Clear();
                    }
        
                    result.Add(input.ElementAt(i));
                }
            }
        
            return result;
        }
    }
}
