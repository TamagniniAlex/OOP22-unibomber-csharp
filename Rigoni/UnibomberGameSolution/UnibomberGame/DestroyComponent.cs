/// disabled warning CS8602 because Components will never be null in this case
#pragma warning disable CS8602
namespace UnibomberGame
{
    public class DestroyComponent : AbstractComponent
    {
        public bool IsDestroyed { get; set; }
        public int DestroyedFrames { get; set; }
        public int DestroyFramesPerType { get; set; }

        public DestroyComponent()
        {
            IsDestroyed = false;
            DestroyedFrames = 0;
            DestroyFramesPerType = -1;
        }

        public override void Update()
        {
            if (DestroyFramesPerType == -1)
            {
                //In this part, in the original project,
                //the variable is setted by a map of constants
                switch (Entity.EntityType)
                {
                    case Type.DESTRUCTIBLE_WALL:
                        DestroyFramesPerType = 15;
                        break;
                    case Type.BOMBER:
                        DestroyFramesPerType = 70;
                        break;
                    default:
                        DestroyFramesPerType = 0;
                        break;
                }
            }
            if (IsDestroyed)
            {
                DestroyedFrames++;
                if (DestroyedFrames >= DestroyFramesPerType)
                { 
                    Entity.Game.RemoveEntity(Entity);
                }
            }
        }

        public void Destroy() => IsDestroyed = true;
    }
}