namespace UnibomberGame
{
    public abstract class AbstractComponent : IComponent
    {
        /// <summary>
        /// Set / Get Entity object.
        /// </summary>
        public IEntity? _Entity { get; set; }

        /// <inheritdoc />
        public abstract void Update();

    }

}
