namespace UnibomberGame
{
    public class Game : IGame
    {
        /// <summary>
        /// Constructor generate instance of Entities.
        /// </summary>
        public Game() => Entities = new List<IEntity>();

        /// <inheritdoc />
        public List<IEntity> Entities { get; }

        /// <inheritdoc />
        public void AddEntity<T>(T entity) where T : IEntity
        {
            Entities.Add(entity);
        }

    }

}
