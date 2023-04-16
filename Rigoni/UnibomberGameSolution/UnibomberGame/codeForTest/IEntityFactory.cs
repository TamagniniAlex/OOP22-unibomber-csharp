namespace UnibomberGame
{
    public interface IEntityFactory
    {
        IEntity MakeBomb(Pair<float, float> position);

        IEntity MakeDestructibleWall(Pair<float, float> position);

        IEntity MakeIndestructibleWall(Pair<float, float> position);
    }
}
