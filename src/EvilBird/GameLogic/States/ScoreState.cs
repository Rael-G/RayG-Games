using EvilBird.Enums;
using RayG;
using Raylib_cs;

namespace EvilBird.GameLogic.States
{
    internal class ScoreState : GameObject
    {
        string Corns { get; set; }
        GameStateRef GameStateRef;

        const string _caugthMsg = "You got Caught";
        const string _restartMsg = "Press Space to Restart";
        const int _fontSize = 100;

        int cornMsgSize;
        int caughtMsgSize;
        int restartMsgSize;

        public ScoreState(GameStateRef gameState, string corns) 
        {
            GameStateRef = gameState;
            Corns = corns;
        }

        public override void Start()
        {
            cornMsgSize = Raylib.MeasureText(Corns, _fontSize * 2);
            caughtMsgSize = Raylib.MeasureText(_caugthMsg, _fontSize);
            restartMsgSize = Raylib.MeasureText(_restartMsg, _fontSize);
            base.Start();
        }

        public override void Update()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.Space))
            {
                GameStateRef.State = GameState.CountDown;
            }
            base.Update();
        }

        public override void Canvas()
        {
            Raylib.DrawText(Corns.ToString(), Window.Width / 2 - cornMsgSize / 2,
                Window.Height * 25 / 100 - _fontSize / 2, _fontSize * 2, Color.White);

            Raylib.DrawText(_caugthMsg, Window.Width / 2 - caughtMsgSize / 2,
                Window.Height / 2 - _fontSize / 2, _fontSize, Color.White);

            Raylib.DrawText(_restartMsg, Window.Width / 2 - restartMsgSize / 2,
                Window.Height * 75 / 100 - _fontSize / 2, _fontSize, Color.White);
            base.Canvas();
        }
    }
}
