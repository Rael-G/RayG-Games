using Breakout.GameLogic.States.Enums;
using RayG;
using Raylib_cs;

namespace Breakout.GameLogic.States
{
    internal class GameOverState : StateBase
    {
        readonly GameController _gameController;

        public GameOverState(GameStateRef state, GameController gameController) : base(state)
        {
            _gameController = gameController;
        }

        const string msg = "Game Over";
        int width;
        int fontSize = 100;

        public override void Start()
        {
            width = Raylib.MeasureText(msg, fontSize);
            _gameController.GameOver();
            base.Start();
        }

        public override void Update()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.Space))
            {
                StateRef.State = GameState.EnterHighScore;
            }
            base.Update();
        }

        public override void Canvas()
        {
            Raylib.DrawText(msg, Window.Width / 2 - width / 2, Window.Height / 2, fontSize, Color.White);
            base.Canvas();
        }
    }
}
