namespace UnibomberGame
{
    public interface IEntityFactory
    {
        /// <summary>
        /// A method to create a bomb.
        /// </summary>
        IEntity MakeBomb(Pair<float, float> position);

        /// <summary>
        /// A method to create a destructible wall.
        /// </summary>
        IEntity MakeDestructibleWall(Pair<float, float> position);

        /// <summary>
        /// A method to create a indestructible wall.
        /// </summary>
        IEntity MakeIndestructibleWall(Pair<float, float> position);

        /// <summary>
        /// A method to create a player.
        /// </summary>
        IEntity MakePlayable(Pair<float, float> position);
        /// <summary>
        /// A method to create a power up.
        /// </summary>
        IEntity MakePowerUp(Pair<float, float> position, PowerUpType type);
    }
}
