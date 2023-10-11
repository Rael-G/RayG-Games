using Breakout.GameLogic.States.Enums;

namespace Breakout.GameLogic.States
{
    internal class PaddleSelectState : StateBase
    {
        public PaddleSelectState(GameStateRef state) : base(state) { }

        public override void Start()
        {
            StateRef.State = GameState.Serve;
            base.Start();
        }
    }
}
