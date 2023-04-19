namespace UnibomberGame
{
    internal class Utilities
    {
        /// <summary>
        /// true if the value is contained between min and max.
        /// </summary>
        /// <param name="value">initial value</param>
        /// <param name="min">minimum value</param>
        /// <param name="max">maximum value</param>
        public static bool IsBetween(int value, int min, int max)
        {
            return value >= min && value < max;
        }

    }
}
