using Breakout.Entities;
using Breakout.GameLogic.States.Enums;
using Breakout.Resources;
using RayG;
using Raylib_cs;

namespace Breakout.GameLogic.States
{
    internal class PlayState : StateBase
    {
        SpriteSheet _spriteSheet;
        Paddle Paddle;
        Ball Ball;
        List<Brick> Bricks;

        GameObject CollisionLayer;

        SoundManager _soundManager;

        public PlayState(GameStateRef state, SpriteSheet spriteSheet, SoundManager soundManager) : base(state)
        {
            _spriteSheet = spriteSheet;
            _soundManager = soundManager;
        }

        public override void Start()
        {
            Paddle = new(_spriteSheet.Paddles[SpriteSheet.Medium, SpriteSheet.Blue]);
            Ball = new(_spriteSheet.Balls[Raylib.GetRandomValue(0, 6)], _soundManager);
            CollisionLayer = new() { Childs = { Paddle, Ball } };
            Childs.Add(CollisionLayer);

            var levelMaker = new LevelMaker(_soundManager, _spriteSheet);

            Bricks = levelMaker.RandomLevel();
            CollisionLayer.Childs.AddRange(Bricks);

            base.Start();
            Ball.Play();
        }

        public override void Update()
        {
            if (!Bricks.Any(b => b.Life > 0))
            {
                //Victory
            }

            CollisionLayer.Collision();
            base.Update();
        }
    }
}
