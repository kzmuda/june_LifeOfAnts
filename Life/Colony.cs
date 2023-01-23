using Life.Ants;
using Life.Geometry;

namespace Life
{
    public class Colony
    {
        public int Width { get; }
        private List<Ant> ants;

        public Queen Queen { get; }

        public Colony(int width)
        {
            ants = new List<Ant>();
            this.Width = width;
            Position queenPosition = new Position(Width/2, Width/2);
            Queen = new Queen(this, queenPosition);
            ants.Add(Queen);
        }

        public void AddAnts(int numbersOfDrones, int numberOfWorkers, int numberOfSoldiers)
        {
            for (int i = 0; i < numbersOfDrones; i++)
            {
                ants.Add(new Drone(this, Position.GetRandomPosition(Width)));
            }

            for (int i = 0; i < numberOfWorkers; i++)
            {
                ants.Add(new Worker(this, Position.GetRandomPosition(Width)));
            }

            for (int i = 0; i < numberOfSoldiers; i++)
            {
                ants.Add(new Soldier(this, Position.GetRandomPosition(Width)));
            }
        }

        public void Update()
        {
            foreach (var ant in ants)
            {
                ant.Move();
            }
        }

        public void Display()
        {
            Console.Clear();
            DisplayColumnsHeader();

            for (int row = 0; row < Width; row++)
            {
                DisplayRowNumber(row);
                DisplayAntsInRow(row);
                Console.Out.WriteLine("|");
            }

            DisplayColonyState();
        }

        private void DisplayAntsInRow(int rowNumber)
        {
            for (int x = 0; x < Width; x++)
            {
                string symbol = GetSymbolFromPosition(x, rowNumber);
                Console.Out.Write($"|{symbol} ");
            }
        }

        private static void DisplayRowNumber(int rowNumber)
        {
            rowNumber++;
            Console.Out.Write($"{rowNumber}");
            if (rowNumber < 10)
            {
                Console.Out.Write(" ");
            }
        }

        private void DisplayColumnsHeader()
        {
            Console.Out.Write("  ");
            for (int i = 0; i < Width; i++)
            {
                Console.Out.Write($" {(char)(i + 65)} ");
            }
            Console.Out.WriteLine("");
        }

        private string GetSymbolFromPosition(int x, int y)
        {
            Position position = new Position(x, y);
            foreach (var ant in ants)
            {
                if (ant.Position.IsEqual(position))
                {
                    return ant.Symbol;
                }
            }

            return " ";
        }

        private void DisplayColonyState()
        {
            Console.Out.WriteLine();
            foreach (var ant in ants)
            {
                string antState = ant.GetState();
                if (!string.IsNullOrEmpty(antState))
                {
                    Console.Out.WriteLine($"{ant.GetType().Name}: {antState}");
                }
            }
        }
    }
}
