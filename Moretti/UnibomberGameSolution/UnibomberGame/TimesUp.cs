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
        private bool _isStarted = false;
        private bool _isDone = false;
        private Pair<int, int>? _currentPosition;
        private bool[][] _raisedWalls = new int[0][0];
        private Pair<int, int>? _currentDirection;
        int? _sizeX;
        int? _sizeY;

        /// <inheritdoc />
        public Game Game { get; set; } = new Game();
        public void start(int sizeX, int sizeY)
        {
            _currentPosition = new Pair<int, int>(0, 0);
            _currentDirection = new Pair<int, int>(1, 0);
            _raisedWalls = new int[sizeX][sizeY];
            _isStarted = true;
            _sizeX = sizeX;
            _sizeY = sizeY;
        }

        public void update()
        {

            if (_isStarted && !_isDone)
            {
                Pair<int,int> newPosition = new Pair<int, int>(_currentDirection.GetX + _currentPosition.GetX,
                          _currentDirection.GetY + _currentPosition.GetY);
                if (!Utilities.isBetween(newPosition.GetX, 0, _sizeX)
                          || !Utilities.isBetween(newPosition.GetY, 0, _sizeY)
                          || _raisedWalls[newPosition.GetX][newPosition.GetY])
                {
                    _currentDirection = _currentDirection.getNextClockwise();
                    newPosition = new Pair<int, int>(_currentDirection.GetX + _currentPosition.GetX,
                              _currentDirection.GetY + _currentPosition.GetY);
                    if (_raisedWalls[newPosition.GetX][newPosition.GetY])
                    {
                        _isDone = true;
                    }
                }
                raisedWalls[newPosition.getX][newPosition.getY] = true;
                Game.AddEntity(new Entity(Type.WALL,new Pair<double, double>(_currentPosition.GetX, _currentPosition.GetY)));
                _currentPosition = newPosition;
            }
        }
    }
}
