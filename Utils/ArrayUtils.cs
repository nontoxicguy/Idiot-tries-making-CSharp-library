namespace UtilsCSharp
{
    public static class ArrayUtils
    {
        /* 3 dimensions? DIY
         * I refuse to make other functions like that because this library is mostly for copy-pasting.
         * If this library is in your depedencies, even the simplest app is going to take a bunch of memory.
         */
        /// <summary>
        /// The same as System.Linq's ElementAtOrDefault but for two dimensional arrays.
        /// </summary>
        /// <param name="XIndex"></param>
        /// <param name="YIndex"></param>
        /// <returns>The object at the spcified index. If it doesn't exist, default.</returns>
        public static T? ElementAtOrDefault<T>(T[,] array, int XIndex, int YIndex) =>
            XIndex >= array.GetLowerBound(0) && XIndex < array.GetUpperBound(0) && YIndex >= array.GetLowerBound(1) && YIndex < array.GetUpperBound(1) ? array[XIndex, YIndex] : default;

        /// <summary>
        /// Adds a value to an array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="valueToAdd"></param>
        /// <returns>An array but with a new value.</returns>
        public static T[] Add<T>(T[] array, T valueToAdd)
        {
            T[] newArray = new T[array.Length + 1];

            array.CopyTo(newArray, 0);
            newArray[array.Length] = valueToAdd;

            return newArray;
        }
    }
}