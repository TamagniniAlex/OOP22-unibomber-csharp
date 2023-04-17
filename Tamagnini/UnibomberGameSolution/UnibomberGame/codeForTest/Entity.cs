namespace UnibomberGame
{
    public class Entity : IEntity
    {
        private readonly List<IComponent> _components;
        private float _speed;

        public Entity(Type type)
        {
            EntityType = type;
            EntityPosition = new Pair<float, float>(0f, 0f);
            _components = new List<IComponent>();
            _speed = 0.3f;
        }

        public Type EntityType { get; set; }

        public Pair<float, float> EntityPosition { get; set; }

        public T? GetComponent<T>() where T : IComponent
        {
            return _components.OfType<T>().FirstOrDefault();
        }

        public Entity AddComponent(AbstractComponent component)
        {
            component.Entity = this;
            _components.Add(component);
            return this;
        }

        public float GetSpeed()
        {
            return _speed;
        }

        public void AddSpeed(float speed)
        {
            _speed += speed;
        }

    }
}
