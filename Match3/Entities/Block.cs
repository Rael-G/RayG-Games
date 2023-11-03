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
        public bool Dead { get; set; }

        private const float DURATION = 0.2f;
        
        public Block(int tile, Sprite sprite, Vector2 position, int row, int col)
        {
            Tile = tile;
            Sprite = sprite;
            Position = new Rectangle { width = Sprite.Width, height = Sprite.Height, 
                x = position.X, y = position.Y};
            BoardPosition = (row, col);
        }

        public void Swap(Vector2 position)
        {
            var moveX = Timing.InterpolateAsync(DURATION, Position.x, position.X, (t) => 
            { 
                Position = new Rectangle(t, Position.y, Position.height, Position.width); 
            });
            var moveY = Timing.InterpolateAsync(DURATION, Position.y, position.Y, (t) => 
            { 
                Position = new Rectangle(Position.x, t, Position.height, Position.width); 
            });
        }

        public void Spawn(Vector2 position)
        {
            var move = Timing.InterpolateAsync(DURATION, 0, position.Y, (t) =>
            {
                Position = new Rectangle(Position.x, t, Position.height, Position.width);
            });
        }
    }
}
