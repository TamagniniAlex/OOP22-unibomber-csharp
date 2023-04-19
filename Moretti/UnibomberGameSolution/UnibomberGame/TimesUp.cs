using Microsoft.VisualBasic;
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
        private bool _isStarted;
        private bool _isDone;
        private readonly int _startX, _startY;
        private Pair<int, int> _currentPosition;
        private bool[,] _raisedWalls;
        private Pair<int, int> _currentDirection;

        /// <inheritdoc />
        public Game Game { get; set; }

        public TimesUp(Game game)
        {
            _isStarted = false;
            _isDone = false;
            _currentDirection = new Pair<int, int>(1,0);
            _currentPosition = new Pair<int, int>(-1, 0);
            Game = game;
            Start(10,10);
        }
        public void Start(int sizeX, int sizeY)
        {
            _raisedWalls = new bool[sizeX,sizeY];
            _isStarted = true;
        }

        public void Update()
        {
            if (_isStarted && !_isDone)
            {
                Pair<int,int> newPosition = new Pair<int, int>(_currentDirection.GetX + _currentPosition.GetX,
                          _currentDirection.GetY + _currentPosition.GetY);
                if (!Utilities.IsBetween(newPosition.GetX, 0, _startX)
                          || !Utilities.IsBetween(newPosition.GetY, 0, _startY)
                          || _raisedWalls[newPosition.GetX,newPosition.GetY])
                {
                    _currentDirection = getNextClockwise(_currentDirection);
                    newPosition = new Pair<int,int>(_currentDirection.GetX + _currentPosition.GetX,
                              _currentDirection.GetY + _currentPosition.GetY);
                    if (_raisedWalls[newPosition.GetX,newPosition.GetY])
                    {
                        _isDone = true;
                    }
                }
                _raisedWalls[newPosition.GetX,newPosition.GetY] = true;                
                Game.AddEntity(new Entity(Type.RAISING_WALL,new Pair<double, double>(_currentPosition.GetX, _currentPosition.GetY);
                _currentPosition = newPosition;
            }
        }
        private Pair<int,int> getNextClockwise(Pair<int, int> direction)
        {
            int x = direction.GetY > 0 ? 1 : direction.GetY < 0 ? -1 : 0;
            int y = direction.GetX > 0 ? -1 : direction.GetX < 0 ? 1 : 0;

            return new Pair<int, int>(x, y);
        }
    }
}
