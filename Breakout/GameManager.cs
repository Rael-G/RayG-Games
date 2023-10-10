using Breakout.Entities;
using Breakout.GameLogic;
using Breakout.Resources;
using RayG;
using Raylib_cs;

namespace Breakout
{
    internal class GameManager : GameObject
    {
        Camera camera;

        public override void Config()
        {
            Window.Name = "Breakout";
            Window.Width = 1920;
            Window.Height = 1080;
            Window.VirtualWidth = 320;
            Window.VirtualHeight = 180;
            Raylib.SetTargetFPS(144);
            base.Config();
        }

        public override void Start()
        {
            var textureManager = new TextureManager();
            var backgorund = new Background(textureManager);
            camera = new Camera();

            Childs.Add(camera);
            Childs.Add(textureManager);
            Childs.Add(backgorund);
            base.Start();
        }

        public override void Render()
        {
            Raylib.BeginMode2D(camera.Camera2d);
            base.Render();
            Raylib.EndMode2D();
        }
    }
}
