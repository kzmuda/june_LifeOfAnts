using static System.Net.Mime.MediaTypeNames;

namespace Life.Geometry
{
    public class Position
    {
        public int X { get; }

        public int Y { get; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Direction DirectionTowards(Position position)
        {
            if (this.Y > position.Y)
            {
                return Direction.North;
            }
            else if (this.Y < position.Y)
            {
                return Direction.South;
            }
            else
            {
                if (this.X > position.X)
                {
                    return Direction.West;
                }
                else if (this.X < position.X)
                {
                    return Direction.East;
                }

                return Direction.North;
            }
        }

        public int DistanceTo(Position other)
        {
            return Math.Abs(X - other.X) + Math.Abs(Y - other.Y);
        }

        public static Position GetRandomPosition(int colonyWidth)
        {
            Random random = new Random();
            int x = random.Next(0, colonyWidth - 1);
            int y = random.Next(0, colonyWidth - 1);

            return new Position(x, y);
        }

        public bool IsEqual(Position other)
        {
            return this.X == other.X && this.Y == other.Y;
        }

        public bool IsInRange(int height, int width)
        {
            return this.X >= 0 && this.Y >= 0 && this.X < width && this.Y < height;
        }

        public Position NextInDirection(Direction direction)
        {
            if (direction == Direction.North)
            {
                return new Position(this.X, this.Y - 1);
            }
            else if (direction == Direction.South)
            {
                return new Position(this.X, this.Y + 1);
            }
            else if (direction == Direction.West)
            {
                return new Position(this.X - 1, this.Y);
            }
            else
            {
                return new Position(this.X + 1, this.Y);
            }

        }
    }
}
