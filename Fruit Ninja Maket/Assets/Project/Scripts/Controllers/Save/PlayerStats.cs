namespace Project.Scripts.Controllers.Save
{
    public class PlayerStats
    {
        public int BestScore { get; private set; }

        public bool IsSaveChanged { get; private set; }
        
        public PlayerStats(int bestScore)
        {
            BestScore = bestScore;
            IsSaveChanged = false;
        }

        public void SetBestScore(int value)
        {
            if (value < 0) return;

            IsSaveChanged = true;
            BestScore = value;
        }
    }
}