namespace UnibomberGame
{
    public abstract class AbstractComponent : IComponent
    {
        //In the Java project, this field is protected because it is visible in all the package.
        //To traduce in C#, I have to set public the field for the visibility.
        /// <summary>
        /// The entity linked to the component.
        /// </summary>
        public IEntity? Entity { get; set; }

        /// <inheritdoc />
        public abstract void Update();
    }
}