using RayG;
using Raylib_cs;
using System.Numerics;

namespace Match3.Entities
{
    internal class Block
    {
        public int Tile { get; private set; }
        public Sprite Sprite { get; private set; }
        public Rectangle Position { get; set; }
        public (int Row, int Col) BoardPosition { get; set; }

        public Block(int tile, Sprite sprite, Vector2 position, int row, int col)
        {
            Tile = tile;
            Sprite = sprite;
            Position = new Rectangle { width = Sprite.Width, height = Sprite.Height, 
                x = position.X, y = position.Y};
            BoardPosition = (row, col);
        }

        public void Swap(Block other)
        {
            const float duration = 0.2f;
            (other.BoardPosition, BoardPosition) = (BoardPosition, other.BoardPosition);

            var moveX = Timing.InterpolateAsync(duration, Position.x, other.Position.x, (t) => 
            { 
                Position = new Rectangle(t, Position.y, Position.height, Position.width); 
            });
            var moveY = Timing.InterpolateAsync(duration, Position.y, other.Position.y, (t) => 
            { 
                Position = new Rectangle(Position.x, t, Position.height, Position.width); 
            });
            var moveOtherX = Timing.InterpolateAsync(duration, other.Position.x, Position.x, (t) => 
            { 
                other.Position = new Rectangle(t, other.Position.y, 
                    other.Position.height, other.Position.width); 
            });
            var moveOtherY = Timing.InterpolateAsync(duration, other.Position.y, Position.y, (t) => 
            { 
                other.Position = new Rectangle(other.Position.x, t, 
                    other.Position.height, other.Position.width); 
            });
        }
    }
}
