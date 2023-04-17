/// disabled warning CS8602 because Components will never be null
#pragma warning disable CS8602
namespace UnibomberGame
{
    public class BombPlaceComponent : AbstractComponent
    {
        private bool bombPlaced;

        public override void update()
        {
            if (this.Entity != null)
            {
                IEntity thisEntity = this.Entity;
                if (this.bombPlaced)
                {
                    Pair<float, float> normalizedPosition = new Pair<float, float>(
                        (float)Math.Round(thisEntity.Position.x),
                        (float)Math.Round(thisEntity.Position.y));

                    IEntity bombCreate = new Entity();
                    bombCreate.Position = normalizedPosition;
                    thisEntity.GetComponent<PowerUpHandlerComponent>().AddBombPlaced(1);
                }
            }
            this.bombPlaced = false;
        }

        public void placeBomb()
        {
            if (this.Entity.GetComponent<PowerUpHandlerComponent>().GetRemainingBomb() > 0)
            {
                this.bombPlaced = true;
            }
        }
    }
}
