
namespace UnibomberGame
{
    public class EntityFactory : IEntityFactory
    {
        private readonly IGame _game;

        public EntityFactory(IGame game)
        {
            this._game = game;
        }

        /// <inheritdoc />
        public IEntity MakeBomb(Pair<float, float> position)
        {
            return new Entity(position, Type.BOMB, _game)
                .AddComponent(new CollisionComponent(true, true, (int)Math.Round(position.GetX),
                     (int)Math.Round(position.GetY), null));
        }

        /// <inheritdoc />
        public IEntity MakeDestructibleWall(Pair<float, float> position)
        {
            return new Entity(position, Type.DESTRUCTIBLE_WALL, _game)
                 .AddComponent(new CollisionComponent(true, false, (int)Math.Round(position.GetX),
                                                (int)Math.Round(position.GetY), null));
        }

        /// <inheritdoc />
        public IEntity MakeIndestructibleWall(Pair<float, float> position)
        {
            return new Entity(position, Type.INDESTRUCTIBLE_WALL, _game)
                .AddComponent(new CollisionComponent(true, false, (int)Math.Round(position.GetX),
                                                (int)Math.Round(position.GetY), null));
        }
        /// <inheritdoc />
        public IEntity MakePowerUp(Pair<float, float> position, PowerUpType type)
        {
            return new Entity(position, Type.POWERUP, _game)
                .AddComponent(new PowerUpComponent(type))
                                .AddComponent(new CollisionComponent(true, true, (int)Math.Round(position.GetX),
                                                (int)Math.Round(position.GetY), null));
        }
        /// <inheritdoc />
        public IEntity MakePlayable(Pair<float, float> position)
        {
            return new Entity(position, Type.PLAYER, _game)
                .AddComponent(new MovementComponent())
                .AddComponent(new PowerUpHandlerComponent(1, 1, new List<PowerUpType>()))
                .AddComponent(new CollisionComponent(false, true, (int)Math.Round(position.GetX),
                                                (int)Math.Round(position.GetY), Extension.Bomber.Collision.GetCollide()));
        }
    }
}