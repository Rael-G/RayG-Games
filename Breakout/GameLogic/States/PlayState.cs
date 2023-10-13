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

        float x, y;
        int fontSize = 50;
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
            x = Window.Width * 0.90f - Raylib.MeasureText(_gameController.Score.ToString(), fontSize);
            y = Window.Height * 0.05f;

            if (!_gameController.Bricks.Any(b => b.Life > 0))
            {
                //VictoryState
            }

            if (_gameController.Health.Hearts <= 0)
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
            Raylib.DrawText(_gameController.Score.ToString(), (int)x, (int)y, fontSize, Color.WHITE);
            base.Canvas();
        }
    }
}
