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
     public void update()
        {
            this.Entity.Game.AddEntity(new Entity(Type.WALL,this.Entity.Position));
            this.Entity.Game..remove(entity);
        }

    }

}
