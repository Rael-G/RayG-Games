using Breakout.Entities;
using Breakout.GameLogic;
using Breakout.GameLogic.States;
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
            var textureManager = new TextureManager(@"Data\Breakout\Textures\", new string[]
            {
                "Breakout.png", "RedBlueGirl.png"
            });
            var soundManager = new SoundManager(@"Data\Breakout\Audio\Sounds\", new string[]
            {
                "Select.wav"
            });
            var backgorund = new Background(textureManager);
            var StateMachine = new StateMachine(soundManager);
            //var spriteSheet = new SpriteSheet(textureManager);
            camera = new Camera();

            Blocks blocks = new Blocks(textureManager);

            Childs.Add(camera);
            Childs.Add(textureManager);
            Childs.Add(soundManager);
            Childs.Add(backgorund);
            Childs.Add(StateMachine);
            Childs.Add(blocks);
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
