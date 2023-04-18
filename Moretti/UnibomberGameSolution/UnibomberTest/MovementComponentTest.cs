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

        [TestMethod]
        public void TestMovement()
        {
            Pair<double, double> initialPosition = new Pair<double, double>(1.0, 1.0);
            Pair<double, double> right = new Pair<double, double>(1.0, 0);
            Pair<double, double> left = new Pair<double, double>(-1.0, 0);
            IEntity player = new Entity(UnibomberGame.Type.BOMBER, initialPosition)
                .AddComponent(new MovementComponent());
            game.AddEntity(player); 

            player.GetComponent<MovementComponent>().moveBy(right);
            player.GetComponent<MovementComponent>().Update();

            Assert.AreEqual(new Pair<double, double>(1.0 + 1.0 * player.GetSpeed(),1.0), player.Position);

            player.GetComponent<MovementComponent>().moveBy(left);
            player.GetComponent<MovementComponent>().Update();
            player.GetComponent<MovementComponent>().moveBy(left);
            player.GetComponent<MovementComponent>().Update();

            Assert.AreEqual(new Pair<double, double>(1.0 - 1.0 * player.GetSpeed(), 1.0), player.Position);
        }

    }
}
