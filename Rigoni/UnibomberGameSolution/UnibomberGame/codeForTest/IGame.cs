using UnibomberGame;

namespace ecs
{
    public interface IGame
    {
        IList<IEntity> Entities { get; }

        void AddEntity<T>(T entity) where T : IEntity;

        void RemoveEntity(IEntity entity);

        Pair<int, int> GameDimensions { get; }

        IEntityFactory EntityFactory { get; }

        IField Field { get; }
    }
}