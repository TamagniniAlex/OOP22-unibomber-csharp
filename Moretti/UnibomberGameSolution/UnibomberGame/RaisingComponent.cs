using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnibomberGame
{
    internal class RaisingComponent : AbstractComponent
    {

        /// <summary>
        /// This method turns the entity it is attatched to into a full wall after a frame has passed
        /// </summary>
        public override void Update()
        {
            this.Entity.Game.AddEntity(new Entity(Type.WALL,this.Entity.Position));
            this.Entity.Game.RemoveEntity(this.Entity);
        }
    }

}
