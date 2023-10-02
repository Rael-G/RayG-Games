using RayG;
using Raylib_cs;
using System.Numerics;

namespace EvilBird
{
    internal class GameManager : GameObject
    {
        TextureManager textureManager;
        Camera camera;
        Player player;
        Background background;

        public override void Config()
        {
            Window.Width = 1280;
            Window.Height = 960;
            Window.VirtualWidth = 320;
            Window.VirtualHeight = 240;
            Window.Name = "EvilBird";
            base.Config();
        }

        public override void Start()
        {
            textureManager = new();

            background = new Background(textureManager);
            player = new(textureManager);
            camera = new Camera(player._position);
            
            var colisionLayer = new GameObject() { Childs = { player } };
            var logicLayer = new GameObject() { Childs = { textureManager, camera } };
            Childs.Add(logicLayer);
            Childs.Add(background);
            Childs.Add(colisionLayer);

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
