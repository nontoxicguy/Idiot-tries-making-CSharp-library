namespace UtilsCSharp.TypeUtils
{
    public static class StringUtils
    {
        /// <summary>
        /// Removes all instances of the specified character in the string.
        /// </summary>
        /// <param name="str"/>
        /// <param name="toRemove"/>
        /// <returns>A string without the specified character.</returns>
        public static string RemoveChar(this string str, char toRemove)
        {
            for (int i = str.Length - 1; i >= 0; --i)
            {
                if (str[i] == toRemove)
                {
                    str = str.Remove(i, 1);
                }
            }

            return str;
        }

        /// <summary>
        /// Gets the count of every value in the string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns>A dictionary of the item counts.</returns>
        public static Dictionary<char, int> Counts(this string str)
        {
            Dictionary<char, int> result = new();

            foreach (char character in str)
            {
                if (!result.TryAdd(character, 1))
                {
                    ++result[character];
                }
            }

            return result;
        }
    }
}
