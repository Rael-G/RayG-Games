using RayG;
using Raylib_cs;
using System.Numerics;

namespace Match3.Entities
{
    internal class Board : GameObject
    {
        public const int ROWS = 8;
        public const int COLS = 8;

        public Block[,] Blocks { get; private set; }

        readonly SpriteSheet _sheet;
        Sprite[] _sprites;
        
        public Board(SpriteSheet sheet) 
        {
            _sheet = sheet;
        }

        public override void Start()
        {
            _sprites = _sheet.ArrangeArrayEqual(10, 16, 16);
            GenerateBoard();

            base.Start();
        }

        public override void Render()
        {
            foreach ( var block in Blocks ) 
            {
                Raylib.DrawTexturePro(block.Sprite.Texture, block.Sprite.Source,
                    block.Position, block.Sprite.Axis, 0, Color.WHITE);
            }
            base.Render();
        }

        public void SwapBlocks(Block block, Block otherBlock)
        {
            block.Swap(otherBlock);

            Blocks[block.BoardPosition.Row, block.BoardPosition.Col] = block;
            Blocks[otherBlock.BoardPosition.Row, otherBlock.BoardPosition.Col] = otherBlock;
        }

        private void GenerateBoard()
        {
            Blocks = new Block[8, 8];
            var x = Window.VirtualWidth * 0.40f;
            var y = Window.VirtualWidth * 0.05f;
            for (int rows = 0; rows < ROWS; rows++) 
            {
                var localX = x;
                for (int cols = 0; cols < COLS; cols++)
                {
                    var position = new Vector2()
                    {
                        X = localX,
                        Y = y,
                    };
                    var tile = Raylib.GetRandomValue(0, 9);
                    Blocks[rows, cols] = new Block(tile, _sprites[tile], position, rows, cols);

                    localX += 16;
                }
                y += 16;
            }
        }

    }
}
