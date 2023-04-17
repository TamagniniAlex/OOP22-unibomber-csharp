using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace UnibomberGame
{
    public class Entity : IEntity
    {
        private readonly List<IComponent> _components;
        private Pair<float, float> Position { get; set; } 
        private float _speed;

        /// <summary>
        /// Constructor set default Entities settings.
        /// </summary>
        /// <param name="type">Entity type</param>
        /// <param name="position">Entity position</param>
        public Entity(Type type, Pair<float, float> position)
        {
            EntityType = type;
            EntityPosition = new Pair<float, float>(0f, 0f);
            Position = position;   
            _components = new List<IComponent>();
            _speed = 0.3f;
        }

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
        /// <inheritdoc />
        public void addPosition(Pair<float,float> position)
        {
            Position = new Pair<float, float>(Position.GetX + position.GetX, Position.GetY + position.GetY);
        }

    }

}
