using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnibomberGame;

/// disabled warning CS8602 because Components will never be null
#pragma warning disable CS8602
namespace UnibomerTests
{
    [TestClass]
    public class RaisingTest
    {
        private Game game;
        private TimesUp timesUp;
        private readonly int DimensionX = 10, DimensionY = 10;

        private void initializeVariables()
        {
            game = new Game();
            timesUp = new TimesUp(game);
        }

        [TestMethod]
        public void RisingTest()
        {
            initializeVariables();
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
        public void checkBorder()
        {

            initializeVariables();
            timesUp.Start(DimensionX, DimensionY);
            for(int i = 0; i < 15; i++)
            {
                timesUp.Update();
            }
            Assert.AreEqual(15, game.Entities.Count);
        }
    }
}
