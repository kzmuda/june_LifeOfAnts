using Life.Geometry;

namespace Life.Ants
{
    public class Queen : Ant
    {
        private const int GOOD_MOOD_MIN = 50;
        private const int GOOD_MOOD_MAX = 100;

        private int goodMoodCountdown;
        private bool isMating;

        public Queen(Colony colony, Position position) : base(colony, "Q", position)
        {
            SetGoodMoodCountdown();
        }

        public bool IsInGoodMood()
        {
            return this.goodMoodCountdown == 0 && !isMating;
        }

        public void StartMate()
        {
            isMating = true;
        }

        public void StopMate()
        {
            isMating = false;
            SetGoodMoodCountdown();
        }

        public override void Move()
        {
            if (goodMoodCountdown > 0)
            {
                goodMoodCountdown--;
            }
        }

        public override string GetState()
        {
            if (isMating)
            {
                return "is mating";
            }

            if (IsInGoodMood())
            {
                return "is in good mood";
            }

            return $"will be in good mood after {this.goodMoodCountdown}";
            
        }

        private void SetGoodMoodCountdown()
        {
            this.goodMoodCountdown = new Random().Next(GOOD_MOOD_MIN, GOOD_MOOD_MAX);
        }
    }
}
