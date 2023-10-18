using Breakout.Resources;
using RayG;
using Raylib_cs;
using System.Numerics;

namespace Breakout.Entities
{
    internal class Ball : GameObject, ICollisor
    {
        public Collisor Collisor { get; set; }
        public bool Dead { get; set; }

        Sprite Sprite;
        Rectangle Position;

        readonly Vector2 initialPosition = new Vector2(Window.VirtualWidth / 2, Window.VirtualHeight / 2);

        public float DeltaY;
        public float DeltaX;

        readonly SoundManager _soundManager;

        public Ball(Sprite sprite, SoundManager soundManager) 
        {
            Sprite = sprite;
            _soundManager = soundManager;
        }

        public override void Start()
        {
            Position = new (Window.VirtualWidth / 2 - 1, Window.VirtualHeight / 2 - 1, Sprite.Width * 0.75f, Sprite.Height * 0.75f);
            Collisor = new((int)Position.x, (int)Position.y, Sprite.Width, Sprite.Height, "Ball");

            base.Start();
        }

        public override void Update()
        {
            var deltatime = Raylib.GetFrameTime();
            Position.x += DeltaX * deltatime;
            Position.y += DeltaY * deltatime;

            WallCollision();
            Collisor.Position = new(Position.x, Position.y);

            base.Update();
        }

        public override void Render()
        {
            Raylib.DrawTexturePro(Sprite.Texture, Sprite.Source, Position, Sprite.Axis, 0, Color.WHITE);
            base.Render();
        }

        public void Play()
        {
            Stop();
            Collisor.Active = true;
            Dead = false;
            DeltaX = Raylib.GetRandomValue(-200, 200);
            DeltaY = Raylib.GetRandomValue(-50, -60);
        }

        public void Stop()
        {
            Collisor.Active = false;
            Position.y = initialPosition.Y;
            Position.x = initialPosition.X;
            DeltaX = 0;
            DeltaY = 0;
        }

        private void WallCollision()
        {
            if (Position.x <= 0)
            {
                Position.x = 0;
                DeltaX = -DeltaX;
                _soundManager.PlaySound("Wall");

            }
            else if (Position.x >= Window.VirtualWidth - Sprite.Width)
            {
                Position.x = Window.VirtualWidth - Sprite.Width;
                DeltaX = -DeltaX;
                _soundManager.PlaySound("Wall");
            }

            if (Position.y <= 0)
            {
                Position.y = 0;
                DeltaY = -DeltaY;
                _soundManager.PlaySound("Wall");

            }
            else if (Position.y >= Window.VirtualHeight - Sprite.Height)
            {
                _soundManager.PlaySound("Death", 0.20f);
                Dead = true;
                Stop();
            }
        }

        public void OnCollisionEnter(Collisor collider)
        {
            if (collider.Layer == "Paddle")
            {
                DeltaY = -DeltaY;
                var diference = Position.x + Position.width / 2 - (collider.Position.X + collider.Area.X / 2);
                DeltaX = diference * 12;
                DeltaY *= 1.02f;

                _soundManager.PlaySound("Paddle", 0.5f);
            }

            var side = Collisor.CollisionSide(collider);

            if (collider.Layer == "Brick")
            {
                const int safeSpacing = 3;

                if (side == Side.Top)
                {
                    Position.y = collider.Position.Y - Position.height - safeSpacing;
                    DeltaY = -DeltaY;
                }
                else if (side == Side.Bottom)
                {
                    Position.y = collider.Position.Y + collider.Area.Y + safeSpacing;
                    DeltaY = -DeltaY;
                }
                else if (side == Side.Left)
                {
                    Position.x = collider.Position.X - Position.width - safeSpacing;
                    DeltaX = -DeltaX;
                }
                else
                {
                    Position.x = collider.Position.X + collider.Area.X + safeSpacing;
                    DeltaX = -DeltaX;
                }
            }
        }

        public void OnCollisionExit(Collisor collider)
        {
            
        }
    }
}
