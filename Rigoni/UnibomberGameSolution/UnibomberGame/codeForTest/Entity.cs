using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace UnibomberGame
{
    public class Entity : IEntity
    {
        private readonly HashSet<IComponent> _components;

        private readonly List<IGame> _game;

        /// <inheritdoc />
        public Type EntityType { get; }

        /// <inheritdoc />
        public Pair<float, float> Position { get; set; }

        /// <inheritdoc />
        public float Speed { get; set; }

        public Entity(Pair<float, float> position, Type type, IGame game)
        {
            Position = new Pair<float, float>(position.x, position.y);
            EntityType = type;
            _components = new HashSet<IComponent>();
            _game = new List<IGame>();
            _game.Add(game);
            Speed = 0.3F;
        }

        /// <inheritdoc />
        public HashSet<IComponent> Components
        {
            get { return new HashSet<IComponent>(_components); }
        }

        /// <inheritdoc />
        public T? GetComponent<T>() where T : IComponent
        {
            return _components.OfType<T>().FirstOrDefault();
        }

        /// <inheritdoc />
        public IEntity AddComponent(AbstractComponent component)
        {
            component.Entity = this;
            _components.Add(component);
            return this;
        }

        /// <inheritdoc />
        public IGame Game
        {
            get { return _game[0]; }
        }
    }
}