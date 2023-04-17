/// disabled warning CS8602 and CS8600 because PowerUpListComponent will never be null
#pragma warning disable CS8600
#pragma warning disable CS8602
namespace UnibomberGame
{
    public class PowerUpListComponent : AbstractComponent
    {
        private readonly List<PowerUpType> powerUpList;

        public PowerUpListComponent(int bombFire, List<PowerUpType> powerUpList)
        {
            this.powerUpList = new List<PowerUpType>(powerUpList);
            BombFire = bombFire;
        }

        public PowerUpListComponent(IEntity giver)
        {
            PowerUpListComponent giverPowerUpList = giver.GetComponent<PowerUpListComponent>();
            BombFire = giverPowerUpList.BombFire;
            powerUpList = giverPowerUpList.GetPowerUpList();
        }

        public int BombFire { get; set; }

        public List<PowerUpType> GetPowerUpList()
        {
            return new List<PowerUpType>(powerUpList);
        }

        public void AddPowerUpList(PowerUpType powerUpType)
        {
            powerUpList.Add(powerUpType);
        }

        public override void Update()
        {

        }
    }
}
