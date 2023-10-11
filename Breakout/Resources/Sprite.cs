using Raylib_cs;
using System.Numerics;

namespace Breakout.Resources
{
    internal struct Sprite
    {
        private int _scale;

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

        public Sprite(Rectangle source, int scale, bool centerAxis = false)
        {
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
