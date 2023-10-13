using Breakout.GameLogic.States.Enums;
using RayG;
using Raylib_cs;

namespace Breakout.GameLogic.States
{
    internal class ServeState : StateBase
    {
        public ServeState(GameStateRef state) : base(state) { }

        const string msg = "Press Space";
        int width;
        int fontSize = 100;

        public override void Start()
        {
            width = Raylib.MeasureText(msg, fontSize);
            base.Start();
        }

        public override void Update()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                StateRef.State = GameState.Play;
            }
            base.Update();
        }

        public override void Canvas()
        {
            Raylib.DrawText(msg, Window.Width / 2 - width / 2, Window.Height / 2, fontSize, Color.WHITE);
            base.Canvas();
        }
    }
}
