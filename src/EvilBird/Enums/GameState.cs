namespace EvilBird.Enums
{
    internal enum GameState
    {
        Initial,
        Start,
        CountDown,
        Play,
        Score
    }

    internal class GameStateRef
    {
        public GameState State { get; set; }

        public GameStateRef(GameState state) 
        { 
            State = state;
        }
    }
}
