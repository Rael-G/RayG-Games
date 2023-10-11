using Breakout.Resources;
using RayG;
using Raylib_cs;

namespace Breakout.Entities
{
    //this is a test class
    internal class Blocks : GameObject
    {
        SpriteSheet _sheet;
        TextureManager _textureManager;
        Texture2D texture;

        public Blocks(TextureManager textureManager) 
        {
            _textureManager = textureManager;
        }

        public override void Start()
        {
            _sheet = new SpriteSheet();
            texture = _textureManager.GetTexture("Breakout");
            base.Start();
        }

        public override void Render()
        {
            Rectangle dest = new Rectangle(16, 8, 16f, 8f);

            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    Raylib.DrawTexturePro(texture, _sheet.Blocks[j, i].Source, dest, new System.Numerics.Vector2(0, 0), 0, Color.WHITE);
                    dest.x += 16;
                }

                dest.y += 8;
                dest.x = 16;
            }
            base.Render();
        }
    }
}
