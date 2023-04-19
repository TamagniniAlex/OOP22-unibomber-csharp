using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnibomberGame
{
    public class RaisingComponent : AbstractComponent
    {

        /// <summary>
        /// This method turns the entity it is attatched to into a full wall after a frame has passed
        /// </summary>
        public override void Update()
        {
            if(Entity != null)
            {
                Entity.Game.AddEntity(new Entity(Type.WALL, Entity.Position));
                Entity.Game.RemoveEntity(Entity);
            }
        }
    }

}
