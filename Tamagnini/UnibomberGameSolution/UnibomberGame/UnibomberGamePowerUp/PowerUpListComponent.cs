namespace UnibomberGame
{
    public class PowerUpListComponent : AbstractComponent
    {
        private int bombFire;
        private readonly List<PowerUpType> powerUpList;

        public PowerUpListComponent(int bombFire, List<PowerUpType> powerUpList) 
        {
            this.bombFire = bombFire;
            this.powerUpList = new List<PowerUpType>(powerUpList);
        }

        /// disabled warning CS8602 and CS8600 because PowerUpListComponent will never be null
        #pragma warning disable CS8600
        #pragma warning disable CS8602
        public PowerUpListComponent(IEntity giver)
        {
            PowerUpListComponent giverPowerUpList = giver.GetComponent<PowerUpListComponent>();
            this.bombFire = giverPowerUpList.GetBombFire();
            this.powerUpList = giverPowerUpList.GetPowerUpList();
        }

        public override void update()
        {

        }

        public int GetBombFire()
        {
            return this.bombFire;
        }

        public void SetBombFire(int bombFire)
        {
            this.bombFire = bombFire;
        }

        public List<PowerUpType> GetPowerUpList()
        {
            return new List<PowerUpType>(this.powerUpList);
        }

        public void AddPowerUpList(PowerUpType powerUpType)
        {
            this.powerUpList.Add(powerUpType);
        }
    }
}