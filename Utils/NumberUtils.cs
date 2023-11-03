namespace UtilsCSharp
{
    public static class NumberUtils
    {
        /// <summary>
        /// Turns number into an ienumerable of digits.
        /// </summary>
        /// <param name="num"></param>
        /// <returns>A byte ienumerable representing the digits of the number</returns>
        public static IEnumerable<byte> GetDigits(int num)
        {
            num = Math.Abs(num);
            while (num != 0)
            {
                yield return num % 10;
                num /= 10;
            }
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
