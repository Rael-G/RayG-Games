using EvilBird.Entities;
using EvilBird.GameLogic;
using EvilBird.GameLogic.States;
using RayG;
using Raylib_cs;

namespace EvilBird
{
    internal class GameManager : GameObject
    {
        Camera Camera { get; set; }
        TextureManager TextureManager { get; set; }
        SoundManager SoundManager { get; set; }
        MusicManager MusicManager { get; set; }
        Background Background { get; set; }
        StateMachine StateMachine { get; set; }

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

        public override void Awake()
        {
            Camera = new Camera();
            TextureManager = new TextureManager(@"\Data\EvilBird\Textures\");

            SoundManager = new SoundManager(@"\Data\EvilBird\Audio\Sound\");

            MusicManager = new MusicManager(@"\Data\EvilBird\Audio\Music\");

            Childs.Add(Camera);
            Childs.Add(TextureManager);
            Childs.Add(MusicManager);
            Childs.Add(SoundManager);

            base.Awake();
        }

        public override void Start()
        {
            Background = new Background(TextureManager, MusicManager);
            StateMachine = new(TextureManager, SoundManager);
           
            Childs.Add(Background);
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
