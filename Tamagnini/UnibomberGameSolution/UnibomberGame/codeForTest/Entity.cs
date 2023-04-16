namespace UnibomberGame
{
    public class Entity : IEntity
    {
        private readonly List<IComponent> components = new List<IComponent>();
        private Pair<float, float>? position;
        private float speed;

        public T? GetComponent<T>() where T : IComponent
        {
            return components.OfType<T>().FirstOrDefault();
        }

        public Entity AddComponent(IComponent component)
        {
            this.components.Add(component);
            return this;
        }

        public Pair<float, float> Position
        {
            get
            {
                return this.position != null ? new Pair<float, float>(this.position.x, this.position.y) : new Pair<float, float>(0, 0);
            }
            set => this.position = new Pair<float, float>(value.x, value.y);
        }

        public float GetSpeed()
        {
            return this.speed;
        }

        public void AddSpeed(float speedValue)
        {
            this.speed += speedValue;
        }
    }
}
