namespace UtilsCSharp
{
    /* NEEDS REWORK:
     * It's better to use two dictionaries than to use this class on both memory and optimization.
     * The best thing to do would probably be to rewrite the Dictionary class but allowing two way translation.
     * On another note that would probably take A LOT of lines and copy and pasting it would be a bit bad.
     * Maybe making an efficient version and an unefficient version could be the solution?
     */
    /// <summary>
    /// Dictionary but can be used both ways around.
    /// </summary>
    /// <typeparam name="T1"/>
    /// <typeparam name="T2"/>
    public class TwoWayDictionary<T1, T2> where T1 : notnull where T2 : notnull
    {
        private readonly Dictionary<T1, T2> _forwards;
        private readonly Dictionary<T2, T1> _backwards;

        /// <summary>
        /// Create a new bidirectional dictionary.
        /// </summary>
        /// <param name="firstTypeValues"/>
        /// <param name="secondTypeValues"/>
        /// <exception cref="InvalidOperationException"/>
        public TwoWayDictionary((T1, T2)[] values)
        {
            if (typeof(T1) == typeof(T2))
                throw new InvalidOperationException("Value types cannot be the same!");

            _forwards = values.ToDictionary(k => k.Item1, v => v.Item2);
            _backwards = values.ToDictionary(k => k.Item2, v => v.Item1);
        }
        
        /// <summary>
        /// Adds a translation in the bidirectional dictionary.
        /// </summary>
        /// <param name="t1"/>
        /// <param name="t2"/>
        public void Add(T1 t1, T2 t2)
        {
            _forwards.Add(t1, t2);
            _backwards.Add(t2, t1);
        }

        /// <summary>
        /// Removes translation from bidirectional dictionary.
        /// </summary>
        /// <typeparam name="T"/>
        /// <param name="value"/>
        public void Remove<T>(T value) where T : T1, T2
        {
            _forwards.Remove(value);
            _backwards.Remove(value);
        }

        /// <summary>
        /// Clears the bidirectional dictionary.
        /// </summary>
        public void Clear()
        {
            _forwards.Clear();
            _backwards.Clear();
        }

        /// <summary>
        /// The nummber of translations in the bidirectional dictionary.
        /// </summary>
        public int Count => _forwards.Count;
        
        /// <summary>
        /// Get the equivalent value in of another type.
        /// </summary>
        /// <param name="value"/>
        /// <returns>The matching second type value of the first type value.</returns>
        /// <exception cref="KeyNotFoundException"/>
        public T2 this[T1 value] => _forwards[value];

        /// <summary>
        /// Get the equivalent value in of another type.
        /// </summary>
        /// <param name="value"/>
        /// <returns>The matching first type value of the second type value.</returns>
        /// <exception cref="KeyNotFoundException"/>
        public T1 this[T2 value] => _backwards[value];
    }
}
