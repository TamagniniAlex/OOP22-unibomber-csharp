namespace ecs
{
    public abstract class AbstractComponent : IComponent
    {
        protected IEntity? Entity { get; set; }

        public abstract void Update();
    }
}