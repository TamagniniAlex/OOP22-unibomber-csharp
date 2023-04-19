using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UnibomberGame
{
    internal class TimesUp : ITimesUp
    {
        private bool isStarted;
        private bool isDone;
        private int normalizedFrames;
        private Pair<int, int>? currentPosition;
        private bool[][]? raisedWalls;
        private Pair<int, int>? currentDirection;

        /// <inheritdoc />
        public Game Game {  set; }
        public void start(int sizeX, int sizeY)
        {
            currentPosition = new Pair<int, int>(0, 0);
            currentDirection = new Pair<int, int>(1, 0);
            raisedWalls = new int[sizeX][sizeY];
        }

        public void update()
        {
            throw new NotImplementedException();
        }
    }
}
