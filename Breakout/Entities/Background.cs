using RayG;
using Raylib_cs;
using System.Numerics;

namespace Breakout.Entities
{
    internal class Background : GameObject
    {
        readonly TextureManager _textureManager;
        readonly MusicManager _musicManager;
        Texture2D Texture;

        Vector2 position = new(0, 0);

        public Background(TextureManager textureManager, MusicManager muicManager) 
        {
            _textureManager = textureManager;
            _musicManager = muicManager;
        }

        public override void Start()
        {
            Texture = _textureManager.GetTexture("RedBlueGirl");
            _musicManager.StartMusic("Music", 0.5f, 0.75f);
            base.Start();
        }

        public override void Update()
        {
            _musicManager.UpdateMusic("Music");
            base.Update();
        }

        public override void Render()
        {
            Raylib.ClearBackground(Color.BLACK);
            Raylib.DrawTextureEx(Texture, position, 0, 2, Color.WHITE);
            base.Render();
        }
    }
}
