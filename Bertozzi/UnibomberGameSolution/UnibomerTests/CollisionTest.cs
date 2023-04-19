using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;
using System.Runtime.InteropServices;
using UnibomberGame;

/// disabled warning CS8602 because Components will never be null
#pragma warning disable CS8602
namespace UnibomerTests
{
    [TestClass]
    public class CollisionTest
    {
        private const float XPLAYERR = 0.6f;
        private const float XPLAYERL = 0.3f;
        private const int ROWS = 5;
        private const int COLUMNS = 5;
        private static readonly IGame _game = new Game(ROWS, COLUMNS);
        private readonly IEntityFactory _entityFactory = new EntityFactory(_game);
        [TestMethod]
        public void TestCollisionsPlayerWall()
        {
            _game.AddEntity(_entityFactory.MakeIndestructibleWall(new Pair<float, float>(0f, 1f)));
            _game.AddEntity(_entityFactory.MakeIndestructibleWall(new Pair<float, float>(1f, 0f)));
            IEntity player = _entityFactory.MakePlayable(new Pair<float, float>(0f, 0f));
            _game.AddEntity(player);
            Assert.AreEqual(player.EntityPosition, new Pair<float, float>(0f, 0f));
            MoveOneTiles(player);
            Assert.AreEqual(new Pair<float, float>(0f, 0f), player.EntityPosition);
        }
        [TestMethod]
        public void TestCollisionsPlayerWallAngleRight()
        {
            _game.AddEntity(_entityFactory.MakeIndestructibleWall(new Pair<float, float>(0f, 1f)));
            IEntity player = _entityFactory.MakePlayable(new Pair<float, float>(XPLAYERR, 0f));
            _game.AddEntity(player);
            Assert.AreEqual(player.EntityPosition, new Pair<float, float>(XPLAYERR, 0f));
            MoveOneTiles(player);
            Assert.AreEqual(1, player.EntityPosition.GetX);
        }

        [TestMethod]
        public void TestCollisionsPlayerWallAnglLeft()
        {
            _game.AddEntity(_entityFactory.MakeIndestructibleWall(new Pair<float, float>(0f, 1f)));
            IEntity player = _entityFactory.MakePlayable(new Pair<float, float>(XPLAYERL, 0f));
            _game.AddEntity(player);
            Assert.AreEqual(player.EntityPosition, new Pair<float, float>(XPLAYERL, 0f));
            MoveOneTiles(player);
            Assert.AreEqual(0, player.EntityPosition.GetX);
        }
        [TestMethod]
        public void TestCollisionsPlayerPowerUP()
        {
            _game.AddEntity(_entityFactory.MakePowerUp(new Pair<float, float>(0f, 1f), PowerUpType.FIREUP));
            IEntity player = _entityFactory.MakePlayable(new Pair<float, float>(0f, 0f));
            _game.AddEntity(player);
            Assert.AreEqual(player.EntityPosition, new Pair<float, float>(0f, 0f));
            MoveOneTiles(player);
            Assert.IsTrue(player.GetComponent<PowerUpHandlerComponent>().GetPowerUpList()
                    .Contains(PowerUpType.FIREUP));
        }

        [TestMethod]
        public void TestCollisionsPlayerBomb()
        {
            IEntity player = _entityFactory.MakePlayable(new Pair<float, float>(0f, 0f));
            _game.AddEntity(_entityFactory.MakeBomb(new Pair<float, float>(0f, 1f)));
            _game.AddEntity(player);
            player.GetComponent<CollisionComponent>().Update();
            Assert.AreEqual(player.EntityPosition, new Pair<float, float>(0f, 0f));
            MoveOneTiles(player);
            Assert.AreEqual(new Pair<float, float>(0f, 0f), player.EntityPosition);
        }
        private static void MoveOneTiles(IEntity player)
        {
            MovementComponent? movement = player.GetComponent<MovementComponent>();
            CollisionComponent? collision = player.GetComponent<CollisionComponent>();
            movement.MoveBy(new Pair<float, float>(0f, 1f));
            movement.Update();
            collision.Update();
            movement.MoveBy(new Pair<float, float>(0f, 1f));
            movement.Update();
            collision.Update();
            movement.MoveBy(new Pair<float, float>(0f, 1f));
            movement.Update();
            collision.Update();
            movement.MoveBy(new Pair<float, float>(0f, 1f));
            movement.Update();
            collision.Update();
            movement.MoveBy(new Pair<float, float>(0f, 1f));
            movement.Update();
            collision.Update();
        }
    }
}

