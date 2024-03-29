namespace UnibomberGame
{
    public interface IEntity
    {
        /// <summary>
        /// Set / Get game.
        /// </summary>
        IGame Game { get; set; }
        /// <summary>
        /// Set / Get entity type.
        /// </summary>
        Type EntityType { get; set; }

        /// <summary>
        /// Set / Get entity position.
        /// </summary>
        Pair<float, float> EntityPosition { get; set; }

        /// <summary>
        /// Get Entity component.
        /// </summary>
        /// <typeparam name="T">component class</typeparam>
        /// <returns>component</returns>
        T? GetComponent<T>() where T : IComponent;

        /// <summary>
        /// Add component to Entity.
        /// </summary>
        /// <param name="component">component to add</param>
        /// <returns>entity</returns>
        Entity AddComponent(AbstractComponent component);

        /// <summary>
        /// Return entity speed.
        /// </summary>
        /// <returns>speed</returns>
        float GetSpeed();

        /// <summary>
        /// Add speed to Entity.
        /// </summary>
        /// <param name="speedValue">value to add</param>
        void AddSpeed(float speedValue);

    }

}
