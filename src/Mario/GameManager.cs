using RayG;
using Raylib_cs;

namespace Mario
{
    internal class GameManager : GameObject
    {
        TextureManager _textureManager;
        MapManager _mapManager;

        Camera _camera;

        public override void Config()
        {
            Window.Name = "Mario";
            Window.Width = 1920;
            Window.Height = 1080;
            Window.VirtualWidth = 640;
            Window.VirtualHeight = 320;
            Raylib.SetTargetFPS(144);
            base.Config();
        }

        public override void Awake()
        {
            _textureManager = new(@"Data\Mario\Textures\");
            _mapManager = new(@"Data\Mario\Maps\");

            Children.Add(_textureManager);
            Children.Add(_mapManager);
            base.Awake();
        }

        public override void Start() 
        {
            var texture = _textureManager.GetTexture("Ground");
            var idleTexture = _textureManager.GetTexture("Dolphin-Idle");
            var runTexture = _textureManager.GetTexture("Dolphin-Run");
            var jumpTexture = _textureManager.GetTexture("Dolphin-Jump");

            var spriteSheet = new SpriteSheet(idleTexture);
            var playerIdle = spriteSheet.ArrangeArrayEqually(6, 32, 32, true);
            Animation idle = new Animation(6, playerIdle, 0.24f);

            spriteSheet = new SpriteSheet(runTexture);
            var playerRun = spriteSheet.ArrangeArrayEqually(6, 32, 32, true);
            Animation run = new Animation(6, playerRun, 0.12f);

            spriteSheet = new SpriteSheet(jumpTexture);
            var playerJump = spriteSheet.ArrangeArrayEqually(2, 32, 32, true);
            var playerFall = playerJump.Skip(1).ToArray();
            Animation jump = new Animation(1, playerJump, 1f);
            Animation fall = new Animation(1, playerFall, 1f);

            Animator animator = new Animator(new Dictionary<string, Animation> { ["idle"] = idle, ["run"] = run, ["jump"] = jump, ["fall"] = fall });
            var map = _mapManager.GetMap("map-2");

            var player = new Player(animator);
            _camera = new Camera(player);


            var tiles = Tile.GenerateTiles(map, texture);
            var level = new GameObject();
            level.Children.AddRange(tiles);

            Children.Add(_camera);
            Children.Add(level);
            Children.Add(player);
            base.Start();
        }
        public override void LateUpdate()
        {
            this.StartCollision();
            base.LateUpdate();
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Render()
        {
            Raylib.ClearBackground(Color.SkyBlue);

            Raylib.BeginMode2D(_camera.Camera2d);
            base.Render();
            Raylib.EndMode2D();

        }
    }
}
