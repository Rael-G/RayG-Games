using Breakout.GameLogic.States.Enums;

namespace Breakout.GameLogic.States
{
    internal class EnterHighScoreState : StateBase
    {
        public EnterHighScoreState(GameStateRef state) : base(state)
        {

        }

        public override void Start()
        {
            StateRef.State = GameState.Start;
            base.Start();
        }
    }
}
