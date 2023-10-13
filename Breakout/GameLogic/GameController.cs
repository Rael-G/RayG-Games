
using Breakout.Entities;
using Breakout.Resources;
using RayG;
using Raylib_cs;

namespace Breakout.GameLogic
{
    internal class GameController : GameObject
    {
        int Level;
        public bool Lost;
        public int Score { get; private set; }

        Paddle Paddle;
        Ball Ball;
        public Health Health;
        public List<Brick> Bricks;

        readonly SpriteSheet _spriteSheet;
        readonly SoundManager _soundManager;

        GameObject CollisionLayer;

        public GameController(SpriteSheet spriteSheet, SoundManager soundManager)
        {
            _spriteSheet = spriteSheet;
            _soundManager = soundManager;
            Score = 0;
        }

        public override void Start()
        {
            Lost = false;
            Paddle = new(_spriteSheet.Paddles[SpriteSheet.Medium, SpriteSheet.Blue]);
            Ball = new(_spriteSheet.Balls[Raylib.GetRandomValue(0, 6)], _soundManager);
            Health = new(_spriteSheet.Hearts[0], 3);
            var levelMaker = new LevelMaker(_soundManager, _spriteSheet);
            Bricks = levelMaker.RandomLevel();
            CollisionLayer = new();
            CollisionLayer.Children.AddStart(Paddle, Ball, Health);
            CollisionLayer.Children.AddRangeStart(Bricks);

            base.Start();
        }

        public override void Update()
        {
            if (Ball.Dead)
            {
                LostBall();
                Ball.Dead = false;
            }

            var deadBricks = Bricks.FindAll(b => b.Dead);
            if (deadBricks.Any())
            {
                foreach (var brick in deadBricks)
                {
                    IncreaseScore((brick.Tier + 1) * 10);
                    Bricks.Remove(brick);
                }
                
            }

            CollisionLayer.Collision();
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
            if (Health.Hearts > 0)
            {
                Health.Hearts--;
                Lost = true;
            }
        }
    }
}
