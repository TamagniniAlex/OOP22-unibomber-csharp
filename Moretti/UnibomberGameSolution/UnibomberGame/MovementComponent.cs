using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

/// disabled warning CS8602 because Components will never be null
#pragma warning disable CS8602
namespace UnibomberGame
{

    /// <summary>
    /// This component manage bomb placement.
    /// </summary>
    public class MovementComponent : AbstractComponent
    {
        readonly double POSITIVE_MOVE = 1;
        private Pair<double, double> _moveBy = new (0f, 0f);
        public Pair<double, double> Direction { get; set; } = new (0,0);

        /// <inheritdoc />
        public override void Update()
        {   
            Entity.addPosition(new (_moveBy.GetX, _moveBy.GetY));
            UpdateDirection();
            ResetMovement();
        }
        /// <summary>
        /// given the movement, updates the direction the entity is facing.
        /// </summary>
        private void UpdateDirection()
        {
            int directionX = _moveBy.GetX == 0 ? 0 : _moveBy.GetX > 0 ? 1 : -1;
            int directionY = _moveBy.GetY == 0 ? 0 : _moveBy.GetY > 0 ? 1 : -1;
            Direction = new (directionX, directionY);
        }

        /// <summary>
        /// resets the current movement
        /// </summary>
        private void ResetMovement()
        {
            _moveBy = new (0, 0);
        }

        /// <summary>
        /// method that upsates the direction to move towards
        /// </summary>
        /// <param name="direction">the direction to move towards</param>
        public void MoveBy(Pair<double, double> direction)
        {
            _moveBy = new (
                    direction.GetX * Entity.GetSpeed() * POSITIVE_MOVE,
                    direction.GetY * Entity.GetSpeed() * POSITIVE_MOVE);
        }

    }
}