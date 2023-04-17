namespace UnibomberGame
{
    public class Game : IGame
    {
        public List<IEntity> Entities { get; }

        public Game() => Entities = new List<IEntity>();

        public void AddEntity<T>(T entity) where T : IEntity
        {
            Entities.Add(entity);
        }

    }
}
