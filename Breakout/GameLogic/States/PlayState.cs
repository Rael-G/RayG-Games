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
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE))
            {
                StateRef.State = GameState.GameOver;
            }

            if (!_gameController.Bricks.Any())
            {
                _gameController.Score += (int)(_gameController.Timer * _gameController.Level);
                _gameController.IncreaseLevel();
                StateRef.State = GameState.Serve;
            }
            else if(_gameController.Timer <= 0)
            {
                _gameController.IncreaseLevel();
                StateRef.State = GameState.Serve;
            }
            else if (_gameController.Ui.Hearts <= 0)
            {
                StateRef.State = GameState.GameOver;
            }
            else if (_gameController.Lost)
            {
                StateRef.State = GameState.Serve;
                _gameController.Lost = false;
            }

            base.Update();
        }

        public override void Canvas()
        {
            
            base.Canvas();
        }
    }
}
