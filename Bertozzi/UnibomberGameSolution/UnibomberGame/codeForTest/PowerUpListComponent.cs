/// disabled warning CS8602 and CS8600 because PowerUpListComponent will never be null
#pragma warning disable CS8600
#pragma warning disable CS8602
namespace UnibomberGame
{
    /// <summary>
    /// This component manage a list of all bombers and bomb powerUps.
    /// </summary>
    public class PowerUpListComponent : AbstractComponent
    {
        private readonly List<PowerUpType> powerUpList;

        /// <summary>
        /// This method sets all bomber's powerups.
        /// </summary>
        /// <param name="bombFire">bomb fire</param>
        /// <param name="powerUpList">power up list</param>
        public PowerUpListComponent(int bombFire, List<PowerUpType> powerUpList)
        {
            this.powerUpList = new List<PowerUpType>(powerUpList);
            BombFire = bombFire;
        }

        /// <summary>
        /// This method takes all powerups from giver.
        /// </summary>
        /// <param name="giver">giver bomber entity</param>
        public PowerUpListComponent(IEntity giver)
        {
            PowerUpListComponent giverPowerUpList = giver.GetComponent<PowerUpListComponent>();
            BombFire = giverPowerUpList.BombFire;
            powerUpList = giverPowerUpList.GetPowerUpList();
        }

        /// <summary>
        /// Set / Get bomb fire.
        /// </summary>
        public int BombFire { get; set; }

        /// <summary>
        /// This method return power up list.
        /// </summary>
        /// <returns>list of power up type</returns>
        public List<PowerUpType> GetPowerUpList()
        {
            return new List<PowerUpType>(powerUpList);
        }

        /// <summary>
        /// This method add power up into the list.
        /// </summary>
        /// <param name="powerUpType">power up to add</param>
        public void AddPowerUpList(PowerUpType powerUpType)
        {
            powerUpList.Add(powerUpType);
        }

        /// <inheritdoc />
        public override void Update()
        {

        }

    }

}
