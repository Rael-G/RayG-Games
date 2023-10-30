using Raylib_cs;
using System.Numerics;

namespace RayG
{
    public struct Sprite
    {
        private int _scale;
        private bool _centerAxis;

        public Texture2D Texture { get; private set; }
        public int Width { get => (int)Source.width; }
        public int Height { get => (int)Source.height;  }
        public Rectangle Source { get; private set; }
        public Vector2 Axis { get; set; }
        public int Scale
        {
            get => _scale;
            set
            {
                _scale = value;
                SetAxis();
            }
        }

        public Sprite(Texture2D texture, Rectangle source, int scale, bool centerAxis = false)
        {
            Texture = texture;
            Source = source;
            _centerAxis = centerAxis;
            Scale = scale;
        }

        private void SetAxis()
        {
            if (_centerAxis)
            {
                Axis = new(Source.width * Scale / 2, Source.height * Scale / 2);
            }
            else
            {
                Axis = new(0, 0);
            }
        }
    }
}
