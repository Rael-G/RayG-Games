using EvilBird.Resources;
using RayG;
using RayG.Interfaces;
using Raylib_cs;
using System.Numerics;


namespace EvilBird.Entities
{
    internal class Bird : GameObject, ICollisor

    { 
        public Vector2 _size;
        public Vector2 _position;
        public float _gravity = 12;
        public float _fallForce = 0;
        public float _jumpForce = 150;

        private TextureManager _textureManager;
        private Texture2D TextureRising;
        private Texture2D TextureFalling;
        public Collisor Collisor { get; set; }

        public Bird(TextureManager textureManager) 
        {
            _textureManager = textureManager;
            Collisor = new(_position, _size, "Bird");
        }

        public override void Start()
        {
            TextureRising = _textureManager.GetTexture("EvilBirdRising");
            TextureFalling = _textureManager.GetTexture("EvilBirdFalling");

            _size = new Vector2(TextureRising.width, TextureRising.height);
            _position = new Vector2(Window.VirtualWidth / 2 - _size.X / 2, Window.VirtualHeight / 2 - _size.Y / 2);
            base.Start();
        }

        public override void Update()
        {
            _fallForce += _gravity * Raylib.GetFrameTime();
            _position.Y += _fallForce;

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                _fallForce = -2.5f;
            }
            base.Update();
        }

        public override void Render()
        {
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

        public void OnCollisionEnter(Collisor collisor)
        {

        }

        public void OnCollisionExit(Collisor collisor)
        {

        }
    }
}
