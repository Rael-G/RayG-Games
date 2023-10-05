using EvilBird.Resources;
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
        AudioManager _audioManager;
        const float _speed = 25;
        const int _scale = 2;
        const int _rotation = 0;

        float scrollingMid;
        float scrollingFront;

        public Background(TextureManager textureManager , AudioManager audioManager)
        {
            _textureManager = textureManager;
            _audioManager = audioManager;
        }

        public override void Start()
        {
            _audioManager.StartMusic("Music");
            TextureMid = _textureManager.GetTexture("WheatFarmMid");
            TextureFront = _textureManager.GetTexture("WheatFarmFront");

            Size = new(TextureMid.width * 2, 0);
            base.Start();
        }

        public override void Update()
        {
            _audioManager.UpdateMusic("Music");
            scrollingMid += _speed * Raylib.GetFrameTime();
            scrollingFront += _speed * Raylib.GetFrameTime();

            if (scrollingMid >= TextureMid.width * 2 )
            {
                scrollingMid = 0;
            }
            if (scrollingFront >= TextureFront.width)
            {
                scrollingFront = 0;
            }

            PositionMid = new(-scrollingMid, 0);
            PositionFront = new(-scrollingFront * 2, 0);

            base.Update();
        }

        public override void Render()
        {
            Raylib.ClearBackground(Color.GRAY);

            Raylib.DrawTextureEx(TextureMid, PositionMid, _rotation, _scale, Color.WHITE);
            Raylib.DrawTextureEx(TextureMid, PositionMid + Size, _rotation, _scale, Color.WHITE);

            Raylib.DrawTextureEx(TextureFront, PositionFront, _rotation, _scale, Color.WHITE);
            Raylib.DrawTextureEx(TextureFront, PositionFront + Size, _rotation, _scale, Color.WHITE);

            base.Render();
        }
    }
}
