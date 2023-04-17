/// disabled warning CS8602 because Components will never be null
#pragma warning disable CS8602
namespace UnibomberGame
{
    public class BombPlaceComponent : AbstractComponent
    {
        private bool bombPlaced;
        private IGame? game;

        public override void update()
        {
            if (this.Entity != null)
            {
                IEntity thisEntity = this.Entity;
                if (this.bombPlaced)
                {
                    Pair<float, float> normalizedPosition = new Pair<float, float>(
                        (float)Math.Round(thisEntity.EntityPosition.x),
                        (float)Math.Round(thisEntity.EntityPosition.y));

                    IEntity bombCreate = new Entity(Type.BOMB)
                    {
                        EntityPosition = normalizedPosition
                    };
                    game.AddEntity(bombCreate);
                    thisEntity.GetComponent<PowerUpHandlerComponent>().AddBombPlaced(1);
                }
            }
            this.bombPlaced = false;
        }

        public void placeBomb(IGame game)
        {
            if (this.Entity.GetComponent<PowerUpHandlerComponent>().GetRemainingBomb() > 0)
            {
                this.bombPlaced = true;
                this.game = game;
            }
        }
    }
}
