namespace UnibomberGame
{
    public class Field : IField
    {
        public Dictionary<Pair<int, int>, Pair<Type, IEntity>> GameField {  get; set; }
        private readonly List<IGame> _game;

        public Field(IGame game)
        {
            this.GameField = new Dictionary<Pair<int, int>, Pair<Type, IEntity>>();
            this._game = new List<IGame>();
            this._game.Add(game);
        }

        public void UpdateField()
        {
            int row;
            int col;
            List<IEntity> fieldEntities = new List<IEntity>();
            foreach (var entity in _game[0].Entities)
            {
                if (entity.Type != Type.BOMBER)
                {
                    fieldEntities.Add(entity);
                }
            }
            GameField.Clear();
            foreach (var entity in fieldEntities)
            {
                if (entity.Type != Type.BOMB)
                {
                    row = (int) entity.Position.x;
                    col = (int) entity.Position.y;
                    GameField.Add(new Pair<int, int>(row, col), new Pair<Type, IEntity>(entity.Type, entity));
                }
            }
        }
    }
}
