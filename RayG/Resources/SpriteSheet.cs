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

        public Sprite[] ArrangeArrayEqual(int quantity, int width, int height, int scale = 1)
        {
            Sprite[] sprites = new Sprite[quantity];
            Sprite sprite;
            Rectangle source;
            int srcX = 0;
            int srcY = 0;

            for (int i = 0; i < quantity; i++)
            {
                if (srcX >= _texture.width)
                {
                    srcX = 0;
                    srcY += height;
                    if (srcY >= _texture.height)
                        break;
                }

                source = new Rectangle(srcX, srcY, width, height);
                sprite = new Sprite(_texture, source, scale);
                sprites[i] = sprite;
                srcX += width;
            }

            return sprites;
        }

        public Sprite[,] ArrangeMatrixEqual(int rows, int columns, int width, int height, int scale = 1)
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
                    if (srcX >= _texture.width)
                        break;

                    source = new Rectangle(srcX, srcY, width, height);
                    sprite = new Sprite(_texture, source, scale);
                    sprites[i,j] = sprite;
                    srcX += width;
                }
                srcY += height;
                if (srcY >= _texture.height)
                    break;
            }

            return sprites;
        }
    }
}
