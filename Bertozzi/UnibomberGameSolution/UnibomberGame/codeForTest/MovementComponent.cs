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
        readonly float POSITIVE_MOVE = 0.2f;
        private Pair<float, float> _moveBy = new Pair<float, float>(0f, 0f);

        /// <inheritdoc />
        public override void Update()
        {
                this.Entity.EntityPosition = new Pair<float, float>(_moveBy.GetX, _moveBy.GetY);
        }

        /**
         * @param direction the direction to move by
         */
        public void MoveBy(Pair<float, float> direction)
        {
            _moveBy = new Pair<float, float>(
                    this.Entity.EntityPosition.GetX + direction.GetX * this.Entity.GetSpeed() * POSITIVE_MOVE,
                    this.Entity.EntityPosition.GetY + direction.GetY * this.Entity.GetSpeed() * POSITIVE_MOVE);
        }

    }
}