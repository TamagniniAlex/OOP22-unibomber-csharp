#pragma warning disable CS8602
using System.Drawing;
/// disabled warning CS8602 because Components will never be null in this case
namespace UnibomberGame
{
    internal class CollisionComponent : AbstractComponent
    {
        private readonly bool isSolid;
        private bool isOver;
        private RectangleF hitbox;
        private readonly float x, y;
        private int width, height;
        private readonly Action<IEntity, IEntity> action;
        private const int TILE_SIZE = 48;
        private const int DEFAULT_TILES_WIDTH = 15;
        private const int DEFAULT_TILES_HEIGHT = 19;
        private const int G_TILES_WIDTH = TILE_SIZE * DEFAULT_TILES_WIDTH;
        private const int G_TILES_HEIGHT = TILE_SIZE * DEFAULT_TILES_HEIGHT;


        public override void Update()
        {
            hitbox.X = (int)(this.Entity.EntityPosition.GetX * TILE_SIZE);
            hitbox.Y = (int)(this.Entity.EntityPosition.GetY * TILE_SIZE);
            IsOutofField();
            ChangeBombOver();
            CheckCollisions();
        }

        public CollisionComponent(bool isSolid, bool isOver, int x, int y,
                                  Action<IEntity, IEntity> action)
        {
            this.isSolid = isSolid;
            this.isOver = isOver;
            this.x = (int)(x * TILE_SIZE);
            this.y = (int)(y * TILE_SIZE);
            this.action = action;
            Inithitbox();
        }

        public RectangleF Gethitbox()
        {
            return new RectangleF(hitbox.X, hitbox.Y, hitbox.Width, hitbox.Height);
        }

        public bool IsSolid()
        {
            return isSolid;
        }

        public bool IsOver()
        {
            return isOver;
        }

        public void SetOver(bool isOver)
        {
            this.isOver = isOver;
        }

        public void CheckCollisions()
        {
            IEntity? entity = this.Entity;
            if (entity.EntityType.Equals(Type.BOMBER) || entity.EntityType.Equals(Type.BOMB))
            {
                entity.Game.Entities
                    .Where(e => !e.Equals(entity))
                    .Where(e => hitbox.IntersectsWith(e.GetComponent<CollisionComponent>().hitbox))
                    .ToList()
                    .ForEach(e => action.Invoke(entity, e));
            }
        }

        private void IsOutofField()
        {
            IEntity? entity = this.Entity;
            Pair<float, float>? newPosition = null;
            if (entity.EntityType != Type.BOMB)
            {
                if (hitbox.X > (G_TILES_WIDTH - TILE_SIZE))
                {
                    newPosition = new Pair<float, float>((float)DEFAULT_TILES_WIDTH - 1, entity.EntityPosition.GetY);
                }
                else if (hitbox.X < 0)
                {
                    newPosition = new Pair<float, float>(0f, entity.EntityPosition.GetY);
                }
                else if (hitbox.Y > (G_TILES_HEIGHT - TILE_SIZE))
                {
                    newPosition = new Pair<float, float>(entity.EntityPosition.GetX, (float)DEFAULT_TILES_HEIGHT - 1);
                }
                else if (hitbox.Y < 0)
                {
                    newPosition = new Pair<float, float>(entity.EntityPosition.GetX, 0f);
                }
                if (newPosition != null)
                {
                    entity.EntityPosition = newPosition;

                }
            }
        }

        private void ChangeBombOver()
        {
            IEntity? player = this.Entity;
            if (player.EntityType.Equals(Type.BOMBER))
            {
                CollisionComponent? playerCollision = player.GetComponent<CollisionComponent>();
                player.Game.Entities
                    .Where(entity => entity.EntityType == Type.BOMB)
                    .Select(entity => entity.GetComponent<CollisionComponent>())
                    .Where(entity => entity != null && entity.IsOver())
                    .Where(entity => !playerCollision.hitbox.IntersectsWith(entity.hitbox))
                    .ToList()
                    .ForEach(entity => entity.isOver = false);
            }
        }

        private void Inithitbox()
        {
            width = (int)TILE_SIZE;
            height = width;
            hitbox = new RectangleF(x, y, width, height);
        }

    }
}
