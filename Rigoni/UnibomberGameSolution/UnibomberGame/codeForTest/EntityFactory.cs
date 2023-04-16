using System;
using UnibomberGame;

namespace ecs;

public class EntityFactory : IEntityFactory
{
    private List<IGame> _game;

    public EntityFactoryImpl(IGame game)
    {
        this._game = new List<IGame>();
        this._game.add(game);
    }

    public  Entity MakeBomb(Pair<Float, Float> position)
    {
        return new Entity(_game.get(0), position, Type.BOMB)
                        .addComponent(new ExplodeComponent())
                        .addComponent(new DestroyComponent());
    }

    
    public  Entity MakeDestructibleWall(Pair<Float, Float> position)
    {
        return new Entity(_game.get(0), position, Type.DESTRUCTIBLE_WALL)
                        .addComponent(new DestroyComponent());
    }

    
    public  Entity MakeIndestructibleWall(Pair<Float, Float> position)
    {
        return new Entity(_game.get(0), position, Type.INDESTRUCTIBLE_WALL);
    }
}