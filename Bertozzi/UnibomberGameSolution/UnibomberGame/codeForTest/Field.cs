namespace UnibomberGame
{
    public class Field : IField
    {
        /// <inheritdoc />
        public Dictionary<Pair<int, int>, Pair<Type, IEntity>> GameField {  get; }
        
        private readonly List<IGame> _game;

        public Field(IGame game)
        {
            this.GameField = new Dictionary<Pair<int, int>, Pair<Type, IEntity>>();
            this._game = new List<IGame>();
            this._game.Add(game);
        }

        /// <inheritdoc />
        public void UpdateField()
        {
            int row;
            int col;
            List<IEntity> fieldEntities = new List<IEntity>();
            foreach (var entity in _game[0].Entities)
            {
                if (entity.EntityType != Type.BOMBER)
                {
                    fieldEntities.Add(entity);
                }
            }
            GameField.Clear();
            foreach (var entity in fieldEntities)
            {
                if (entity.EntityType != Type.BOMB)
                {
                    row = (int) entity.EntityPosition.GetX;
                    col = (int) entity.EntityPosition.GetY;
                    GameField.Add(new Pair<int, int>(row, col), new Pair<Type, IEntity>(entity.EntityType, entity));
                }
            }
        }
    }
}
