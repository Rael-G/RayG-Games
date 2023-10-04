using EvilBird.Resources;
using RayG;
using RayG.Interfaces;
using Raylib_cs;
using System.Numerics;


namespace EvilBird.Entities
{
    internal class Bird : GameObject, ICollisor

    {
        public int Corn { get; set; }

        public Vector2 _size;
        public Vector2 _position;
        public bool gravityOn;
        private float _gravity = 12;
        public float _fallForce = 0;
        public float _jumpForce = 150;
        public bool _dead = false;

        private TextureManager _textureManager;
        private Texture2D TextureRising;
        private Texture2D TextureFalling;
        public Collisor Collisor { get; set; }

        public Bird(TextureManager textureManager) 
        {
            _textureManager = textureManager;
        }

        public override void Start()
        {
            TextureRising = _textureManager.GetTexture("EvilBirdRising");
            TextureFalling = _textureManager.GetTexture("EvilBirdFalling");

            _size = new Vector2(TextureRising.width, TextureRising.height);
            _position = new Vector2(Window.VirtualWidth / 2 - _size.X / 2, Window.VirtualHeight / 2 - _size.Y / 2);

            Collisor = new(_position, new Vector2(_size.X, _size.Y / 2), "Bird");

            base.Start();
        }

        public override void Update()
        {
            _fallForce += _gravity * Raylib.GetFrameTime();
            _position.Y += _fallForce;

            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT) && !_dead
                || Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                _fallForce = -2.5f;
            }

            Collisor.Position = _position;
            Collisor.Position += new Vector2(0, _size.Y / 4) ;
            base.Update();
        }

        public override void Render()
        {
            //Draw Collisor
            Raylib.DrawRectangle((int)Collisor.Position.X, (int)Collisor.Position.Y,
                (int)Collisor.Area.X, (int)Collisor.Area.Y, Color.RED);

            if (_fallForce > 0)
            {
                Raylib.DrawTexture(TextureFalling, (int)_position.X, (int)_position.Y, Color.WHITE);
            }
            else
            {
                Raylib.DrawTexture(TextureRising, (int)_position.X, (int)_position.Y, Color.WHITE);
            }
            base.Render();
        }

        public override void Canvas()
        {
            Raylib.DrawText(Corn.ToString(),
                Window.VirtualWidth / 2, Window.VirtualHeight * 25 / 100,
                100, Color.WHITE);
            base.Canvas();
        }

        public void OnCollisionEnter(Collisor collisor)
        {
            if (collisor.Layer == "Scarecrow" || collisor.Layer == "Wall")
            {
                _dead = true;
            }
            if (collisor.Layer == "Score")
            {
                Corn++;
            }
        }

        public void OnCollisionExit(Collisor collisor)
        {

        }
    }
}
