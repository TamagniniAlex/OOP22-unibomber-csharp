namespace UnibomberGame
{
    public abstract class AbstractComponent : IComponent
    {
        protected IEntity? Entity { get; set; }

        public abstract void update();
    }
}