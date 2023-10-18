namespace Breakout.Resources
{
    public record Score
    {
        public string PlayerName { get; }
        public int HighScore { get; }

        public Score(string playerName, int highScore)
        {
            PlayerName = playerName;
            HighScore = highScore;
        }

        public override string ToString()
        {
            return PlayerName + " : " + HighScore;
        }
    }
}
