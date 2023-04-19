namespace UnibomberGame
{
    internal class Utilities
    {
        /// <summary>
        /// true if the value is contained between min and max.
        /// </summary>
        /// <param name="type">Entity type</param>
        /// <param name="position">Entity position</param>
        public static bool IsBetween(int value, int min, int max)
        {
            return value >= min && value < max;
        }

    }
}
