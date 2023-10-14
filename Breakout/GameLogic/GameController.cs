
using Breakout.Entities;
using Breakout.GameLogic.States.Enums;
using Breakout.Resources;
using RayG;
using Raylib_cs;
using System.Diagnostics.Metrics;
using System.Threading;
using System.Timers;

namespace Breakout.GameLogic
{
    internal class GameController : GameObject
    {
        public int Level;
        public bool Lost;
        public int Score { get; set; }
        private float _timer;
        public int Timer;

        Paddle Paddle;
        Ball Ball;
        public Ui Ui;
        public List<Brick> Bricks;

        readonly SpriteSheet _spriteSheet;
        readonly SoundManager _soundManager;
        LevelMaker _levelMaker;

        GameObject CollisionLayer;
        GameObject BricksLayer;

        public GameController(SpriteSheet spriteSheet, SoundManager soundManager)
        {
            _spriteSheet = spriteSheet;
            _soundManager = soundManager;
            Score = 0;
            Timer = 60;
        }

        public override void Start()
        {
            Level = 1;
            Lost = false;
            Paddle = new(_spriteSheet.Paddles[SpriteSheet.Medium, SpriteSheet.Blue]);
            Ball = new(_spriteSheet.Balls[Raylib.GetRandomValue(0, 6)], _soundManager);
            Ui = new(_spriteSheet.Hearts[0], 3);
            _levelMaker = new LevelMaker(_soundManager, _spriteSheet);
            Bricks = _levelMaker.RandomLevel(Level);
            CollisionLayer = new();
            BricksLayer = new();
            CollisionLayer.Children.AddStart(Paddle, Ball, Ui, BricksLayer);

            base.Start();
        }

        public override void Update()
        {
            Ui.Level = Level;
            Ui.Score = Score;
            Ui.Timer = Timer;
            if (Ball.Dead)
            {
                LostBall();
                Ball.Dead = false;
            }

            var deadBricks = Bricks.FindAll(b => b.Dead == true);
            //var deadBricks = Bricks.FindAll(b=> b.Dead == false);

            if (deadBricks.Any())
            {
                foreach (var brick in deadBricks)
                {
                    IncreaseScore((brick.Tier + 1) * 10);
                    Bricks.Remove(brick);
                    BricksLayer.Dispose(brick);
                }
                
            }

            TimerCount();
            CollisionLayer.Collision();
            base.Update();
        }

        public void Begin()
        {
            if (!Children.Contains(CollisionLayer))
            {
                Children.Add(CollisionLayer);
                Bricks = _levelMaker.RandomLevel(Level);
                BricksLayer.Children.AddRangeStart(Bricks);
            }
            Ball.Play();
        }
        public void GameOver()
        {
            Children.Remove(CollisionLayer);
            BricksLayer.Dispose();
        }

        private void TimerCount()
        {
            var deltatime = Raylib.GetFrameTime();
            _timer -= deltatime;

            if (_timer <= 0 && Timer > 0 && Ball.deltaY != 0)
            {
                _timer = 1;
                Timer--;
            }
        }

        public void IncreaseLevel()
        {
            BricksLayer.Dispose();
            Ball.Stop();
            Timer = 60;
            Level++;
            Bricks = _levelMaker.RandomLevel(Level);
            BricksLayer.Children.AddRangeStart(Bricks);
        }

        public void IncreaseScore(int points)
        {
            Score += points;
        }

        public void LostBall()
        {
            if (Ui.Hearts > 0)
            {
                Ui.Hearts--;
                Lost = true;
            }
        }
    }
}
