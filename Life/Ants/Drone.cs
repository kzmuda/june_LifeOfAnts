using Life.Geometry;

namespace Life.Ants
{
    public class Drone : Ant
    {
        private bool isMating = false;
        private int matingCounter = 0;
        private string droneState = string.Empty;
        public Drone(Colony colony, Position position) : base(colony, "D", position)
        {
        }

        public override void Move()
        {
            Queen queen = Colony.Queen;
            this.droneState = "";
            if (isMating)
            {
                ContinueMating(queen);
            }
            else if (this.Position.DistanceTo(queen.Position) > 1)
            {
                MoveToQueen(queen);
            }
            else
            {
                TryMating(queen);
            }
        }

        private void TryMating(Queen queen)
        {
            if (queen.IsInGoodMood())
            {
                droneState = "HALLELUJAH!";
                this.matingCounter = 10;
                queen.StartMate();
                this.isMating = true;
            }
            else
            {
                droneState = ":(";
                ResetPosition();
            }
        }

        public override string GetState()
        {
            return this.droneState;
        }

        private void MoveToQueen(Queen queen)
        {
            Direction direction = this.Position.DirectionTowards(queen.Position);
            MoveToDirection(direction);
        }

        private void ContinueMating(Queen queen)
        {
            if (matingCounter > 0)
            {
                matingCounter--;
                droneState = $"Mating, time left {matingCounter}";
            }
            else
            {
                isMating = false;
                ResetPosition();
                queen.StopMate();
            }
        }

        private void ResetPosition()
        {
            this.Position = Position.GetRandomPosition(this.Colony.Width);
        }
    }
}
