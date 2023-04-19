using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UnibomberGame
{
    public class TimesUp : ITimesUp
    {
        private bool _isStarted;
        private bool _isDone;
        private int _startX, _startY;
        private Pair<int, int> _currentPosition;
        private bool[,] _raisedWalls;
        private Pair<int, int> _currentDirection;

        /// <inheritdoc />
        public Game Game { get; set; }

        /// <summary>
        /// constructor of timesUp
        /// </summary>
        /// <param name="game">the game associated to the timesUp</param>
        public TimesUp(Game game)
        {
            _isStarted = false;
            _isDone = false;
            _raisedWalls = new bool[0, 0];
            _currentDirection = new Pair<int, int>(1, 0);
            _currentPosition = new Pair<int, int>(-1, 0);
            Game = game;
            Start(10, 10);
        }

        /// <summary>
        /// Times up is started
        /// </summary>
        /// <param name="sizeX">the horizontal size of the game</param>
        /// <param name="sizeY">the vertical size of the game</param>
        public void Start(int sizeX, int sizeY)
        {
            _raisedWalls = new bool[sizeX, sizeY];
            _isStarted = true;
            _startX = sizeX;
            _startY = sizeY;
        }


        /// <summary>
        /// Should be called every frame, updates the timesUp
        /// </summary>
        public void Update()
        {
            if (_isStarted && !_isDone)
            {
                Pair<int, int> newPosition = new (_currentDirection.GetX + _currentPosition.GetX,
                          _currentDirection.GetY + _currentPosition.GetY);
                if (!Utilities.IsBetween(newPosition.GetX, 0, _startX)
                          || !Utilities.IsBetween(newPosition.GetY, 0, _startY)
                          || _raisedWalls[newPosition.GetX, newPosition.GetY])
                {
                    _currentDirection = GetNextClockwise(_currentDirection);
                    newPosition = new Pair<int, int>(_currentDirection.GetX + _currentPosition.GetX,
                              _currentDirection.GetY + _currentPosition.GetY);
                    if (_raisedWalls[newPosition.GetX, newPosition.GetY])
                    {
                        _isDone = true;
                    }
                }
                _raisedWalls[newPosition.GetX, newPosition.GetY] = true;
                Game.AddEntity(new Entity(Type.RAISING_WALL, new Pair<double, double>(_currentPosition.GetX, _currentPosition.GetY)));
                _currentPosition = newPosition;
            }
        }

        /// <summary>
        /// Times up is started
        /// </summary>
        /// <param name="sizeX">the horizontal size of the game</param>
        /// <param name="sizeY">the vertical size of the game</param>
        /// <returns>the next value clockWise</returns>
        private static Pair<int, int> GetNextClockwise(Pair<int, int> direction)
        {
            Pair<int, int> LEFT = new (-1, 0);
            Pair<int, int> RIGHT = new (1, 0);
            Pair<int, int> UP = new (0,-1);
            Pair<int, int> DOWN = new(0,1);
            if (direction.GetX > 0) return DOWN;
            else if (direction.GetX < 0) return UP;
            else if (direction.GetY > 0) return LEFT;
            else  return RIGHT;
        }
    }
}
