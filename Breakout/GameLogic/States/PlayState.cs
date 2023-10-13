using Breakout.Entities;
using Breakout.GameLogic.States.Enums;
using Breakout.Resources;
using RayG;
using Raylib_cs;

namespace Breakout.GameLogic.States
{
    internal class PlayState : StateBase
    {
        GameController _gameController;
        public PlayState(GameStateRef state, GameController controller) : base(state)
        {
            _gameController = controller;
        }

        public override void Start()
        {
            _gameController.Begin();
            base.Start();
        }

        public override void Update()
        {
            if (!_gameController.Bricks.Any(b => b.Life > 0))
            {
                //VictoryState
            }

            if (_gameController.Hearts <= 0)
            {
                StateRef.State = GameState.GameOver;
            }

            if (_gameController.Lost)
            {
                StateRef.State = GameState.Serve;
                _gameController.Lost = false;
            }

            base.Update();
        }
    }
}
