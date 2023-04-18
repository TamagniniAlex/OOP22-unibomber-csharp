using UnibomberGame;
using System.Collections.Generic;

namespace UnibomberGame
{
    public class Game : IGame
    {
        /// <inheritdoc />
        public List<IEntity> Entities { get; }
        /// <inheritdoc />
        public IEntityFactory EntityFactory { get; }
        /// <inheritdoc />
        public IField Field { get; }
        
        private readonly int _rows;
        private readonly int _columns;

        public Game(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;
            Entities = new List<IEntity>();
            EntityFactory = new EntityFactory(this);
            Field = new Field(this);
        }

        /// <inheritdoc />
        public void AddEntity<T>(T entity) where T : IEntity => Entities.Add(entity);

        /// <inheritdoc />
        public void RemoveEntity(IEntity entity) => Entities.Remove(entity);

        /// <inheritdoc />
        public Pair<int, int> GameDimensions 
        { 
            get { return new Pair<int, int>(_rows, _columns); } 
        }
    }
}