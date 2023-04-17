namespace UnibomberGame
{
    public interface IGame
    {
        /// <summary>
        /// Return list of all Entity in game.
        /// </summary>
        List<IEntity> Entities { get; }

        /// <summary>
        /// Add entity into the game.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void AddEntity<T>(T entity) where T : IEntity;

    }

}
