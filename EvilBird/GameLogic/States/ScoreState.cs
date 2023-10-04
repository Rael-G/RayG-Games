using EvilBird.Enums;
using RayG;
using Raylib_cs;

namespace EvilBird.GameLogic.States
{
    internal class ScoreState : GameObject
    {
        GameStateRef GameStateRef { get; set; }

        public ScoreState(GameStateRef gameState) 
        {
            GameStateRef = gameState;
        }

        public override void Start()
        {
            base.Start();
        }

        public override void Update()
        {
            //Wait Some seconds
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                GameStateRef.State = GameState.CountDown;
            }
            base.Update();
        }

        public override void Canvas()
        {
            //Wait some seconds
            Raylib.DrawText("Press Space to Restart", Window.VirtualWidth / 2,
                Window.VirtualHeight / 2, 50, Color.WHITE);
            base.Canvas();
        }
    }
}
