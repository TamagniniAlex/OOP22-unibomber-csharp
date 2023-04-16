namespace UnibomberGame;
using ecs;

public interface IField
{
    Dictionary<Pair<int, int>, Pair<Type, IEntity>> Field { get; set; }

    void UpdateField();
}