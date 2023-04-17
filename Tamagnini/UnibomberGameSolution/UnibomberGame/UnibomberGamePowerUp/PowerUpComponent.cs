namespace UnibomberGame
{
    public class PowerUpComponent : AbstractComponent
    {
        public PowerUpComponent(PowerUpType powerUpType) => PowerUpType = powerUpType;

        public PowerUpType PowerUpType { get; set; }

        public override void Update()
        {

        }
    }
}
