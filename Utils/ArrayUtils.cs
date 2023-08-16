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
    }
}
