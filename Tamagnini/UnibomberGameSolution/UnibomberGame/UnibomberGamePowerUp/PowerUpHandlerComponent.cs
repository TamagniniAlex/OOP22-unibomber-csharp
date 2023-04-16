using Microsoft.VisualBasic;

namespace UnibomberGame
{
    public class PowerUpHandlerComponent : PowerUpListComponent
    {
        private static readonly float MAX_SPEED = 0.57f;
        private static readonly float MIN_SPEED = 0.31f;
        private static readonly float SPEED_POWERUP_CHANGE = 0.07f;
        private int bombNumber;
        private int bombPlaced;

        public PowerUpHandlerComponent(int bombNumber, int bombFire, List<PowerUpType> powerUpList) : base(bombFire, powerUpList)
        {
            this.bombNumber = bombNumber;
            this.bombPlaced = 0;
        }

        public int GetBombNumber()
        {
            return this.bombNumber;
        }

        public void SetBombNumer(int bombNumber)
        {
            this.bombNumber = bombNumber;
        }

        public int GetBombPlaced()
        {
            return this.bombPlaced;
        }

        public void AddBombPlaced(int bombPlaced)
        {
            this.bombPlaced += bombPlaced;
        }

        public int GetRemainingBomb()
        {
            return this.GetBombNumber() - this.GetBombPlaced();
        }

        public void addPowerUp(PowerUpType powerUpType)
        {
            this.AddPowerUpList(powerUpType);
            switch (powerUpType)
            {
                case PowerUpType.FIREUP:
                    if (this.GetBombFire() < 8)
                    {
                        this.SetBombFire(this.GetBombFire() + 1);
                    }
                    break;
                case PowerUpType.FIREDOWN:
                    if (this.GetBombFire() > 1)
                    {
                        this.SetBombFire(this.GetBombFire() - 1);
                    }
                    break;
                case PowerUpType.FIREFULL:
                    this.SetBombFire(8);
                    break;
                case PowerUpType.BOMBUP:
                    if (this.GetBombNumber() < 8)
                    {
                        this.SetBombNumer(this.GetBombNumber() + 1);
                    }
                    break;
                case PowerUpType.BOMBDOWN:
                    if (this.GetBombNumber() > 1)
                    {
                        this.SetBombNumer(this.GetBombNumber() - 1);
                    }
                    break;
                case PowerUpType.SPEEDUP:
                    if (this.Entity != null && this.Entity.GetSpeed() < MAX_SPEED)
                    {
                        this.Entity.AddSpeed(SPEED_POWERUP_CHANGE);
                    }
                    break;
                case PowerUpType.SPEEDDOWN:
                    if (this.Entity != null && this.Entity.GetSpeed() > MIN_SPEED)
                    {
                        this.Entity.AddSpeed(-SPEED_POWERUP_CHANGE);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}