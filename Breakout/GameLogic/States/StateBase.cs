using Breakout.GameLogic.States.Enums;
using RayG;

namespace Breakout.GameLogic.States
{
    internal abstract class StateBase : GameObject
    {
        protected GameStateRef StateRef { get; set; }

        protected StateBase(GameStateRef state)
        {
            StateRef = state;
        }
    }
}
