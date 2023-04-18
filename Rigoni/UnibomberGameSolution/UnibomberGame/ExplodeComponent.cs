/// disabled warning CS8602 because Components will never be null in this case
#pragma warning disable CS8602
namespace UnibomberGame
{
    public class ExplodeComponent : AbstractComponent
    {
        public int ExplodeFrames { get; set; }
        public int ExpiringFrames { get; set; }
        public bool IsExploding { get; set; }
        private readonly Direction _dir = new Direction();
        //In the original project, the fields are constants
        //in the file Constants.java
        private const int EXPIRING_TIME = 90;
        private const int EXPLODE_DURATION = 9;

        public ExplodeComponent()
        {
            ExplodeFrames = 0;
            ExpiringFrames = 0;
            IsExploding = false;
        }

        /// <inheritdoc />
        public override void Update()
        {
            if (ExpiringFrames == EXPIRING_TIME)
            {
                ExplodeFrames++;
                IsExploding=true;
                if (ExplodeFrames < EXPLODE_DURATION)
                {
                    ExplodeEntities();
                } else if (!Entity.GetComponent<DestroyComponent>().IsDestroyed)
                {
                    Entity.GetComponent<DestroyComponent>().Destroy();
                }
            }
            else
            { 
                ExpiringFrames++;
            }
        }

        private void ExplodeEntities()
        {
           int bombRange = 1;
           int countPos;
           Pair<float, float> pos;
           IEntity entityOfPos;
           foreach (var dir in _dir.Directions())
           {
                countPos = 1;
                while (countPos <= bombRange)
                {
                    pos = new Pair<float, float>(Entity.Position.x + dir.x * countPos, 
                        Entity.Position.y + dir.y * countPos);
                    entityOfPos = SearchEntity(pos);
                    if (entityOfPos.EntityType != Type.AIR && entityOfPos.GetComponent<DestroyComponent>() != null)
                    {
                        entityOfPos.GetComponent<DestroyComponent>().Destroy();
                    }
                    countPos++;
                }
           }
        }

        private IEntity SearchEntity(Pair<float, float> pos)
        {
            foreach(IEntity e in Entity.Game.Entities)
            {
                if (e.Position.x == pos.x && e.Position.y == pos.y)
                {
                    return e;
                }
            }
            return new Entity(new Pair<float, float>(-1.0F, -1.0F), Type.AIR, Entity.Game);
        }
    }
}