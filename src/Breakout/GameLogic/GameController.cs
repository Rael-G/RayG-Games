using Breakout.Entities;
using Breakout.Resources;
using RayG;
using Raylib_cs;

namespace Breakout.GameLogic
{
    internal class GameController : GameObject
    {
        public int Level { get; private set; }
        public bool Lost { get; set; }
        public int Score { get; set; }

        public Ui Ui { get; private set; }
        public List<Brick> Bricks { get; private set; }

        private float _timer;
        public int Timer { get; private set; }

        Paddle Paddle;
        Ball Ball;
        
        readonly SpriteSheetCustom _spriteSheet;
        readonly SoundManager _soundManager;
        readonly ParticleSystem _particleSystem;
        LevelMaker _levelMaker;

        GameObject CollisionLayer;
        GameObject BricksLayer;

        public GameController(SpriteSheetCustom spriteSheet, SoundManager soundManager)
        {
            _spriteSheet = spriteSheet;
            _soundManager = soundManager;
            _particleSystem = new ParticleSystem();
            Score = 0;
            Timer = 60;
            Level = 1;
        }

        public override void Start()
        {
            Paddle = new(_spriteSheet.Paddles[SpriteSheetCustom.Medium, SpriteSheetCustom.Blue]);
            Ball = new(_spriteSheet.Balls[Raylib.GetRandomValue(0, 6)], _soundManager);
            Ui = new(_spriteSheet.Hearts[0], 3);

            _levelMaker = new LevelMaker(_soundManager, _spriteSheet, _particleSystem);
            Bricks = _levelMaker.RandomLevel(Level);
            CollisionLayer = new();
            BricksLayer = new();

            CollisionLayer.Children.AddStart(Paddle, Ball, Ui, BricksLayer);
            Children.Add(_particleSystem);
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

            foreach(var b in Bricks) 
            {
                Score += b.Score;
                b.Score = 0;
            }

            var deadBricks = Bricks.FindAll(b => b.Dead == true);

            if (deadBricks.Any())
            {
                foreach (var brick in deadBricks)
                {
                    Bricks.Remove(brick);
                    BricksLayer.Dispose(brick);
                }
                
            }

            TimerCount();
            CollisionLayer.StartCollision();
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

        public void IncreaseLevel()
        {
            BricksLayer.Dispose();
            Ball.Stop();
            Timer = 60;
            Level++;
            Bricks = _levelMaker.RandomLevel(Level);
            BricksLayer.Children.AddRangeStart(Bricks);
        }

        private void LostBall()
        {
            if (Ui.Hearts > 0)
            {
                Ui.Hearts--;
                Lost = true;
            }
        }

        private void TimerCount()
        {
            var deltatime = Raylib.GetFrameTime();
            _timer -= deltatime;

            if (_timer <= 0 && Timer > 0 && Ball.DeltaY != 0)
            {
                _timer = 1;
                Timer--;
            }
        }
    }
}
