using Raylib_cs;

namespace RayG
{
    public class Tile : GameObject, ICollisor
    {
        /// <summary>
        /// Gets the sprite associated with the tile.
        /// </summary>
        public Sprite Sprite { get;}

        /// <summary>
        /// Gets or sets the collision information for the tile.
        /// </summary>
        public Collisor Collisor { get; set; }

        private Rectangle _rectangle;

        public Tile(Sprite sprite, Rectangle rectangle)
        {
            Sprite = sprite;
            _rectangle = rectangle;
            Collisor = new(_rectangle)
            {
                Static = true
            };
        }

        public override void Render()
        {
            Raylib.DrawTexturePro(Sprite.Texture, Sprite.Source, _rectangle, Sprite.Axis, 0, Color.White);
            base.Render();
        }

        /// <summary>
        /// Creates a list of tiles based on the provided map and texture.
        /// </summary>
        /// <param name="map">The map containing information about the level layout.</param>
        /// <param name="texture">The texture used for the tiles.</param>
        /// <returns>A list of tiles representing the level.</returns>
        public static List<Tile> GenerateTiles(Map map, Texture2D texture)
        {
            var spriteSheet = new SpriteSheet(texture);
            var sprites = spriteSheet.ArrangeArrayEqually(map.Frames, map.TileWidth, map.TileHeight);
            var tiles = new List<Tile>();

            var destination = new Rectangle(0, 0, map.TileWidth, map.TileHeight);
            var limit = map.MapWidth;

            for (int i = 0; i < map.Data.Length; i++)
            {
                var tile = map.Data[i];
                if (tile > 0 && tile <= sprites.Length)
                {
                    var sprite = sprites[tile - 1];

                    tiles.Add(new(sprite, destination));
                }

                destination.X += map.TileWidth;

                if (i == limit - 1)
                {
                    destination.X = 0;
                    destination.Y += map.TileHeight;
                    limit += map.MapWidth;
                }
            }

            return tiles;
        }

        public void OnCollisionEnter(Collisor collisor)
        {

        }

        public void OnCollisionExit(Collisor collisor)
        {

        }

        public void OnCollision(Collisor collisor)
        {

        }
    }
}
