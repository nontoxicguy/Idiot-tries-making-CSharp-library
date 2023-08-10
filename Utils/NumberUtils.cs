namespace UtilsCSharp
{
    public static class NumberUtils
    {
        /// <summary>
        /// Turns number into array of digits.
        /// </summary>
        /// <param name="num"></param>
        /// <returns>A byte array representing the digits of the number.</returns>
        public static int[] GetDigits(this int num)
        {
            int[] result = new int[(int)Math.Floor(Math.Log10(num) + 1)];

            for (int i = result.Length - 1; i >= 0; --i)
            {
                result[i] = num % 10;
                num /= 10;
            }

            return result;
        }

        /// <summary>
        /// Decomposes the given number into prime numbers.
        /// </summary>
        /// <param name="num"></param>
        /// <returns>An array reprsenting the primes making the given number.</returns>
        public static int[] PrimeFactors(this int num)
        {
            List<int> primes = new();

            for (int i = 2; i < num && IsPrime(i); ++i)
            {
                while (num % i == 0)
                {
                    primes.Add(i);
                    num /= i;
                }
            }

            return primes.ToArray();
        }

        /// <summary>
        /// Checks if number is prime.
        /// </summary>
        /// <param name="num"></param>
        /// <returns>True if the given number is prime, else false.</returns>
        public static bool IsPrime(this int num)
        {
            for (int i = 2; i < num / 2; ++i)
                if (num % i == 0)
                    return false;

            return true;
        }
    }
}
