using ecs;

public interface IEntityFactory
{
    IEntity MakePowerUp(Pair<float, float> position, PowerUpType powerUpType);

    IEntity MakeBomber(Pair<float, float> position, Type type);

    IEntity MakePlayable(Pair<float, float> position);

    IEntity MakeBot(Pair<float, float> position, int difficultyAI);

    IEntity MakeBomb(Pair<float, float> position, IEntity placer);

    IEntity MakeDestructibleWall(Pair<float, float> position);

    IEntity MakeIndestructibleWall(Pair<float, float> position);

    IEntity MakeRaisingWall(Pair<float, float> position);
}