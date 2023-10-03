using EvilBird.Resources;
using RayG;
using Raylib_cs;
using System.Numerics;

namespace EvilBird.Entities
{
    internal class Background : GameObject
    {
        private const float speed = 25;
        private const int scale = 2;
        private const int rotation = 0;

        private Vector2 positionBack;
        private Vector2 positionMidA;
        private Vector2 positionMidB;
        private Vector2 positionFrontA;
        private Vector2 positionFrontB;

        private Texture2D TextureBack;
        private Texture2D TextureMid;
        private Texture2D TextureFront;

        private float scrollingMid;
        private float scrollingFront;

        TextureManager _textureManager;

        public Background(TextureManager textureManager)
        {
            _textureManager = textureManager;
        }

        public override void Start()
        {
            TextureBack = _textureManager.GetTexture("WheatFarmBack");
            TextureMid = _textureManager.GetTexture("WheatFarmMid");
            TextureFront = _textureManager.GetTexture("WheatFarmFront");
            base.Start();
        }

        public override void Update()
        {

            scrollingMid += speed * Raylib.GetFrameTime();
            scrollingFront += speed * Raylib.GetFrameTime();

            if (scrollingMid >= TextureMid.width * 2 )
            {
                scrollingMid = 0;
            }
            if (scrollingFront >= TextureFront.width)
            {
                scrollingFront = 0;
            }

            positionBack = new(0, 0);
            positionMidA = new(-scrollingMid, 0);
            positionMidB = new(-scrollingMid + TextureBack.width * 2, 0);
            positionFrontA = new(-scrollingFront * 2, 0);
            positionFrontB = new(-scrollingFront * 2 + TextureFront.width * 2, 0);

            base.Update();
        }

        public override void Render()
        {
            Raylib.ClearBackground(Color.GRAY);

            Raylib.DrawTextureEx(TextureBack, positionBack, rotation, scale, Color.WHITE);

            Raylib.DrawTextureEx(TextureMid, positionMidA, rotation, scale, Color.WHITE);
            Raylib.DrawTextureEx(TextureMid, positionMidB, rotation, scale, Color.WHITE);

            Raylib.DrawTextureEx(TextureFront, positionFrontA, rotation, scale, Color.WHITE);
            Raylib.DrawTextureEx(TextureFront, positionFrontB, rotation, scale, Color.WHITE);

            base.Render();
        }
    }
}
