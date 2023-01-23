using Life.Geometry;

namespace Life.Ants
{
    public abstract class Ant
    {
        public string Symbol { get; }

        public Position Position { get; protected set; }

        protected Colony Colony { get; }

        protected Ant(Colony colony, string symbol, Position position)
        {
            Colony = colony;
            Symbol = symbol;
            Position = position;
        }

        public abstract void Move();

        public virtual string GetState()
        {
            return string.Empty;
        }

        protected void MoveToDirection(Direction direction)
        {
            Position next = Position.NextInDirection(direction);
            if (next.IsInRange(Colony.Width, Colony.Width))
            {
                this.Position = next;
            }
        }
    }
}
