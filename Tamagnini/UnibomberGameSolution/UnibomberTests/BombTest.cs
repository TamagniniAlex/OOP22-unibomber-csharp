using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnibomberGame;

/// disabled warning CS8602 because Components will never be null
#pragma warning disable CS8602
namespace UnibomerTests
{
    [TestClass]
    public class BombTest
    {
        private static readonly float BOMB_EXCEPTED_X = 0f;
        private static readonly float BOMB_EXCEPTED_Y = 0f;
        private readonly IGame game = new Game();
        private static IEntity CreatePlayerEntity()
        {
            return new Entity(UnibomberGame.Type.BOMBER)
                .AddComponent(new BombPlaceComponent())
                .AddComponent(new PowerUpHandlerComponent(1, 1, new List<PowerUpType>()));
        }

        [TestMethod]
        public void TestBombPlace()
        {
            IEntity player = CreatePlayerEntity();
            this.game.AddEntity(player);
            player.GetComponent<BombPlaceComponent>().PlaceBomb(this.game);
            player.GetComponent<BombPlaceComponent>().Update();
            IEntity? bombEntity = null;
            foreach(var entities in this.game.Entities)
            {
                if (entities.EntityType.Equals(UnibomberGame.Type.BOMB)) {
                    bombEntity = entities;
                }
            }
            Assert.IsTrue(bombEntity != null);
            Assert.AreEqual(new Pair<float,float>(BOMB_EXCEPTED_X, BOMB_EXCEPTED_Y), bombEntity.EntityPosition);
        }

    }
}
