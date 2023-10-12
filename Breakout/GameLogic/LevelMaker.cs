using Breakout.Entities;
using Breakout.Resources;
using RayG;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.GameLogic
{
    internal class LevelMaker
    {
        SoundManager _soundManager;
        SpriteSheet _spriteSheet;
        public LevelMaker(SoundManager soundManager, SpriteSheet spriteSheet)
        {
            _spriteSheet = spriteSheet;
            _soundManager = soundManager;
        }

        public List<Brick> RandomLevel()
        {
            var bricks = new List<Brick>();
            var rows = Raylib.GetRandomValue(1, 5);
            var cols = Raylib.GetRandomValue(7, 15);
            var brickWidth = 17;
            var brickHeight = 9;

            var padding = Window.VirtualWidth * 0.10f + cols * brickWidth;
            var initialPosX = Window.VirtualWidth * 0.10f + (Window.VirtualWidth * 0.90f - padding) / 2;
            var pos = new Vector2(initialPosX, Window.VirtualHeight * 0.10f);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    var brick = new Brick(_soundManager, _spriteSheet.Bricks[SpriteSheet.Blue, 
                        SpriteSheet.Weak], SpriteSheet.Weak, pos);
                    bricks.Add(brick);
                    pos.X += brickWidth;
                }

                pos.X = initialPosX;
                pos.Y += brickHeight;
            }
            return bricks;
        }
    }
}
