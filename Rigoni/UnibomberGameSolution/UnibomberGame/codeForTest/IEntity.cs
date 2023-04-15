namespace ecs
{
    public interface IEntity
    {
        ISet<IComponent> Components { get; }

        Pair<float, float> Position { get; set; }

        T? GetComponent<T>() where T : IComponent;

        IEntity AddComponent(IComponent component);

        Type Type { get; }

        IGame Game { get; }

        float Speed { get; set; }
    }
}