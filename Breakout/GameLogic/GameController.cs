
using Breakout.Entities;
using Breakout.Resources;
using RayG;
using Raylib_cs;

namespace Breakout.GameLogic
{
    internal class GameController : GameObject
    {
        int Level;
        public int Hearts { get; private set; }
        public int Score { get; private set; }
        public bool Lost { get; set; }

        Paddle Paddle;
        Ball Ball;
        Health Health;
        public List<Brick> Bricks;

        readonly SpriteSheet _spriteSheet;
        readonly SoundManager _soundManager;

        GameObject CollisionLayer;

        public GameController(SpriteSheet spriteSheet, SoundManager soundManager)
        {
            _spriteSheet = spriteSheet;
            _soundManager = soundManager;
            Hearts = 3;
            Score = 0;
        }

        public override void Start()
        {
            Paddle = new(_spriteSheet.Paddles[SpriteSheet.Medium, SpriteSheet.Blue]);
            Ball = new(_spriteSheet.Balls[Raylib.GetRandomValue(0, 6)], _soundManager, this);
            Health = new(this, _spriteSheet.Hearts[0]);
            var levelMaker = new LevelMaker(_soundManager, _spriteSheet);
            Bricks = levelMaker.RandomLevel();
            CollisionLayer = new();
            CollisionLayer.Children.AddStart(Paddle);
            CollisionLayer.Children.AddStart(Ball);
            CollisionLayer.Children.AddStart(Health);
            CollisionLayer.Children.AddRange(Bricks);

            base.Start();
        }

        public override void Update()
        {
            this.Collision();
            base.Update();
        }

        public void Begin()
        {
            if (!Children.Contains(CollisionLayer))
            {
                Children.Add(CollisionLayer);
            }

            Ball.Play();
        }
        public void GameOver()
        {
            Children.Remove(CollisionLayer);
        }

        public void IncreaseScore(int points)
        {
            Score += points;
        }

        public void LostBall()
        {
            if (Hearts > 0)
            {
                Hearts--;
                Lost = true;
            }
        }
    }
}
