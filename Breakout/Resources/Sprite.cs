using Raylib_cs;
using System.Numerics;

namespace Breakout.Resources
{
    internal struct Sprite
    {
        private int _scale;

        public Texture2D Texture { get; private set; }
        public int Width { get => (int)Source.width; }
        public int Height { get => (int)Source.height;  }
        public Rectangle Source { get; private set; }
        public Vector2 Axis { get; set; }
        bool CenterAxis { get; set; }
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
            Scale = scale;
            SetAxis();
        }

        private void SetAxis()
        {
            if (CenterAxis)
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
