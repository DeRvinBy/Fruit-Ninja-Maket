namespace Project.Scripts.Controllers.Save
{
    public class PlayerStats
    {
        public int BestScore { get; private set; }

        public PlayerStats(int bestScore)
        {
            BestScore = bestScore;
        }

        public void SetBestScore(int value)
        {
            if (value < 0) return;

            BestScore = value;
        }
    }
}