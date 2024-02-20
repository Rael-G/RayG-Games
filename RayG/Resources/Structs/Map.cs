namespace RayG
{
    /// <summary>
    /// Represents a map with properties such as width, height, tile dimensions, frames, and data.
    /// </summary>
    public struct Map
    {
        /// <summary>
        /// Gets or sets the width of the map in tiles.
        /// </summary>
        public int MapWidth { get; set; }

        /// <summary>
        /// Gets or sets the height of the map in tiles.
        /// </summary>
        public int MapHeight { get; set; }

        /// <summary>
        /// Gets or sets the width of each tile in pixels.
        /// </summary>
        public int TileWidth { get; set; }

        /// <summary>
        /// Gets or sets the height of each tile in pixels.
        /// </summary>
        public int TileHeight { get; set; }

        /// <summary>
        /// Gets or sets the number of frames in the map.
        /// </summary>
        public int Frames { get; set; }

        /// <summary>
        /// Gets or sets the data representing the map layout, i.e., an array of tile indices.
        /// </summary>
        public int[] Data { get; set; }
    }
}
