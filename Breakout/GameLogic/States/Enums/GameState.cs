namespace Breakout.GameLogic.States.Enums
{
    internal enum GameState
    {
        Start,
        PaddleSelect,
        Serve,
        Play,
        GameOver,
        EnterHighScore,
        HighScore
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