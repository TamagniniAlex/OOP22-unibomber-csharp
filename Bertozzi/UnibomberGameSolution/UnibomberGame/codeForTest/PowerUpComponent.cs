namespace UnibomberGame
{
    /// <summary>
    /// This component manage the type of all powerUps.
    /// </summary>
    public class PowerUpComponent : AbstractComponent
    {
        /// <summary>
        /// This method set the type of powerUp.
        /// </summary>
        /// <param name="powerUpType">type of powerup to set</param>
        public PowerUpComponent(PowerUpType powerUpType) => PowerUpType = powerUpType;

        /// <summary>
        /// Set / Get Type of PowerUp.
        /// </summary>
        public PowerUpType PowerUpType { get; set; }
        
        /// <inheritdoc />
        public override void Update()
        {

        }

    }

}
