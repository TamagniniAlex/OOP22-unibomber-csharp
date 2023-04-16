namespace UnibomberGame
{
    public interface IEntity
    {
        Entity AddComponent(IComponent component);

        T? GetComponent<T>() where T : IComponent;

        float GetSpeed();

        void AddSpeed(float speedValue);
    }
}