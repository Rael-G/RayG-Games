
using RayG;
using Raylib_cs;

namespace Breakout.Resources
{
    internal class SpriteSheetCustom : GameObject
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

        public const int Width = 16;
        public const int Height = 8;

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

        public SpriteSheetCustom(TextureManager textureManager)
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
            Bricks = ArrangeMatrix(Bricks, Green, Width * 4, 0, 1);
            Bricks = ArrangeMatrix(Bricks, Red, Width * 2, Height, 1);
            Bricks = ArrangeMatrix(Bricks, Violet, 0, Height * 2, 1);
            Bricks = ArrangeMatrix(Bricks, Yellow, Width * 4, Height * 2, 1);
            Bricks = ArrangeMatrix(Bricks, Black, Width * 2, Height * 3, 1);

            Paddles = ArrangeMatrix(Paddles, Small, 0, Height * 4, 1, true);
            Paddles = ArrangeMatrix(Paddles, Medium, Width, Height * 4, 2, true);
            Paddles = ArrangeMatrix(Paddles, Large, Width * 3, Height * 4, 3, true);
            Paddles = ArrangeMatrix(Paddles, ExtraLarge, 0, Height * 5, 4, true);

            Balls = ArrangeArray(Balls, 7, Width * 4, Height * 3, 4, 4);
            Hearts = ArrangeArray(Hearts, 2, Width * 4, Height * 5, Width / 2, Height);

            base.Awake();
        }

        private Sprite[,] ArrangeMatrix(Sprite[,] matrix, int matrixLeft, int srcX, int srcY, int size, bool paddle = false)
        {
            Rectangle source;
            Sprite sprite;

            for (int i = 0; i < 4; i++)
            {
                if (srcX >= Width * 6)
                {
                    srcX = 0;
                    srcY += Height;
                }

                source = new Rectangle(srcX, srcY, Width * size, Height);
                sprite = new Sprite(_texture, source, 1);
                matrix[matrixLeft, i] = sprite;
               
                if (!paddle)
                {
                    srcX += Width;
                }
                else
                {
                    srcY += Height * 2;
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
                if (srcX >= Width * 6)
                {
                    srcX = 0;
                    srcY += Height;
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
