using RayG;
using Raylib_cs;
using System.Numerics;

namespace EvilBird
{
    internal class GameManager : GameObject
    {
        TextureManager textureManager;
        Camera camera;
        Bird player;
        Background background;

        public override void Config()
        {
            Window.Name = "EvilBird";
            Window.Width = 1600;
            Window.Height = 1200;
            Window.VirtualWidth = 320;
            Window.VirtualHeight = 240;
            Window.Flags = new ConfigFlags[] { ConfigFlags.FLAG_VSYNC_HINT};
            Raylib.SetTargetFPS(144);
            base.Config();
        }

        public override void Start()
        {
            textureManager = new();

            background = new Background(textureManager);
            player = new(textureManager);
            camera = new Camera();

            var resourceLayer = new GameObject() { Childs = { textureManager } };
            var colisionLayer = new GameObject() { Childs = { player } };
            var logicLayer = new GameObject() { Childs = { camera } };
            Childs.Add(resourceLayer);
            Childs.Add(background);
            Childs.Add(colisionLayer);
            Childs.Add(logicLayer);


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
