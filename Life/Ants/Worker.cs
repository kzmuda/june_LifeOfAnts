using Life.Geometry;

namespace Life.Ants
{
    public class Worker : Ant
    {
        public Worker(Colony colony, Position position) : base(colony, "W", position)
        {
        }

        public override void Move()
        {
            MoveToDirection(DirectionExtensions.GetRandomDirection());
        }
    }
}
