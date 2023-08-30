namespace UtilsCSharp
{
    public static class ArrayUtils
    {
        /// <summary>
        /// Adds a value to an array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="valueToAdd"></param>
        /// <returns>An array but with a new value.</returns>
        public static T[] Add<T>(this T[] array, T valueToAdd)
        {
            T[] newArray = new T[array.Length + 1];

            array.CopyTo(newArray, 0);
            newArray[array.Length] = valueToAdd;

            return newArray;
        }

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
