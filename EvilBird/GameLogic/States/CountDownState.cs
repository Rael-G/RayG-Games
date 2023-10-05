using EvilBird.Enums;
using EvilBird.Resources;
using RayG;
using Raylib_cs;

namespace EvilBird.GameLogic.States
{
    internal class CountDownState : GameObject
    {
        GameStateRef GameStateRef;
        int Count;

        const int _fontSize = 100;
        int textSize;
        float timer;

        AudioManager _audioManager;

        public CountDownState(GameStateRef gameState, AudioManager audioManager) 
        {
            GameStateRef = gameState;
            _audioManager = audioManager;
        }

        public override void Start()
        {
            textSize = Raylib.MeasureText(Count.ToString(), _fontSize);
            timer = 1;
            Count = 3;
        }

        public override void Update()
        {
            timer -= Raylib.GetFrameTime();

            if (timer <= 0)
            {
                timer = 1;
                Count--;
                _audioManager.PlaySound("Countdown");

            }
            if (Count < 1)
            {
                GameStateRef.State = GameState.Play;
            }
        }

        public override void Canvas()
        {
            Raylib.DrawText(Count.ToString(), Window.Width / 2 - textSize / 2,
                Window.Height / 2 -_fontSize / 2, _fontSize, Color.WHITE);
            base.Canvas();
        }
    }
}
