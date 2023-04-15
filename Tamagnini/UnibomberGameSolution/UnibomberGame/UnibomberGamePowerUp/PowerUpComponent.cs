namespace UnibomberGame
{
    public class PowerUpComponent : AbstractComponent
    {
        private readonly PowerUpType powerUpType;

        public PowerUpComponent(PowerUpType powerUpType)
        {
            this.powerUpType = powerUpType;
        }

        public PowerUpType GetPowerUpType()
        {
            return powerUpType;
        }

        public override void update()
        {

        }
    }
}