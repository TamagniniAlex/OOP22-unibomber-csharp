namespace UnibomberGame
{
    /// <summary>
    /// This component manage bombers powerUp.
    /// </summary>
    public class PowerUpHandlerComponent : PowerUpListComponent
    {
        private static readonly float MAX_SPEED = 0.57f;
        private static readonly float MIN_SPEED = 0.31f;
        private static readonly float SPEED_POWERUP_CHANGE = 0.07f;
        private int bombPlaced;

        /// <summary>
        /// This method inherit powerUp from the superclass.
        /// </summary>
        /// <param name="bombNumber">starting bomb number</param>
        /// <param name="bombFire">starting bomb fire</param>
        /// <param name="powerUpList">starting power up list</param>
        public PowerUpHandlerComponent(int bombNumber, int bombFire, List<PowerUpType> powerUpList) : base(bombFire, powerUpList)
        {
            BombNumber = bombNumber;
            bombPlaced = 0;
        }

        /// <summary>
        /// Set / Get bomb number.
        /// </summary>
        public int BombNumber { get; set; }

        /// <summary>
        /// Return bombPlaced of player.
        /// </summary>
        /// <returns>bomb placed</returns>
        public int GetBombPlaced()
        {
            return bombPlaced;
        }

        /// <summary>
        /// Add bomb placed
        /// </summary>
        /// <param name="bombPlaced">bombe placed</param>
        public void AddBombPlaced(int bombPlaced)
        {
            this.bombPlaced += bombPlaced;
        }

        /// <summary>
        /// Return number of remaning placeable bomb.
        /// </summary>
        /// <returns>number of remaning bomb</returns>
        public int GetRemainingBomb()
        {
            return BombNumber - GetBombPlaced();
        }

        /// <summary>
        /// Add powerup into list and modifiy bomber value.
        /// </summary>
        /// <param name="powerUpType">power up to add</param>
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
