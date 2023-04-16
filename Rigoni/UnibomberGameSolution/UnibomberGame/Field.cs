using ecs;

namespace UnibomberGame;

public class Field : IField
{
    public Dictionary<Pair<int, int>, Pair<Type, IEntity>> Field {  get; set; }
    private readonly List<IGame> _game;

    public Field(IGame game)
    {
        this.Field = new Dictionary<Pair<int, int>, Pair<Type, IEntity>>;
        this._game = new List<IGame>();
        this._game.Add(game);
    }

    public void UpdateField()
    {
        int row;
        int col;
        List<IEntity> fieldEntities = new List<IEntity>;
        foreach (var entity in _game.Get(0).Entities)
        {
            if (entity.Type != Type.BOMBER)
            {
                fieldEntities.Add(entity);
            }
        }
        Field.Clear();
        foreach (var entity in fieldEntities)
        {
            if (entity.Type != Type.BOMB)
            {
                row = Math.Round(entity.Position.x);
                col = Math.Round(entity.Position.y);
                Field.Add(new Pair<int, int>(row, col));
            }
        }
    }
}