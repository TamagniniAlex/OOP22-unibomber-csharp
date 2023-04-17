/// disabled warning CS8602 because Components are controlled if are null
#pragma warning disable CS8602
namespace UnibomberTests
{
    [TestClass]
    public class DestroyComponentTest
    {
        private static readonly float WALL_COORD_X = 5.6F;
        private static readonly float WALL_COORD_Y = 3.4F;
        private static readonly int FIELD_ROWS = 15;
        private static readonly int FIELD_COLS = 19;
        private static readonly int DESTROY_FRAMES = 15;
        private static readonly IGame _game = new Game(FIELD_ROWS, FIELD_COLS);
        private readonly IEntityFactory _entityFactory = new EntityFactory(_game);

        [TestMethod]
        public void TestDestructibleWall()
        {
            var desWall = _entityFactory.MakeDestructibleWall(new Pair<float, float>(WALL_COORD_X, WALL_COORD_Y));
            _game.AddEntity(desWall);
            Assert.AreEqual(UnibomberGame.Type.DESTRUCTIBLE_WALL, desWall.EntityType);
            Assert.IsTrue(_game.Entities.Contains(desWall));
            Assert.IsNotNull(desWall.GetComponent<DestroyComponent>());
            Assert.IsFalse(desWall.GetComponent<DestroyComponent>().IsDestroyed);
            desWall.GetComponent<DestroyComponent>().Destroy();
            Assert.IsTrue(desWall.GetComponent<DestroyComponent>().IsDestroyed);
            for (int i = 0; i < DESTROY_FRAMES; i++)
            {
                desWall.GetComponent<DestroyComponent>().Update();
            }
            Assert.IsFalse(_game.Entities.Contains(desWall));
        }

        [TestMethod]
        public void TestIndestructibleWall()
        {
            var indesWall = _entityFactory.MakeIndestructibleWall(new Pair<float, float>(WALL_COORD_X, WALL_COORD_Y));
            _game.AddEntity(indesWall);
            Assert.AreEqual(UnibomberGame.Type.INDESTRUCTIBLE_WALL, indesWall.EntityType);
            Assert.IsTrue(_game.Entities.Contains(indesWall));
            Assert.IsNull(indesWall.GetComponent<DestroyComponent>());
        }
    }
}
