using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnibomberGame;

/// disabled warning CS8602 because Components will never be null
#pragma warning disable CS8602
namespace UnibomerTests
{
    [TestClass]
    public class MovementTest
    {
        private readonly Pair<double, double> initialPosition = new Pair<double, double>(1.0, 1.0);
        private readonly Pair<double, double> right = new Pair<double, double>(1.0, 0);
        private readonly Pair<double, double> left = new Pair<double, double>(-1.0, 0);

        [TestMethod]
        public void TestMovement()
        {
            IEntity player = new Entity(UnibomberGame.Type.BOMBER, initialPosition)
                .AddComponent(new MovementComponent());

            player.GetComponent<MovementComponent>().moveBy(right);
            player.GetComponent<MovementComponent>().Update();

            Assert.AreEqual(new Pair<double, double>(1.0 + 1.0 * player.GetSpeed(), 1.0), player.Position);

            player.GetComponent<MovementComponent>().moveBy(left);
            player.GetComponent<MovementComponent>().Update();
            player.GetComponent<MovementComponent>().moveBy(left);
            player.GetComponent<MovementComponent>().Update();

            Assert.AreEqual(new Pair<double, double>(1.0 - 1.0 * player.GetSpeed(), 1.0), player.Position);
        }
        [TestMethod]
        public void TestMultipleMovements()
        {
            IEntity player = new Entity(UnibomberGame.Type.BOMBER, initialPosition)
                .AddComponent(new MovementComponent());

            player.GetComponent<MovementComponent>().moveBy(right);
            player.GetComponent<MovementComponent>().moveBy(left);
            player.GetComponent<MovementComponent>().moveBy(right);
            player.GetComponent<MovementComponent>().moveBy(left);
            player.GetComponent<MovementComponent>().Update();

            Assert.AreEqual(new Pair<double, double>(1.0 - 1.0 * player.GetSpeed(), 1.0), player.Position);

            player.GetComponent<MovementComponent>().moveBy(left);
            player.GetComponent<MovementComponent>().moveBy(left);
            player.GetComponent<MovementComponent>().moveBy(left);
            player.GetComponent<MovementComponent>().moveBy(left);
            player.GetComponent<MovementComponent>().moveBy(right);
            player.GetComponent<MovementComponent>().Update();

            Assert.AreEqual(new Pair<double, double>(1.0, 1.0), player.Position);
        }

        [TestMethod]
        public void TestDirection()
        {
            IEntity player = new Entity(UnibomberGame.Type.BOMBER, initialPosition)
                .AddComponent(new MovementComponent());

            player.GetComponent<MovementComponent>().moveBy(right);
            player.GetComponent<MovementComponent>().Update();

            Assert.AreEqual(right, player.GetComponent<MovementComponent>().Direction);

            player.GetComponent<MovementComponent>().moveBy(left);
            player.GetComponent<MovementComponent>().moveBy(left);
            player.GetComponent<MovementComponent>().moveBy(left);
            player.GetComponent<MovementComponent>().moveBy(right);
            player.GetComponent<MovementComponent>().moveBy(left);
            player.GetComponent<MovementComponent>().Update();

            Assert.AreEqual(left, player.GetComponent<MovementComponent>().Direction);
        }

    }
}
