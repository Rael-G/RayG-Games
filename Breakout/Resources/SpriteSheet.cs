
using RayG;
using Raylib_cs;

namespace Breakout.Resources
{
    internal class SpriteSheet : GameObject
    {
        //Colors
        public const int Blue = 0;
        public const int Green = 1;
        public const int Red = 2;
        public const int Violet = 3;
        public const int Yellow = 4;
        public const int Black = 5;
        public const int Orange = 6;

        //Strenght
        public const int Weak = 0;
        public const int Medium = 1;
        public const int Strong = 2;
        public const int Strongest = 3;

        //Size
        public const int Small = 0;
        //public const int Medium = 1;
        public const int Large = 2;
        public const int ExtraLarge = 3;

        int sectionWidth = 16;
        int sectionHeight = 8;

        /// <summary>
        ///  Color 0-5 / Strenght 0-3;
        ///  Colors: Blue, Freen, Red, Violet, Yellow, Black;\n
        ///  Tier: Weak, Medium, Strong, Strongest;
        ///  Obs: Black Tier > Weak will throw junt
        /// </summary>
        public Sprite[,] Bricks { get; private set; }

        /// <summary>
        ///   Size 0-3 / Color 0-3
        ///   Size: Small, Medium, Large, ExtraLarge
        ///   Colors: Blue, Freen, Red, Violet
        /// </summary>
        public Sprite[,] Paddles { get; private set; }

        /// <summary>
        /// Color 0-6
        /// Colors: Blue, Freen, Red, Violet, Yellow, Black, Orange
        /// </summary>
        public Sprite[] Balls { get; private set; }

        /// <summary>
        /// color 0-1
        /// colors: red, black
        /// </summary>
        public Sprite[] Hearts { get; private set; }

        TextureManager _textureManager;
        Texture2D _texture;

        public SpriteSheet(TextureManager textureManager)
        {
            _textureManager = textureManager;

            Bricks = new Sprite[6, 4];
            Paddles = new Sprite[4, 4];
            Balls = new Sprite[7];
            Hearts = new Sprite[2];
        }

        public override void Awake()
        {
            _texture = _textureManager.GetTexture("Breakout");

            Bricks = ArrangeMatrix(Bricks, Blue, 0, 0, 1);
            Bricks = ArrangeMatrix(Bricks, Green, sectionWidth * 4, 0, 1);
            Bricks = ArrangeMatrix(Bricks, Red, sectionWidth * 2, sectionHeight, 1);
            Bricks = ArrangeMatrix(Bricks, Violet, 0, sectionHeight * 2, 1);
            Bricks = ArrangeMatrix(Bricks, Yellow, sectionWidth * 4, sectionHeight * 2, 1);
            Bricks = ArrangeMatrix(Bricks, Black, sectionWidth * 2, sectionHeight * 3, 1);

            Paddles = ArrangeMatrix(Paddles, Small, 0, sectionHeight * 4, 1, true);
            Paddles = ArrangeMatrix(Paddles, Medium, sectionWidth, sectionHeight * 4, 2, true);
            Paddles = ArrangeMatrix(Paddles, Large, sectionWidth * 3, sectionHeight * 4, 3, true);
            Paddles = ArrangeMatrix(Paddles, ExtraLarge, 0, sectionHeight * 5, 4, true);

            Balls = ArrangeArray(Balls, 7, sectionWidth * 4, sectionHeight * 3, 4, 4);
            Hearts = ArrangeArray(Hearts, 2, sectionWidth * 4, sectionHeight * 5, sectionWidth / 2, sectionHeight);

            base.Awake();
        }

        private Sprite[,] ArrangeMatrix(Sprite[,] matrix, int matrixLeft, int srcX, int srcY, int size, bool paddle = false)
        {
            Rectangle source;
            Sprite sprite;

            for (int i = 0; i < 4; i++)
            {
                if (srcX >= sectionWidth * 6)
                {
                    srcX = 0;
                    srcY += sectionHeight;
                }

                source = new Rectangle(srcX, srcY, sectionWidth * size, sectionHeight);
                sprite = new Sprite(_texture, source, 1);
                matrix[matrixLeft, i] = sprite;
               
                if (!paddle)
                {
                    srcX += sectionWidth;
                }
                else
                {
                    srcY += sectionHeight * 2;
                }
            }

            return matrix;
        }

        private Sprite[] ArrangeArray(Sprite[] array, int quantity, int srcX, int srcY, int width, int height)
        {
            Rectangle source;
            Sprite sprite;

            for (int i = 0; i < quantity; i++)
            {
                if (srcX >= sectionWidth * 6)
                {
                    srcX = 0;
                    srcY += sectionHeight;
                }

                source = new Rectangle(srcX, srcY, width, height);
                sprite = new Sprite(_texture, source, 1);
                array[i] = sprite;
                srcX += width;
            }

            return array;
        }
    }
}
