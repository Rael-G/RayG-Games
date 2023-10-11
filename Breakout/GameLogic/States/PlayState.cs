using Breakout.Entities;
using Breakout.GameLogic.States.Enums;
using Breakout.Resources;

namespace Breakout.GameLogic.States
{
    internal class PlayState : StateBase
    {
        SpriteSheet _spriteSheet;
        Sprite paddleSprite;
        Paddle Paddle;

        public PlayState(GameStateRef state, SpriteSheet spriteSheet) : base(state)
        {
            _spriteSheet = spriteSheet;
        }

        public override void Start()
        {
            Paddle = new(_spriteSheet.Paddles[SpriteSheet.Medium, SpriteSheet.Blue]);
            Childs.Add(Paddle);
            base.Start();
        }
    }
}
