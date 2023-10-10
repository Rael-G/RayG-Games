using RayG;

namespace Breakout.GameLogic.States
{
    internal class HighScoreState : GameObject
    {
        GameStateRef State { get; set; }

        public HighScoreState(GameStateRef state)
        {
            State = state;
        }
    }
}
