namespace UnibomberGame
{
    public class Entity : IEntity
    {
        private readonly List<IComponent> _components;
        private float _speed;

        /// <summary>
        /// Constructor set default Entities settings.
        /// </summary>
        /// <param name="type">Entity type</param>
        public Entity(Type type)
        {
            EntityType = type;
            EntityPosition = new Pair<float, float>(0f, 0f);
            _components = new List<IComponent>();
            _speed = 0.3f;
        }
        /// <inheritdoc />
        public IGame Game { get; set; }
        /// <inheritdoc />
        public Type EntityType { get; set; }

        /// <inheritdoc />
        public Pair<float, float> EntityPosition { get; set; }

        /// <inheritdoc />
        public T? GetComponent<T>() where T : IComponent
        {
            return _components.OfType<T>().FirstOrDefault();
        }

        /// <inheritdoc />
        public Entity AddComponent(AbstractComponent component)
        {
            component.Entity = this;
            _components.Add(component);
            return this;
        }

        /// <inheritdoc />
        public float GetSpeed()
        {
            return _speed;
        }

        /// <inheritdoc />
        public void AddSpeed(float speed)
        {
            _speed += speed;
        }

    }

}
