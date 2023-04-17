namespace UnibomberGame
{
    public class PowerUpHandlerComponent : PowerUpListComponent
    {
        private static readonly float MAX_SPEED = 0.57f;
        private static readonly float MIN_SPEED = 0.31f;
        private static readonly float SPEED_POWERUP_CHANGE = 0.07f;
        private int bombPlaced;

        public PowerUpHandlerComponent(int bombNumber, int bombFire, List<PowerUpType> powerUpList) : base(bombFire, powerUpList)
        {
            BombNumber = bombNumber;
            bombPlaced = 0;
        }

        public int BombNumber { get; set; }

        public int GetBombPlaced()
        {
            return bombPlaced;
        }

        public void AddBombPlaced(int bombPlaced)
        {
            this.bombPlaced += bombPlaced;
        }

        public int GetRemainingBomb()
        {
            return BombNumber - GetBombPlaced();
        }

        public void AddPowerUp(PowerUpType powerUpType)
        {
            AddPowerUpList(powerUpType);
            switch (powerUpType)
            {
                case PowerUpType.FIREUP:
                    if (BombFire < 8)
                    {
                        BombFire++;
                    }
                    break;
                case PowerUpType.FIREDOWN:
                    if (BombFire > 1)
                    {
                        BombFire--;
                    }
                    break;
                case PowerUpType.FIREFULL:
                    BombFire = 8;
                    break;
                case PowerUpType.BOMBUP:
                    if (BombNumber < 8)
                    {
                        BombNumber++;
                    }
                    break;
                case PowerUpType.BOMBDOWN:
                    if (BombNumber > 1)
                    {
                        BombNumber--;
                    }
                    break;
                case PowerUpType.SPEEDUP:
                    if (Entity != null && Entity.GetSpeed() < MAX_SPEED)
                    {
                        Entity.AddSpeed(SPEED_POWERUP_CHANGE);
                    }
                    break;
                case PowerUpType.SPEEDDOWN:
                    if (Entity != null && Entity.GetSpeed() > MIN_SPEED)
                    {
                        Entity.AddSpeed(-SPEED_POWERUP_CHANGE);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
