using System.Collections.Generic;

namespace UnibomberGame
{
    public class Direction
    {
        public Direction()
        {

        }

        public List<Pair<int, int>> Directions()
        {
            List<Pair<int, int>> directions = new List<Pair<int, int>>();
            directions.Add(new Pair<int, int>(1, 0));
            directions.Add(new Pair<int, int>(-1, 0));
            directions.Add(new Pair<int, int>(0, 1));
            directions.Add(new Pair<int, int>(0, -1));
            return directions;
        }
    }
}