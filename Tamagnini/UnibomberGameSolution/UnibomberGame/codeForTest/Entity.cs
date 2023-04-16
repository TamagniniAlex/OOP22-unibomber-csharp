namespace UnibomberGame
{
    public class Entity : IEntity
    {
        private readonly List<IComponent> components = new List<IComponent>();
        private float speed;

        public T? GetComponent<T>() where T : IComponent
        {
            return components.OfType<T>().FirstOrDefault();
        }

        public Entity AddComponent(IComponent component)
        {
            this.components.Add(component);
            return this;
        }

        public float GetSpeed()
        {
            return this.speed;
        }

        public void AddSpeed(float speedValue)
        {
            this.speed += speedValue;
        }
    }
}
