using EvilBird.Enums;
using RayG;
using Raylib_cs;

namespace EvilBird.GameLogic.States
{
    internal class ScoreState : GameObject
    {
        GameStateRef GameStateRef { get; set; }
        string Corns { get; set; }

        const string _caugthMsg = "You got caught";
        const string _restartMsg = "Press Space to Restart";
        const int _fontSize = 100;

        int _cornMsgSize;
        int _caughtMsgSize;
        int _restartMsgSize;

        public ScoreState(GameStateRef gameState, string corns) 
        {
            GameStateRef = gameState;
            Corns = corns;
        }

        public override void Start()
        {
            _cornMsgSize = Raylib.MeasureText(Corns, _fontSize * 2);
            _caughtMsgSize = Raylib.MeasureText(_caugthMsg, _fontSize);
            _restartMsgSize = Raylib.MeasureText(_restartMsg, _fontSize);
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
            Raylib.DrawText(Corns.ToString(), Window.Width / 2 - _cornMsgSize / 2,
                Window.Height * 25 / 100 - _fontSize / 2, _fontSize * 2, Color.WHITE);

            Raylib.DrawText(_caugthMsg, Window.Width / 2 - _caughtMsgSize / 2,
                Window.Height / 2 - _fontSize / 2, _fontSize, Color.WHITE);

            Raylib.DrawText(_restartMsg, Window.Width / 2 - _restartMsgSize / 2,
                Window.Height * 75 / 100 - _fontSize / 2, _fontSize, Color.WHITE);
            base.Canvas();
        }
    }
}
