namespace ecs
{
    public class Pair<X, Y>
    {
        public X x {get;}
        
        public Y y {get;}

        public Pair(X x, Y y)
        {
            this.x = x;
            this.y = y;
        }

        public override int GetHashCode()
        {
            int prime = 31;
            int result = 1;
            result = prime * result + ((x == null) ? 0 : x.GetHashCode());
            result = prime * result + ((y == null) ? 0 : y.GetHashCode());
            return result;
        }

        public override bool Equals(object? obj)
        {
            return obj is Pair<X, Y> pair &&
                EqualityComparer<X>.Default.Equals(x, pair.x) &&
                EqualityComparer<Y>.Default.Equals(y, pair.y);
        }
    }
}