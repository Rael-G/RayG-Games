using Breakout.Resources;
using RayG;
using Raylib_cs;
using System.Numerics;

namespace Breakout.Entities
{
    internal class Background : GameObject
    {
        TextureManager _textureManager;
        Texture2D background;

        Vector2 position = new(0, 0);

        public Background(TextureManager textureManager) 
        {
            _textureManager = textureManager;
        }

        public override void Start()
        {
            background = _textureManager.GetTexture("RedBlueGirl");
            base.Start();
        }

        public override void Render()
        {
            Raylib.ClearBackground(Color.BLACK);
            Raylib.DrawTextureEx(background, position, 0, 2, Color.WHITE);
            base.Render();
        }
    }
}
