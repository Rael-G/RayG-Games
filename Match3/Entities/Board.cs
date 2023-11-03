using RayG;
using Raylib_cs;
using System.Numerics;

namespace Match3.Entities
{
    internal class Board : GameObject
    {
        public const int ROWS = 10;
        public const int COLS = 10;

        public Block[,] Blocks { get; private set; }
        public Vector2[,] Cordinates { get; private set; }

        readonly SpriteSheet _sheet;
        Sprite[] _sprites;
        
        public Board(SpriteSheet sheet) 
        {
            _sheet = sheet;
        }

        public override void Start()
        {
            _sprites = _sheet.ArrangeArrayEqually(10, 16, 16);
            GenerateBoard();

            base.Start();
        }

        public override void Update()
        {
            var block = Blocks[0, 0];

            base.Update();
        }

        public override void Render()
        {
            foreach ( var block in Blocks ) 
            {
                float alpha = block.Dead ? 0f : 1;

                Raylib.DrawTexturePro(block.Sprite.Texture, block.Sprite.Source,
                block.Position, block.Sprite.Axis, 0, Raylib.ColorAlpha(Color.WHITE, alpha));
            }
            base.Render();
        }

        public void SwapInBoard(Block block, Block otherBlock)
        {
            (otherBlock.BoardPosition, block.BoardPosition) = (block.BoardPosition, otherBlock.BoardPosition);

            Blocks[block.BoardPosition.Row, block.BoardPosition.Col] = block;
            Blocks[otherBlock.BoardPosition.Row, otherBlock.BoardPosition.Col] = otherBlock;

            //Safer way to swap async
            block.Swap(Cordinates[block.BoardPosition.Row, block.BoardPosition.Col]);
            otherBlock.Swap(Cordinates[otherBlock.BoardPosition.Row, otherBlock.BoardPosition.Col]);
        }

        private void GenerateBoard()
        {
            Blocks = new Block[ROWS, COLS];
            Cordinates = new Vector2[ROWS, COLS];
            var x = Window.VirtualWidth * 0.40f;
            var y = Window.VirtualWidth * 0.05f;
            for (int rows = 0; rows < ROWS; rows++) 
            {
                var localX = x;
                for (int cols = 0; cols < COLS; cols++)
                {
                    Cordinates[rows, cols] = new Vector2()
                    {
                        X = localX,
                        Y = y,
                    };
                    var tile = Raylib.GetRandomValue(0, 9);
                    Blocks[rows, cols] = new Block(tile, _sprites[tile], Cordinates[rows, cols], rows, cols);

                    localX += 16;
                }
                y += 16;
            }
        }

        public void ReplaceBoard()
        {
            for (int rows = 0; rows < ROWS; rows++)
            {
                for (int cols = 0; cols < COLS; cols++)
                {
                    if (Blocks[rows, cols].Dead)
                    {
                        var tile = Raylib.GetRandomValue(0, 9);
                        Blocks[rows, cols] = new Block(tile, _sprites[tile], Cordinates[rows, cols], rows, cols);
                        Blocks[rows, cols].Spawn(Cordinates[rows, cols]);
                    }
                }
            }
        }
    }
}
