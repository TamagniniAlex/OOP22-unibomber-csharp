using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnibomberGame
{
    internal interface ITimesUp
    {

        Game Game { get; set; }
        /// <summary>
        /// makes it so the walls start closing in
        /// </summary>
        void Start(int sizeX, int sizeY);

        /// <summary>
        /// should be called every frame. Places a new wall inside the game
        /// </summary>
        void Update();
    }
}
