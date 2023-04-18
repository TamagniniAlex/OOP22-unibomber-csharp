#pragma warning disable CS8602
using UnibomberGame;
/// disabled warning CS8602 because Components will never be null in this case
namespace UnibomberGame
{
    public class Extension
    {
        public static class Bomber
        {
            public static class Collision
            {
                private static Action<IEntity, IEntity> collide = (entity, e) =>
                {
                    if (e.EntityType.Equals(Type.POWERUP))
                    {
                        PowerUpType powerUpType = e.GetComponent<PowerUpComponent>().PowerUpType;
                        PowerUpHandlerComponent? powerUpHandlerComponent = entity.GetComponent<PowerUpHandlerComponent>();
                        powerUpHandlerComponent.AddPowerUp(powerUpType);
                    }
                    CollisionComponent? collision = e.GetComponent<CollisionComponent>();
                    if (collision.IsSolid() && !collision.IsOver())
                    {
                        Extension.CollisonWall(entity, e);
                    }
                };
            }
        }
        public static void CollisonWall(IEntity entity, IEntity e)
        {
            float thisX = (float)Math.Round(entity.EntityPosition.GetX);
            float thisY = (float)Math.Round(entity.EntityPosition.GetY);
            float eX = (float)Math.Round(e.EntityPosition.GetX);
            float eY = (float)Math.Round(e.EntityPosition.GetY);
            bool isOccupied = entity.Game.GetField()
                .Any(entry => entry.Key.Equals(new KeyValuePair<int, int>(
                    (int)Math.Round(thisX) + entity.GetComponent<MovementComponent>().Get().GetDirection().GetX(),
                    (int)Math.Round(thisY) + entity.GetComponent<MovementComponent>().Get().GetDirection().GetY()))));
            if (!isOccupied)
            {
                if (thisX != eX || thisY != eY)
                {
                    entity.EntityPosition = (new Pair<float, float>(thisX, thisY));
                }
            }
            else
            {
                if (thisX == eX && thisY != eY)
                {
                    entity.EntityPosition = (new Pair<float, float>(entity.EntityPosition.GetX, thisY));
                }
                else if (thisX != eX && thisY == eY)
                {
                    entity.EntityPosition = (new Pair<float, float>(thisX, entity.EntityPosition.GetY));
                }
            }
        }

    }
}
