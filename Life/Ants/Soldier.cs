using Life.Geometry;

namespace Life.Ants
{
    public class Soldier : Ant
    {
        private Direction lastStepDirection;
        public Soldier(Colony colony, Position position) : base(colony, "S", position)
        {
            this.lastStepDirection = DirectionExtensions.GetRandomDirection();
        }

        public override void Move()
        {
            Direction nextDirection = lastStepDirection.TurnLeft();
            MoveToDirection(nextDirection);
            lastStepDirection = nextDirection;
        }
    }
}
