namespace UnibomberGame
{
    public interface IGame
    {
        /// <summary>
        /// The list of the entities.
        /// </summary>
        List<IEntity> Entities { get; }

        /// <summary>
        /// A method to add the entity to the game.
        /// </summary>
        void AddEntity<T>(T entity) where T : IEntity;

        /// <summary>
        /// A method to remove an entity from the game.
        /// </summary>
        void RemoveEntity(IEntity entity);

        /// <summary>
        /// The dimensions of the field.
        /// </summary>
        Pair<int, int> GameDimensions { get; }

        /// <summary>
        /// The factory of entities.
        /// </summary>
        IEntityFactory EntityFactory { get; }

        /// <summary>
        /// The field.
        /// </summary>
        IField Field { get; }
    }
}