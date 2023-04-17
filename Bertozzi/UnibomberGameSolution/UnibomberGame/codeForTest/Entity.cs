using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace UnibomberGame
{
    public class Entity : IEntity
    {
        private readonly HashSet<IComponent> _components;

        private readonly List<IGame> _game;

        public Type Type { get; }

        public Pair<float, float> Position { get; set; }

        public float Speed { get; set; }

        public Entity(Pair<float, float> position, Type type, IGame game)
        {
            Position = new Pair<float, float>(position.x, position.y);
            Type = type;
            _components = new HashSet<IComponent>();
            _game = new List<IGame>();
            _game.Add(game);
            Speed = 0.3F;
        }

        public HashSet<IComponent> Components
        {
            get { return new HashSet<IComponent>(_components); }
        }

        public T? GetComponent<T>() where T : IComponent
        {
            return _components.OfType<T>().FirstOrDefault();
        }

        public IEntity AddComponent(AbstractComponent component)
        {
            component.Entity = this;
            _components.Add(component);
            return this;
        }

        public IGame Game
        {
            get { return _game[0]; }
        }
        public IEntity getType()
        {
            return Type;
        }
    }
}