/// disabled warning CS8602 because Components will never be null
#pragma warning disable CS8602
namespace UnibomberGame
{
    /// <summary>
    /// This component manage bomb placement.
    /// </summary>
    public class BombPlaceComponent : AbstractComponent
    {
        private bool _bombPlaced;
        private IGame? _game;

        /// <inheritdoc />
        public override void Update()
        {
            if (Entity != null)
            {
                IEntity thisEntity = Entity;
                if (_bombPlaced)
                {
                    Pair<float, float> normalizedPosition = new(
                        (float)Math.Round(thisEntity.EntityPosition.GetX),
                        (float)Math.Round(thisEntity.EntityPosition.GetY));

                    IEntity bombCreate = new Entity(Type.BOMB)
                    {
                        EntityPosition = normalizedPosition
                    };
                    _game.AddEntity(bombCreate);
                    thisEntity.GetComponent<PowerUpHandlerComponent>().AddBombPlaced(1);
                }
            }
            _bombPlaced = false;
        }

        /// <summary>
        /// This method set the state of the bomb.
        /// </summary>
        /// <param name="game">entity's game</param>
        public void PlaceBomb(IGame game)
        {
            if (Entity.GetComponent<PowerUpHandlerComponent>().GetRemainingBomb() > 0)
            {
                _bombPlaced = true;
                _game = game;
            }
        }

    }

}
