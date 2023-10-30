using RayG;
using Raylib_cs;
using System.Numerics;

namespace Match3.Entities
{
    internal class Block : GameObject
    {
        public int Tile { get; private set; }
        public Sprite Sprite { get; private set; }
        public Rectangle Position { get; set; }

        public Block(int tile, Sprite sprite, Vector2 position) 
        { 
            Tile = tile;
            Sprite = sprite;
            Position = new Rectangle { width = Sprite.Width, height = Sprite.Height, 
                x = position.X, y = position.Y};
        }
    }
}
