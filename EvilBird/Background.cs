using RayG;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EvilBird
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

        TextureManager TextureManager;

        public Background(TextureManager textureManager)
        {
            TextureManager = textureManager;
        }

        public override void Start()
        {
            TextureBack = TextureManager.GetTexture("WheatFarmBack");
            TextureMid = TextureManager.GetTexture("WheatFarmMid");
            TextureFront = TextureManager.GetTexture("WheatFarmFront");

            scrollingFront = -Window.VirtualWidth / 2;
            scrollingMid = -Window.VirtualWidth / 2;

            base.Start();
        }

        public override void Update()
        {
            scrollingMid -= speed * Raylib.GetFrameTime();
            scrollingFront -= speed * 2 * Raylib.GetFrameTime();

            if (scrollingMid <= -TextureMid.width * 2 - Window.VirtualWidth / 2 )
            {
                scrollingMid = -Window.VirtualWidth / 2; ;
            }
            if (scrollingFront <= -TextureFront.width * 2 - Window.VirtualWidth / 2 )
            {
                scrollingFront = -Window.VirtualWidth / 2; ;
            }

            positionBack = new(-Window.VirtualWidth, -Window.VirtualHeight / 2);
            positionMidA = new(scrollingMid, -Window.VirtualHeight / 2);
            positionMidB = new(scrollingMid + TextureBack.width * 2, -Window.VirtualHeight / 2);
            positionFrontA = new(scrollingFront, -Window.VirtualHeight / 2);
            positionFrontB = new(scrollingFront + TextureBack.width * 2 , -Window.VirtualHeight / 2);

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
