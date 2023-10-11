
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

        //  Color 0-4 / Strenght 0-3
        public Sprite[,] Blocks { get; private set; }

        /// <summary>
        ///   Size 0-3 / Color 0-3
        /// </summary>
        public Sprite[,] Paddles { get; private set; }

        TextureManager _textureManager;
        Texture2D _texture;

        public SpriteSheet(TextureManager textureManager)
        {
            _textureManager = textureManager;

            Blocks = new Sprite[5, 4];
            Paddles = new Sprite[4, 4];
        }

        public override void Awake()
        {
            _texture = _textureManager.GetTexture("Breakout");

            Blocks = Arrange(Blocks, Blue, 0, 0, 1);
            Blocks = Arrange(Blocks, Green, sectionWidth * 4, 0, 1);
            Blocks = Arrange(Blocks, Red, sectionWidth * 2, sectionHeight, 1);
            Blocks = Arrange(Blocks, Violet, 0, sectionHeight * 2, 1);
            Blocks = Arrange(Blocks, Yellow, sectionWidth * 4, sectionHeight * 2, 1);

            Paddles = Arrange(Paddles, Small, 0, sectionHeight * 4, 1, true);
            Paddles = Arrange(Paddles, Medium, sectionWidth, sectionHeight * 4, 2, true);
            Paddles = Arrange(Paddles, Large, sectionWidth * 3, sectionHeight * 4, 3, true);
            Paddles = Arrange(Paddles, ExtraLarge, 0, sectionHeight * 5, 4, true);

            base.Awake();
        }

        private Sprite[,] Arrange(Sprite[,] matrix, int matrixLeft, int srcX, int srcY, int size, bool paddle = false)
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
    }
}
