using EvilBird.Entities;
using EvilBird.Entities.Obstacles;
using EvilBird.Enums;
using RayG;
using Raylib_cs;

namespace EvilBird.GameLogic.States
{
    internal class PlayState : GameObject
    {
        GameStateRef GameStateRef { get; set; }
        Bird Bird { get; set; }
        ObstacleManager ObstacleManager { get; set; }

        public int Corns { get; private set; }

        const int _fontSize = 200;
        int _textSize;

        public PlayState(GameStateRef gameState, Bird bird, ObstacleManager obstacleManager)
        {
            GameStateRef = gameState;
            Bird = bird;
            ObstacleManager = obstacleManager;
            Corns = Bird.Corn;
        }

        public override void Start()
        {
            _textSize = Raylib.MeasureText(Corns.ToString(), _fontSize);

            Childs = new() { Bird,  ObstacleManager };
            base.Start();
        }

        public override void Update()
        {
            Corns = Bird.Corn;
            if (Bird._dead == true)
            {
                GameStateRef.State = GameState.Score;
            }
            this.Collision();
            base.Update();
        }

        public override void Canvas()
        {
            Raylib.DrawText(Corns.ToString(), Window.Width / 2 - _textSize / 2,
                Window.Height * 15/100 - _fontSize / 2, _fontSize, Color.WHITE);
            base.Canvas();
        }
    }
}
