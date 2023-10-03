using EvilBird.Entities;
using EvilBird.Entities.Obstacles;
using EvilBird.GameLogic;
using EvilBird.Resources;
using RayG;
using Raylib_cs;

namespace EvilBird
{
    internal class GameManager : GameObject
    {
        Camera camera;
        Bird player;
        Background background;
        TextureManager textureManager;
        ObstacleManager obstacleManager;

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
            textureManager = new TextureManager();
            background = new Background(textureManager);
            player = new(textureManager);
            camera = new Camera();

            obstacleManager = new(textureManager);

            var resourceLayer = new GameObject() { Childs = { textureManager } };
            var colisionLayer = new GameObject() { Childs = { player, obstacleManager } };
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

        public void OnCollisionEnter(Collisor collisor)
        {
            throw new NotImplementedException();
        }

        public void OnCollisionExit(Collisor collisor)
        {
            throw new NotImplementedException();
        }
    }
}
