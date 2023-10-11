using Breakout.GameLogic.States.Enums;

namespace Breakout.GameLogic.States
{
    internal class ServeState : StateBase
    {
        public ServeState(GameStateRef state) : base(state) { }

        public override void Start()
        {
            StateRef.State = GameState.Play;
            base.Start();
        }
    }
}
