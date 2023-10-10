using RayG;

namespace Breakout.GameLogic.States
{
    internal class StartState : GameObject
    {
        GameStateRef State { get; set; }

        public StartState(GameStateRef state) 
        {
            State = state;
        }
    }
}
