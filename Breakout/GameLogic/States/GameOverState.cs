using Breakout.GameLogic.States.Enums;

namespace Breakout.GameLogic.States
{
    internal class GameOverState : StateBase
    {
        GameController _gameController;

        public GameOverState(GameStateRef state, GameController gameController) : base(state)
        {
            _gameController = gameController;
        }
        public override void Start()
        {
            _gameController.GameOver();
            StateRef.State = GameState.EnterHighScore;
            base.Start();
        }
    }
}
