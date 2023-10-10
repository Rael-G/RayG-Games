using RayG;
using RayG.Interfaces;
using Raylib_cs;
using System.Numerics;


namespace EvilBird.Entities
{
    internal class Bird : GameObject, ICollisor
    {
        public Collisor Collisor { get; set; }
        public int Corn { get; private set; }
        public bool Dead { get; private set; }

        private Vector2 Size;
        private Vector2 Position;
        private float FallForce;
        private Texture2D TextureRising;
        private Texture2D TextureFalling;

        private const float _gravity = 12;
        private TextureManager _textureManager;
        private SoundManager _audioManager;

        public Bird(TextureManager textureManager, SoundManager audioManager) 
        {
            Dead = false;
            _textureManager = textureManager;
            _audioManager = audioManager;
        }

        public override void Start()
        {
            TextureRising = _textureManager.GetTexture("EvilBirdRising");
            TextureFalling = _textureManager.GetTexture("EvilBirdFalling");
            Size = new Vector2(TextureRising.width, TextureRising.height);
            Position = new Vector2(Window.VirtualWidth / 2 - Size.X / 2, 
                Window.VirtualHeight / 2 - Size.Y / 2);

            Collisor = new(Position, new Vector2(Size.X, Size.Y / 2), "Bird");

            base.Start();
        }

        public override void Update()
        {
            FallForce += _gravity * Raylib.GetFrameTime();
            Position.Y += FallForce;

            if (!Dead && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT)
                || Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                FallForce = -2.5f;
                _audioManager.PlaySound("Jump");
            }

            Collisor.Position = Position;
            Collisor.Position += new Vector2(0, Size.Y / 4) ;
            base.Update();
        }

        public override void Render()
        {
            //Draw Collisor
            //Raylib.DrawRectangle((int)Collisor.Position.X, (int)Collisor.Position.Y,
            //    (int)Collisor.Area.X, (int)Collisor.Area.Y, Color.RED);

            if (FallForce > 0)
            {
                Raylib.DrawTexture(TextureFalling, (int)Position.X, (int)Position.Y, Color.WHITE);
            }
            else
            {
                Raylib.DrawTexture(TextureRising, (int)Position.X, (int)Position.Y, Color.WHITE);
            }
            base.Render();
        }

        public void OnCollisionEnter(Collisor collisor)
        {
            if (collisor.Layer == "Scarecrow" || collisor.Layer == "Wall")
            {
                Dead = true;
                _audioManager.PlaySound("Death");
            }
            if (collisor.Layer == "Score")
            {
                Corn++;
                _audioManager.PlaySound("Corn");
            }
        }

        public void OnCollisionExit(Collisor collisor)
        {

        }
    }
}
