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
            TextureManager = new TextureManager(@"Data\Breakout\Textures\", new string[]
            {
                "Breakout.png", "RedBlueGirl.png"
            });
            SoundManager = new SoundManager(@"Data\Breakout\Audio\Sounds\", new string[]
            {
                "Select.wav"
            });

            SpriteSheet = new SpriteSheet(TextureManager);

            Camera = new Camera();
            Childs.Add(TextureManager);
            Childs.Add(SoundManager);
            Childs.Add(SpriteSheet);
            Childs.Add(Camera);

            base.Awake();
        }

        public override void Start()
        {
            var backgorund = new Background(TextureManager);
            var StateMachine = new StateMachine(SoundManager, SpriteSheet);
            
            Childs.Add(backgorund);
            Childs.Add(StateMachine);
            base.Start();
        }

        public override void Render()
        {
            Raylib.BeginMode2D(Camera.Camera2d);
            base.Render();
            Raylib.EndMode2D();
        }
    }
}
