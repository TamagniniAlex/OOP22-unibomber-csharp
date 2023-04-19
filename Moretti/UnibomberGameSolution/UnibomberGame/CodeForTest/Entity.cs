using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace UnibomberGame
{
    public class Entity : IEntity
    {
        private readonly List<IComponent> _components;
        private double _speed;

        /// <inheritdoc />
        public Type EntityType { get; set; }
        /// <inheritdoc />
        public IGame Game { get; set; }

        /// <inheritdoc />
        public Pair<double, double> Position { get; set; }

        /// <summary>
        /// Constructor set default Entities settings.
        /// </summary>
        /// <param name="type">Entity type</param>
        /// <param name="position">Entity position</param>
        public Entity(Type type, Pair<double, double> position)
        {
            EntityType = type;
            Position = position;   
            _components = new List<IComponent>();
            _speed = 0.3f;
            Game = new Game();
        }

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
        public double GetSpeed()
        {
            return _speed;
        }

        /// <inheritdoc />
        public void AddSpeed(double speed)
        {
            _speed += speed;
        }
        /// <inheritdoc />
        public void addPosition(Pair<double, double> position)
        {
            Position = new Pair<double, double>(Position.GetX + position.GetX, Position.GetY + position.GetY);
        }

    }

}
