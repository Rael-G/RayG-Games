using EvilBird.Resources;
using RayG;
using Raylib_cs;

namespace EvilBird.Entities.Obstacles
{
    internal class ScarecrowControl : GameObject
    {
        private ScarecrowDown ScarecrowDown { get; set; }
        private ScarecrowUp ScarecorwUp { get; set; }
        private ScarecrowScore ScarecrowScore { get; set; }

        readonly float _initialPosition;
        Texture2D _texture;

        float outOfScreen;

        private TextureManager _textureManager;

        public ScarecrowControl(float initialPosition, TextureManager textureManager)
        {
            _initialPosition = initialPosition;
            _textureManager = textureManager;
        }
        public override void Start()
        {
            _texture = _textureManager.GetTexture("Scarecrow");
            outOfScreen = -_texture.width * 2;
            ScarecrowDown = new(_initialPosition, _texture);
            ScarecorwUp = new(_initialPosition, _texture);
            ScarecrowScore = new ScarecrowScore(_initialPosition);

            Childs.Add(ScarecrowDown);
            Childs.Add(ScarecorwUp);
            Childs.Add(ScarecrowScore);

            base.Start();

            var randonSpawn = Raylib.GetRandomValue
                (-Window.VirtualHeight * 33 / 100, Window.VirtualHeight * 33 / 100);

            ScarecrowDown.BeginPosition(randonSpawn);
            ScarecorwUp.BeginPosition(randonSpawn);
            ScarecrowScore.BeginPosition(randonSpawn);
        }

        public override void Update()
        {
            var randonSpawn = Raylib.GetRandomValue
                (-Window.VirtualHeight * 33 / 100, Window.VirtualHeight * 33 / 100);

            if (ScarecrowDown.Position.X <= outOfScreen)
            {
                ScarecrowDown.ResetPosition(randonSpawn);
                ScarecorwUp.ResetPosition(randonSpawn);
                ScarecrowScore.ResetPosition(randonSpawn);
            }
            base.Update();
        }












        //public Collisor Collisor { get; set; }

        //private Texture2D _texture;
        //private int _randmSpawn;
        //private float _out;
        //private float _initialSpawn;
        //private float _speed;

        //private Vector2 PositionA;
        //private Vector2 PositionB;
        //private Vector2 ResetPosA;
        //private Vector2 ResetPosB;

        //public Scarecrow(float initialSpawn)
        //{
        //    _initialSpawn = initialSpawn;
        //}

        //public override void Start()
        //{
        //    _randmSpawn = Raylib.GetRandomValue(-100, 100);
        //    _out = -_texture.width * 2;
        //    _speed = 100;

        //    ResetPosA = new(Window.VirtualWidth, _texture.height * 1.2f);
        //    ResetPosB = new(Window.VirtualWidth + _texture.width * 2, Window.VirtualHeight - _texture.height * 1.2f);

        //    PositionA = ResetPosA;
        //    PositionA.X += _initialSpawn;
        //    PositionA.Y += _randmSpawn;
        //    PositionB = ResetPosB;
        //    PositionB.X += _initialSpawn;
        //    PositionB.Y += _randmSpawn;

        //    base.Start();
        //}

        //public override void Update()
        //{
        //    _randmSpawn = Raylib.GetRandomValue(Window.VirtualHeight / 4, Window.VirtualHeight / 2);
        //    PositionA.X += -_speed * Raylib.GetFrameTime();
        //    PositionB.X += -_speed * Raylib.GetFrameTime();

        //    if (PositionA.X <= _out)
        //    {
        //        _randmSpawn = Raylib.GetRandomValue(-100, 100);
        //        PositionA = ResetPosA;
        //        PositionA.Y += _randmSpawn;
        //        PositionB = ResetPosB;
        //        PositionB.Y += _randmSpawn;

        //    }
        //    base.Update();
        //}

        //public override void Render()
        //{
        //    Raylib.DrawTextureEx(_texture, PositionA, 0, 2, Color.WHITE);
        //    Raylib.DrawTextureEx(_texture, PositionB, 180, 2, Color.WHITE);
        //    base.Render();
        //}
    }
}
