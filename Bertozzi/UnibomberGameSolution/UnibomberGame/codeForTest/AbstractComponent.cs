namespace UnibomberGame
{
    public abstract class AbstractComponent : IComponent
    {
        //In the Java project, this field is protected because it is visible in all the package.
        //To traduce in C#, I have to set public the field for the visibility.
        public IEntity? Entity { get; set; }

        public abstract void Update();
    }
}