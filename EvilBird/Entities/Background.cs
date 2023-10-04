using EvilBird.Resources;
using RayG;
using Raylib_cs;
using System.Numerics;

namespace EvilBird.Entities
{
    internal class Background : GameObject
    {
        Texture2D TextureMid { get; set; }
        Texture2D TextureFront { get; set; }
        TextureManager TextureManager { get; set; }

        const float _speed = 25;
        const int _scale = 2;
        const int _rotation = 0;
        Vector2 _size;

        Vector2 _positionMid;
        Vector2 _positionFront;

        float _scrollingMid;
        float _scrollingFront;


        public Background(TextureManager textureManager)
        {
            TextureManager = textureManager;
        }

        public override void Start()
        {
            TextureMid = TextureManager.GetTexture("WheatFarmMid");
            TextureFront = TextureManager.GetTexture("WheatFarmFront");

            _size = new(TextureMid.width * 2, 0);
            base.Start();
        }

        public override void Update()
        {

            _scrollingMid += _speed * Raylib.GetFrameTime();
            _scrollingFront += _speed * Raylib.GetFrameTime();

            if (_scrollingMid >= TextureMid.width * 2 )
            {
                _scrollingMid = 0;
            }
            if (_scrollingFront >= TextureFront.width)
            {
                _scrollingFront = 0;
            }

            _positionMid = new(-_scrollingMid, 0);
            _positionFront = new(-_scrollingFront * 2, 0);

            base.Update();
        }

        public override void Render()
        {
            Raylib.ClearBackground(Color.GRAY);

            Raylib.DrawTextureEx(TextureMid, _positionMid, _rotation, _scale, Color.WHITE);
            Raylib.DrawTextureEx(TextureMid, _positionMid + _size, _rotation, _scale, Color.WHITE);

            Raylib.DrawTextureEx(TextureFront, _positionFront, _rotation, _scale, Color.WHITE);
            Raylib.DrawTextureEx(TextureFront, _positionFront + _size, _rotation, _scale, Color.WHITE);

            base.Render();
        }
    }
}
