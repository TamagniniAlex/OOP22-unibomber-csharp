using System;
using UnibomberGame;

namespace UnibomberGame
{
    public class EntityFactory : IEntityFactory
    {
        private List<IGame> _game;

        public EntityFactory(IGame game)
        {
            this._game = new List<IGame>();
            this._game.Add(game);
        }

        public IEntity MakeBomb(Pair<float, float> position)
        {
            return new Entity(position, Type.BOMB, _game[0])
                            .AddComponent(new ExplodeComponent())
                            .AddComponent(new DestroyComponent());
        }

        public IEntity MakeDestructibleWall(Pair<float, float> position)
        {
            return new Entity(position, Type.DESTRUCTIBLE_WALL, _game[0])
                            .AddComponent(new DestroyComponent());
        }

        public IEntity MakeIndestructibleWall(Pair<float, float> position)
        {
            return new Entity(position, Type.INDESTRUCTIBLE_WALL, _game[0]);
        }
    }
}