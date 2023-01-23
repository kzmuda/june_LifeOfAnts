namespace Life.Geometry
{
    public static class DirectionExtensions
    {
        public static Direction TurnLeft(this Direction direction)
        {
            Direction result;
            if (direction == Direction.East)
            {
                result = Direction.North;
            }
            else if (direction == Direction.North)
            {
                result = Direction.West;
            }
            else if (direction == Direction.West)
            {
                result = Direction.South;
            }
            else
            {
                result = Direction.East;
            }

            return result;
        }

        public static Direction GetRandomDirection()
        {
            Random random = new Random();
            int i = random.Next(0, 3);

            return (Direction)i;
        }
    }
}
