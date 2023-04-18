namespace UnibomberGame
{
    public interface IEntity
    {
        /// <summary>
        /// The components of the entity.
        /// </summary>
        HashSet<IComponent> Components { get; }

        /// <summary>
        /// The position of the entity.
        /// </summary>
        Pair<float, float> Position { get; set; }

        /// <summary>
        /// A method to get the component searched (if it exists).
        /// </summary>
        T? GetComponent<T>() where T : IComponent;

        /// <summary>
        /// A method to add a component to the entity.
        /// </summary>
        IEntity AddComponent(AbstractComponent component);

        /// <summary>
        /// The type of the entity
        /// </summary>
        Type EntityType { get; }

        /// <summary>
        /// The game where is the entity.
        /// </summary>
        IGame Game { get; }

        /// <summary>
        /// The speed of the entity.
        /// </summary>
        float Speed { get; set; }
    }
}