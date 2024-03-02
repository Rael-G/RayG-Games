using RayG;
using Raylib_cs;
using System.Numerics;

namespace EvilBird.Entities
{
    internal class Background : GameObject
    {
        private Texture2D TextureMid;
        private Texture2D TextureFront;
        private Vector2 PositionMid;
        private Vector2 PositionFront;
        private Vector2 Size;

        TextureManager _textureManager;
        MusicManager _audioManager;
        const float _speed = 25;
        const int _scale = 2;
        const int _rotation = 0;

        float scrollingMid;
        float scrollingFront;

        public Background(TextureManager textureManager , MusicManager audioManager)
        {
            _textureManager = textureManager;
            _audioManager = audioManager;
        }

        public override void Start()
        {
            _audioManager.StartMusic("Music");
            TextureMid = _textureManager.GetTexture("WheatFarmMid");
            TextureFront = _textureManager.GetTexture("WheatFarmFront");

            Size = new(TextureMid.Width * 2, 0);
            base.Start();
        }

        public override void Update()
        {
            _audioManager.UpdateMusic("Music");
            scrollingMid += _speed * Raylib.GetFrameTime();
            scrollingFront += _speed * Raylib.GetFrameTime();

            if (scrollingMid >= TextureMid.Width * 2 )
            {
                scrollingMid = 0;
            }
            if (scrollingFront >= TextureFront.Width)
            {
                scrollingFront = 0;
            }

            PositionMid = new(-scrollingMid, 0);
            PositionFront = new(-scrollingFront * 2, 0);

            base.Update();
        }

        public override void Render()
        {
            Raylib.ClearBackground(Color.Gray);

            Raylib.DrawTextureEx(TextureMid, PositionMid, _rotation, _scale, Color.White);
            Raylib.DrawTextureEx(TextureMid, PositionMid + Size, _rotation, _scale, Color.White);

            Raylib.DrawTextureEx(TextureFront, PositionFront, _rotation, _scale, Color.White);
            Raylib.DrawTextureEx(TextureFront, PositionFront + Size, _rotation, _scale, Color.White);

            base.Render();
        }
    }
}
