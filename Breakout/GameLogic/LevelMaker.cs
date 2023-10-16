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

        const int brickWidth = 17;
        const int brickHeight = 9;

        public LevelMaker(SoundManager soundManager, SpriteSheet spriteSheet)
        {
            _spriteSheet = spriteSheet;
            _soundManager = soundManager;
        }

        public List<Brick> RandomLevel(int level)
        {
            var bricks = new List<Brick>();
            var highestTier = Math.Min(SpriteSheet.Strongest, level / 5);
            var highestColor = Math.Min(SpriteSheet.Yellow, level % 5 + 3);
            var rows = Raylib.GetRandomValue(3, 5);
            var cols = Raylib.GetRandomValue(7, 15);

            var padding = Window.VirtualWidth * 0.10f + cols * brickWidth;
            var initialPosX = Window.VirtualWidth * 0.10f + (Window.VirtualWidth * 0.90f - padding) / 2;
            var pos = new Vector2(initialPosX, Window.VirtualHeight * 0.10f);

            for (int i = 0; i < rows; i++)
            {
                var skipPattern = Raylib.GetRandomValue(0, 1) != 0;
                var alternatePattern = Raylib.GetRandomValue(0, 1) != 0;

                var skipFlag = Raylib.GetRandomValue(0, 1) != 0;
                var alternateFlag = Raylib.GetRandomValue(0, 1) != 0;

                var alternateColor1 = Raylib.GetRandomValue(0, highestColor);
                var alternateColor2 = Raylib.GetRandomValue(0, highestColor);
                var alternateTier1 = Raylib.GetRandomValue(0, highestTier);
                var alternateTier2 = Raylib.GetRandomValue(0, highestTier);

                var solidColor = Raylib.GetRandomValue(0, highestColor);
                var solidTier = Raylib.GetRandomValue(0, highestTier);

                for (int j = 0; j < cols; j++)
                {
                    if (SkipHandler(skipPattern, ref skipFlag))
                    {
                        pos.X += brickWidth;
                        continue;
                    }

                    ColorTierHandler(out int color, out int tier, alternatePattern, ref alternateFlag,
                        solidColor, solidTier, alternateColor1, alternateColor2, alternateTier1, alternateTier2);
                    
                    var brick = new Brick(_soundManager, _spriteSheet.Bricks[color,
                        tier], tier, pos);

                    bricks.Add(brick);
                    pos.X += brickWidth;
                }

                pos.X = initialPosX;
                pos.Y += brickHeight;
            }
            return bricks;
        }

        private static bool SkipHandler(bool skipPattern, ref bool skipFlag)
        {
            if (skipPattern && skipFlag)
            {
                skipFlag = false;
                return false;
            }
            else if (skipPattern)
            {
                skipFlag = true;
                return true;
            }

            return false;
        }

        private static void ColorTierHandler(out int color, out int tier, bool alternatePattern, 
            ref bool alternateFlag, int solidColor, int solidTier, int alternateColor1, int alternateColor2,
            int alternateTier1, int alternateTier2) 
        {
            if (alternatePattern && alternateFlag)
            {
                alternateFlag = false;
                color = alternateColor1;
                tier = alternateTier1;
            }
            else if (alternatePattern)
            {
                alternateFlag = true;
                color = alternateColor2;
                tier = alternateTier2;
            }
            else
            {
                color = solidColor;
                tier = solidTier;
            }
        }
    }
}
