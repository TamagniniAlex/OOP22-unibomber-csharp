/// disabled warning CS8602 because Components are controlled if are null
#pragma warning disable CS8602
using System.Collections.Generic;
using System.Threading.Tasks;
namespace UnibomberTests
{
    [TestClass]
    public class ExplodeComponentTest
    {
        private static readonly float BOMB_EXCEPTED_X = 6.0F;
        private static readonly float BOMB_EXCEPTED_Y = 3.0F;
        private static readonly float DESWALL_EXCEPTED_X = 7.0f;
        private static readonly float DESWALL_EXCEPTED_Y = 3.0f;
        private static readonly float INDESWALL_EXCEPTED_X = 6.0f;
        private static readonly float INDESWALL_EXCEPTED_Y = 4.0f;
        private static readonly int FIELD_ROWS = 15;
        private static readonly int FIELD_COLS = 19;
        private static readonly int EXPIRING_TIME = 90;
        private static readonly int EXPLODE_DURATION = 9;
        private static readonly int DESTROY_FRAMES = 15;

        private static readonly IGame _game = new Game(FIELD_ROWS, FIELD_COLS);
        private readonly IEntityFactory _entityFactory = new EntityFactory(_game);

        [TestMethod]
        public void TestBombExplosion()
        {
            var desWall = _entityFactory.MakeDestructibleWall(new Pair<float, float>(DESWALL_EXCEPTED_X, DESWALL_EXCEPTED_Y));
            var indesWall = _entityFactory.MakeIndestructibleWall(new Pair<float, float>(INDESWALL_EXCEPTED_X, INDESWALL_EXCEPTED_Y));
            var bomb = _entityFactory.MakeBomb(new Pair<float, float>(BOMB_EXCEPTED_X, BOMB_EXCEPTED_Y));
            List<IEntity> entities = new List<IEntity>();
            entities.Add(desWall);
            entities.Add(indesWall);
            entities.Add(bomb);
            _game.AddEntity(indesWall);
            _game.AddEntity(desWall);
            _game.AddEntity(bomb);
            Assert.IsTrue(_game.Entities.Contains(indesWall));
            Assert.IsTrue(_game.Entities.Contains(desWall));
            Assert.IsTrue(_game.Entities.Contains(bomb));
            Assert.IsNotNull(bomb.GetComponent<ExplodeComponent>());
            for (int i = 0; i < (EXPIRING_TIME + EXPLODE_DURATION); i++)
            {
                bomb.GetComponent<ExplodeComponent>().Update();
            }
            foreach(var entity in entities)
            {
                if (entity.GetComponent<DestroyComponent>() != null)
                {
                    for (int i = 0; i < DESTROY_FRAMES; i++)
                    {
                        entity.GetComponent<DestroyComponent>().Update();
                    }
                }
            }
            Assert.IsTrue(_game.Entities.Contains(indesWall));
            Assert.IsFalse(_game.Entities.Contains(desWall));
            Assert.IsFalse(_game.Entities.Contains(bomb));
        }
    }
}