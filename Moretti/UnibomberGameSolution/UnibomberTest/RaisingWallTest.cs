using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnibomberGame;

/// disabled warning CS8602 because Components will never be null
namespace UnibomerTests
{
    [TestClass]
    public class RaisingTest
    {
        private Game game = new();
        private TimesUp timesUp = new (new Game());
        private readonly int DimensionX = 10, DimensionY = 10;

        private void InitializeVariables()
        {
            game = new Game();
            timesUp = new TimesUp(game);
        }

        [TestMethod]
        public void RisingTest()
        {
            InitializeVariables();
            timesUp.Start(DimensionX, DimensionY);
            timesUp.Update();
            timesUp.Update();
            timesUp.Update();
            timesUp.Update();
            Assert.AreEqual(4, game.Entities.Count);
            timesUp.Update();
            timesUp.Update();
            Assert.AreNotEqual(4, game.Entities.Count);
        }

        [TestMethod]
        public void CheckBorder()
        {

            InitializeVariables();
            timesUp.Start(DimensionX, DimensionY);
            for(int i = 0; i < 15; i++)
            {
                timesUp.Update();
            }
            Assert.AreEqual(15, game.Entities.Count);
        }
    }
}
