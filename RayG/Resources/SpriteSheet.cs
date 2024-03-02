using Raylib_cs;

namespace RayG
{
    public class SpriteSheet : GameObject
    {
        readonly Texture2D _texture;

        public SpriteSheet(Texture2D texture)
        {
            _texture = texture;
        }

        public override void Awake()
        {
            base.Awake();
        }

        /// <summary>
        /// Arranges an array of sprites with equal-sized frames from the sprite sheet.
        /// </summary>
        /// <param name="quantity">The number of sprites to arrange.</param>
        /// <param name="width">The width of each sprite frame.</param>
        /// <param name="height">The height of each sprite frame.</param>
        /// <param name="centerAxis">Determines whether to center the origin axis of each sprite frame (optional, default is false).</param>
        /// <param name="scale">The scale factor for the sprites (optional, default is 1).</param>
        /// <returns>An array of Sprite objects representing the arranged sprites.</returns>
        public Sprite[] ArrangeArrayEqually(int quantity, int width, int height, bool centerAxis = false, int scale = 1)
        {
            Sprite[] sprites = new Sprite[quantity];
            Sprite sprite;
            Rectangle source;
            int srcX = 0;
            int srcY = 0;

            for (int i = 0; i < quantity; i++)
            {
                if (srcX >= _texture.Width)
                {
                    srcX = 0;
                    srcY += height;
                    if (srcY >= _texture.Height)
                        break;
                }

                source = new Rectangle(srcX, srcY, width, height);
                sprite = new Sprite(_texture, source, scale, centerAxis);
                sprites[i] = sprite;
                srcX += width;
            }

            return sprites;
        }

        /// <summary>
        /// Arranges a matrix of sprites with equal-sized frames from the sprite sheet.
        /// </summary>
        /// <param name="rows">The number of rows in the matrix.</param>
        /// <param name="columns">The number of columns in the matrix.</param>
        /// <param name="width">The width of each sprite frame.</param>
        /// <param name="height">The height of each sprite frame.</param>
        /// <param name="centerAxis">Determines whether to center the origin axis of each sprite frame (optional, default is false).</param>
        /// <param name="scale">The scale factor for the sprites (optional, default is 1).</param>
        /// <returns>A 2D array of Sprite objects representing the arranged sprites in rows and columns.</returns>
        public Sprite[,] ArrangeMatrixEqually(int rows, int columns, int width, int height, bool centerAxis = false, int scale = 1)
        {
            Sprite[,] sprites = new Sprite[rows, columns];
            Sprite sprite;
            Rectangle source;
            int srcX;
            int srcY = 0;

            for (int i = 0; i < rows; i++)
            {
                srcX = 0;
                for (int j = 0; j < columns; j++)
                {
                    if (srcX >= _texture.Width)
                        break;

                    source = new Rectangle(srcX, srcY, width, height);
                    sprite = new Sprite(_texture, source, scale, centerAxis);
                    sprites[i,j] = sprite;
                    srcX += width;
                }
                srcY += height;
                if (srcY >= _texture.Height)
                    break;
            }

            return sprites;
        }
    }
}
