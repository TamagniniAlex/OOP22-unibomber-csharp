namespace UnibomberGame
{
    public interface IEntity
    {
        Type EntityType { get; set; }

        Pair<float, float> EntityPosition { get; set; }

        T? GetComponent<T>() where T : IComponent;

        Entity AddComponent(AbstractComponent component);

        float GetSpeed();

        void AddSpeed(float speedValue);
        
    }
}
