namespace UnibomberGame
{
    public interface IEntity
    {
        HashSet<IComponent> Components { get; }

        Pair<float, float> Position { get; set; }

        T? GetComponent<T>() where T : IComponent;

        IEntity AddComponent(AbstractComponent component);

        Type Type { get; }

        IGame Game { get; }

        float Speed { get; set; }
    }
}