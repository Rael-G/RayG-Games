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

            base.Start();
            Ball.Play();
        }

        public override void Update()
        {
            CollisionLayer.Collision();
            base.Update();
        }
    }
}
