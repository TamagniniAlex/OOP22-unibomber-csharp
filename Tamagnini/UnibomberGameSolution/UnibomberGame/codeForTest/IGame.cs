namespace UnibomberGame
{
    public interface IGame
    {
        List<IEntity> Entities { get; }

        void AddEntity<T>(T entity) where T : IEntity;

        void RemoveEntity(IEntity entity);

    }
}
