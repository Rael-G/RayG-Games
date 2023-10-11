
using Raylib_cs;

namespace Breakout.Resources
{
    internal class SpriteSheet
    {
        int sectionWidth = 16;
        int sectionHeight = 8;

        public Sprite[,] Blocks { get; private set; }

        public SpriteSheet()
        {
            Blocks = new Sprite[5, 4];

            ArrangeBlueBlocks();
            ArrangeGreenBlocks();
            ArrangeRedBlocks();
            ArrangeVioletBlocks();
            ArrangeYellowBlocks();
        }

        private void ArrangeBlueBlocks()
        {
            int srcX = 0;
            Rectangle source;
            Sprite sprite;
            for (int i = 0; i < 4; i++)
            {
                source = new Rectangle(srcX, 0, sectionWidth, sectionHeight);
                sprite = new Sprite(source, 1);

                Blocks[0, i] = sprite;
                srcX += sectionWidth;
            }
        }

        private void ArrangeGreenBlocks()
        {
            int srcX = sectionWidth * 4;
            int srcY = 0;
            Rectangle source;
            Sprite sprite;
            for (int i = 0; i < 4; i++)
            {
                if (srcX >= sectionWidth * 6)
                {
                    srcX = 0;
                    srcY += sectionHeight;
                }
                source = new Rectangle(srcX, srcY, sectionWidth, sectionHeight);
                sprite = new Sprite(source, 1);

                Blocks[1, i] = sprite;
                srcX += sectionWidth;
            }
        }

        private void ArrangeRedBlocks()
        {
            int srcX = sectionWidth * 2;
            int srcY = sectionHeight;
            Rectangle source;
            Sprite sprite;
            for (int i = 0; i < 4; i++)
            {
                source = new Rectangle(srcX, srcY, sectionWidth, sectionHeight);
                sprite = new Sprite(source, 1);

                Blocks[2, i] = sprite;
                srcX += sectionWidth;
            }
        }

        private void ArrangeVioletBlocks()
        {
            int srcX = 0;
            int srcY = sectionHeight * 2;
            Rectangle source;
            Sprite sprite;
            for (int i = 0; i < 4; i++)
            {
                source = new Rectangle(srcX, srcY, sectionWidth, sectionHeight);
                sprite = new Sprite(source, 1);

                Blocks[3, i] = sprite;
                srcX += sectionWidth;
            }
        }

        private void ArrangeYellowBlocks()
        {
            int srcX = sectionWidth * 4;
            int srcY = sectionHeight * 2;
            Rectangle source;
            Sprite sprite;
            for (int i = 0; i < 4; i++)
            {
                if (srcX >= sectionWidth * 6)
                {
                    srcX = 0;
                    srcY += sectionHeight;
                }
                source = new Rectangle(srcX, srcY, sectionWidth, sectionHeight);
                sprite = new Sprite(source, 1);

                Blocks[4, i] = sprite;
                srcX += sectionWidth;
            }
        }
    }
}
