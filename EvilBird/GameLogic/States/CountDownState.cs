using EvilBird.Enums;
using RayG;
using Raylib_cs;

namespace EvilBird.GameLogic.States
{
    internal class CountDownState : GameObject
    {
        GameStateRef GameStateRef { get; set; }
        int Count { get; set; }

        const int _fontSize = 100;
        int _textSize;
        float _timer;

        public CountDownState(GameStateRef gameState) 
        {
            GameStateRef = gameState;
        }

        public override void Start()
        {
            _textSize = Raylib.MeasureText(Count.ToString(), _fontSize);
            _timer = 1;
            Count = 3;
        }

        public override void Update()
        {
            _timer -= Raylib.GetFrameTime();

            if (_timer <= 0)
            {
                _timer = 1;
                Count--;
            }
            if (Count < 1)
            {
                GameStateRef.State = GameState.Play;
            }
        }

        public override void Canvas()
        {
            Raylib.DrawText(Count.ToString(), Window.Width / 2 - _textSize / 2,
                Window.Height / 2 -_fontSize / 2, _fontSize, Color.WHITE);
            base.Canvas();
        }
    }
}
