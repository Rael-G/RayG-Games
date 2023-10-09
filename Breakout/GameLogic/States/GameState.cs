namespace Breakout.GameLogic.States
{
    internal enum GameState
    {
        Start,
        PaddleSelect,
        Serve,
        Play,
        Victory,
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