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
        Camera Camera;
        TextureManager TextureManager;
        SoundManager SoundManager;
        SpriteSheet SpriteSheet;

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

        public override void Awake()
        {
            TextureManager = new TextureManager(@"Data\Breakout\Textures\");

            SoundManager = new SoundManager(@"Data\Breakout\Audio\Sounds\");

            SpriteSheet = new SpriteSheet(TextureManager);

            Camera = new Camera();
            Children.Add(TextureManager);
            Children.Add(SoundManager);
            Children.Add(SpriteSheet);
            Children.Add(Camera);

            base.Awake();
        }

        public override void Start()
        {
            var backgorund = new Background(TextureManager);
            var stateMachine = new StateMachine(SoundManager, SpriteSheet);
            
            Children.Add(backgorund);
            Children.Add(stateMachine);

            base.Start();
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Render()
        {
            Raylib.BeginMode2D(Camera.Camera2d);
            base.Render();
            Raylib.EndMode2D();
        }
    }
}
