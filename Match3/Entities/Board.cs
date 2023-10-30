using RayG;
using Raylib_cs;
using System.Numerics;

namespace Match3.Entities
{
    internal class Board : GameObject
    {
        SpriteSheet _sheet;
        Sprite[] _sprites;
        Block[,] _blocks;
        
        public Board(SpriteSheet sheet) 
        {
            _sheet = sheet;
        }

        public override void Start()
        {
            _sprites = _sheet.ArrangeArrayEqual(10, 16, 16);
           GenerateBlocks();
            base.Start();
        }

        public override void Render()
        {
            foreach ( var block in _blocks ) 
            {
                Raylib.DrawTexturePro(block.Sprite.Texture, block.Sprite.Source,
                    block.Position, block.Sprite.Axis, 0, Color.WHITE);
            }
            base.Render();
        }
        private void GenerateBlocks()
        {
            _blocks = new Block[8, 8];
            var x = Window.VirtualWidth * 0.40f;
            var y = Window.VirtualWidth * 0.05f;
            for (int i = 0; i < 8; i++) 
            {
                var localX = x;
                for (int j = 0; j < 8; j++)
                {
                    var position = new Vector2()
                    {
                        X = localX,
                        Y = y,
                    };
                    var tile = Raylib.GetRandomValue(0, 9);
                    _blocks[i, j] = new Block(tile, _sprites[tile], position);

                    localX += 16;
                }
                y += 16;
            }
        }

    }
}
