using EvilBird.Entities;
using EvilBird.Entities.Obstacles;
using EvilBird.Enums;
using RayG;
using Raylib_cs;

namespace EvilBird.GameLogic.States
{
    internal class PlayState : GameObject
    {
        GameStateRef GameStateRef;
        Bird Bird;
        ObstacleManager ObstacleManager;

        public int Corns { get; private set; }

        const int _fontSize = 200;
        int textSize;

        public PlayState(GameStateRef gameState, Bird bird, ObstacleManager obstacleManager)
        {
            GameStateRef = gameState;
            Bird = bird;
            ObstacleManager = obstacleManager;
            Corns = Bird.Corn;
        }

        public override void Start()
        {
            textSize = Raylib.MeasureText(Corns.ToString(), _fontSize);

            Children = new() { Bird,  ObstacleManager };
            base.Start();
        }

        public override void Update()
        {
            Corns = Bird.Corn;
            if (Bird.Dead == true)
            {
                GameStateRef.State = GameState.Score;
            }
            this.Collision();
            base.Update();
        }

        public override void Canvas()
        {
            Raylib.DrawText(Corns.ToString(), Window.Width / 2 - textSize / 2,
                Window.Height * 15/100 - _fontSize / 2, _fontSize, Color.WHITE);
            base.Canvas();
        }
    }
}
