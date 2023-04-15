namespace ecs
{
    public interface IGame
    {
        IList<IEntity> Entities { get; }

        void AddEntity<T>(T entity) where T : IEntity;

        bool IsContained(int keyCode);

        void ClearKeysPressed();

        void RemoveEntity(IEntity entity);

        Pair<int, int> GameDimensions { get; }

        IEntityFactory EntityFactory { get; }

        //IField Field { get; }

        void UpdateTimesUp();
    }
}