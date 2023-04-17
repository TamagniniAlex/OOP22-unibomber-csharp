using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnibomberGame;

/// disabled warning CS8602 because Components will never be null
#pragma warning disable CS8602
namespace UnibomerTests
{
    [TestClass]
    public class PowerUpTest
    {
        private static readonly float SPEED_BASE = 0.3f;
        private static readonly float SPEED_POWERUP = 0.07f;
        private static readonly int BOMB_NUMBER_BASE = 1;
        private static readonly int BOMB_NUMBER_POWERUP = 1;
        private static readonly int BOMB_NUMBER_MAX = 8;
        private static readonly int BOMB_FIRE_BASE = 1;
        private static readonly int BOMB_FIRE_POWERUP = 1;
        private static readonly int BOMB_FIRE_MAX = 8;
        private static IEntity CreatePlayerEntity()
        {
            return new Entity(UnibomberGame.Type.BOMBER)
                .AddComponent(new PowerUpHandlerComponent(1, 1, new List<PowerUpType>()));
        }

        [TestMethod]
        public void TestBombNumberPowerUp()
        {
            IEntity player = CreatePlayerEntity();
            Assert.AreEqual(BOMB_NUMBER_BASE, player.GetComponent<PowerUpHandlerComponent>().BombNumber);
            player.GetComponent<PowerUpHandlerComponent>().AddPowerUp(PowerUpType.BOMBUP);
            Assert.AreEqual(BOMB_NUMBER_BASE + BOMB_NUMBER_POWERUP, player.GetComponent<PowerUpHandlerComponent>().BombNumber);
            for (int i = 0; i < 10; i++)
            {
                player.GetComponent<PowerUpHandlerComponent>().AddPowerUp(PowerUpType.BOMBUP);
            }
            Assert.AreEqual(BOMB_NUMBER_MAX, player.GetComponent<PowerUpHandlerComponent>().BombNumber);
            player.GetComponent<PowerUpHandlerComponent>().AddPowerUp(PowerUpType.BOMBDOWN);
            Assert.AreEqual(BOMB_NUMBER_MAX - BOMB_NUMBER_POWERUP, player.GetComponent<PowerUpHandlerComponent>().BombNumber);
        }

        [TestMethod]
        public void TestBombFirePowerUp()
        {
            IEntity player = CreatePlayerEntity();
            Assert.AreEqual(BOMB_FIRE_BASE, player.GetComponent<PowerUpHandlerComponent>().BombFire);
            player.GetComponent<PowerUpHandlerComponent>().AddPowerUp(PowerUpType.FIREUP);
            Assert.AreEqual(BOMB_FIRE_BASE + BOMB_FIRE_POWERUP, player.GetComponent<PowerUpHandlerComponent>().BombFire);
            for (int i = 0; i < 10; i++)
            {
                player.GetComponent<PowerUpHandlerComponent>().AddPowerUp(PowerUpType.FIREUP);
            }
            Assert.AreEqual(BOMB_FIRE_MAX, player.GetComponent<PowerUpHandlerComponent>().BombFire);
            player.GetComponent<PowerUpHandlerComponent>().AddPowerUp(PowerUpType.FIREDOWN);
            Assert.AreEqual(BOMB_FIRE_MAX - BOMB_FIRE_POWERUP, player.GetComponent<PowerUpHandlerComponent>().BombFire);
            player.GetComponent<PowerUpHandlerComponent>().AddPowerUp(PowerUpType.FIREFULL);
            Assert.AreEqual(BOMB_FIRE_MAX, player.GetComponent<PowerUpHandlerComponent>().BombFire);
        }

        [TestMethod]
        public void TestSpeedUpPowerUp()
        {
            IEntity player = CreatePlayerEntity();
            Assert.AreEqual(SPEED_BASE, player.GetSpeed());
            player.GetComponent<PowerUpHandlerComponent>().AddPowerUp(PowerUpType.SPEEDUP);
            Assert.AreEqual(SPEED_BASE + SPEED_POWERUP, player.GetSpeed());
            Assert.IsTrue(player.GetComponent<PowerUpHandlerComponent>().GetPowerUpList().Contains(PowerUpType.SPEEDUP));
            player.GetComponent<PowerUpHandlerComponent>().AddPowerUp(PowerUpType.SPEEDDOWN);
            Assert.AreEqual(SPEED_BASE, player.GetSpeed());
            Assert.IsTrue(player.GetComponent<PowerUpHandlerComponent>().GetPowerUpList().Contains(PowerUpType.SPEEDDOWN));
        }

    }
}
