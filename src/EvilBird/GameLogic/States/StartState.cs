using EvilBird.Enums;
using RayG;
using Raylib_cs;

namespace EvilBird.GameLogic.States
{
    internal class StartState : GameObject
    {
        GameStateRef GameStateRef;

        const string _msg = "Press Space to Begin";
        const int _fontSize = 100;
        int textSize;

        public StartState(GameStateRef gameState)
        {
            GameStateRef = gameState;
        }

        public override void Start()
        {
            textSize = Raylib.MeasureText(_msg, _fontSize);
            base.Start();
        }

        public override void Update()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.Space))
            {
                GameStateRef.State = GameState.CountDown;
            }
        }

        public override void Canvas()
        {
            Raylib.DrawText(_msg, Window.Width / 2 - textSize / 2, 
                Window.Height / 2 - _fontSize / 2, _fontSize, Color.White);
            base.Canvas();
        }
    }
}
