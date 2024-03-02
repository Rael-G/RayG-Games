using Raylib_cs;
using System.Numerics;

namespace RayG
{
    /// <summary>
    /// Represents a sprite with texture, source rectangle, scale, and optional center axis.
    /// </summary>
    public struct Sprite
    {
        /// <summary>
        /// Gets the texture of the sprite.
        /// </summary>
        public Texture2D Texture { get; private set; }

        /// <summary>
        /// Gets the width of the sprite.
        /// </summary>
        public readonly int Width { get => (int)Source.Width; }

        /// <summary>
        /// Gets the height of the sprite.
        /// </summary>
        public readonly int Height { get => (int)Source.Height;  }

        /// <summary>
        /// Gets or sets the source rectangle of the sprite.
        /// </summary>
        public Rectangle Source { get; private set; }

        /// <summary>
        /// Gets or sets the axis of rotation.
        /// </summary>
        public Vector2 Axis { get; set; }

        /// <summary>
        /// Gets or sets the scale of the sprite.
        /// </summary>
        public int Scale
        {
            readonly get => _scale;
            set
            {
                _scale = value;
                SetAxis();
            }
        }

        private readonly bool _centerAxis;
        private int _scale;

        public Sprite(Texture2D texture, Rectangle source, int scale, bool centerAxis = false)
        {
            Texture = texture;
            Source = source;
            _centerAxis = centerAxis;
            Scale = scale;
        }

        /// <summary>
        /// Flips the sprite horizontally.
        /// </summary>
        public void FlipHorizontally()
        {
            Source = new Rectangle (Source.X, Source.Y, Source.Width * -1, Source.Height);
        }

        private void SetAxis()
        {
            if (_centerAxis)
            {
                Axis = new(Source.Width * Scale / 2, Source.Height * Scale / 2);
            }
            else
            {
                Axis = new(0, 0);
            }
        }
    }
}
