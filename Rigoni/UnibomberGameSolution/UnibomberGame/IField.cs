namespace UnibomberGame
{
    public interface IField
    {
        Dictionary<Pair<int, int>, Pair<Type, IEntity>> GameField { get; set; }

        void UpdateField();
    }
}
