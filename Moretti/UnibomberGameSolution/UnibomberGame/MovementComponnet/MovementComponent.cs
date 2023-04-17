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
        private Pair<float, float> moveBy = new Pair<float, float>(0f, 0f);

        /// <inheritdoc />
        public override void Update()
        {
                this.Entity.addPosition(moveBy);
                handleDirection();
        }

        /**
         * Given the direction it updates the number of frames spent
         * in that direction for the animation's sake.
         */
        private void handleDirection()
        {
            Direction newDirection = Direction.extractDirecion(moveBy).orElse(direction);
            if (this.direction == newDirection)
            {
                this.framesInDirection++;
            }
            else
            {
                this.framesInDirection = 0;
                this.direction = newDirection;
            }
            if (framesInDirection == Constants.Movement.FRAME_DELAY)
            {
                passedFrame++;
                this.framesInDirection = 0;
            }
        }

        /**
         * @param direction the direction to move by
         */
        public final void moveBy(final Direction direction)
        {
            this.moveBy = new Pair<>(
                    direction.getX() * this.getEntity().getSpeed() * globalSpeedMultiplier * Constants.Input.POSITIVE_MOVE,
                    direction.getY() * this.getEntity().getSpeed() * globalSpeedMultiplier * Constants.Input.POSITIVE_MOVE);
            if (moveBy.equals(new Pair<Float, Float>(0f, 0f)))
            {
                hasMoved = false;
            }
            else
            {
                hasMoved = true;
            }
        }

        /**
         * @return the direction this entity is facing
         */
        public final Direction getDirection()
        {
            return this.direction;
        }

        /**
         * @return the number of frames spent in one direction
         */
        public final int getFrameInDirection()
        {
            return this.framesInDirection;
        }

        /**
         * @return the number of frames spent in one direction
         *         keeping in mind the FRAME_DELAY
         */
        public final int getPassedFrames()
        {
            return this.passedFrame;
        }

        /**
         * @param speed the new value of globalSpeedMultiplier
         */
        public static void setGlobalSpeedMultiplier(final float speed)
        {
            globalSpeedMultiplier = speed;
        }

        /**
         * @return whether the entity has moved in the last game frame
         */
        public boolean hasMoved()
        {
            return this.hasMoved;
        }

    }
}