namespace UnibomberGame
{
    public interface IEntity
    {
        Entity AddComponent(IComponent component);

        T? GetComponent<T>() where T : IComponent;

        Pair<float, float> Position { get; set; }

        float GetSpeed();

        void AddSpeed(float speedValue);
    }
}