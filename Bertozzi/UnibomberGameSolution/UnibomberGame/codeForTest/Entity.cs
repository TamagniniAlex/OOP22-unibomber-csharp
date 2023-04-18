namespace UnibomberGame
{
    public class Entity : IEntity
    {
        private readonly HashSet<IComponent> _components;
        private float _speed;

        /// <summary>
        /// Constructor set default Entities settings.
        /// </summary>
        /// <param name="type">Entity type</param>
        public Entity(Pair<float, float> position, Type type, IGame game)
        {
            EntityPosition = new Pair<float, float>(position.GetX, position.GetY);
            EntityType = type;
            _components = new HashSet<IComponent>();
            Game = game;
            _speed = 0.3F;
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
