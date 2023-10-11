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
            TextureManager = new TextureManager(@"\Data\EvilBird\Textures\", new string[]
            {
                "EvilBirdRising.png", "EvilBirdFalling.png", "Scarecrow.png",
                "WheatFarmMid.png", "WheatFarmFront.png"
            });
            SoundManager = new SoundManager(@"\Data\EvilBird\Audio\Sound\", new string[]
            {
                "Countdown.wav", "Death.wav", "Jump.wav", "Corn.wav"
            });
            MusicManager = new MusicManager(@"\Data\EvilBird\Audio\Music\", new string[]
            {
                "Music.mp3"
            });

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
