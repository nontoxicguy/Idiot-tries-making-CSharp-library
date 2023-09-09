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
    }
}
