namespace UnibomberGame
{
    public interface IField
    {
        /// <summary>
        /// The field of the game.
        /// </summary>
        Dictionary<Pair<int, int>, Pair<Type, IEntity>> GameField { get; }

        /// <summary>
        /// A method to update the field.
        /// </summary>
        void UpdateField();
    }
}
