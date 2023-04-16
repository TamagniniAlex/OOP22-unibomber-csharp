using ecs;

namespace UnibomberGame;
{
    public class ExplodeComponent : AbstractComponent
    {
        public int ExplodeFrames { get; set; }
        public int ExpiringFrames { get; set; }
        public bool IsExploding { get; set; }

        public ExplodeComponent()
        {
            ExplodeFrames = 0;
            ExpiringFrames = 0;
            IsExploding = false;
        }

        public override void Update()
        {
            if (ExpiringFrames == 90)
            {
                ExplodeFrames++;

            }
            else
                ExpiringFrames++;
        }
    }
}