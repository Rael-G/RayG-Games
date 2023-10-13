using Breakout.GameLogic;
using Breakout.Resources;
using RayG;
using Raylib_cs;
using System.Numerics;

namespace Breakout.Entities
{
    internal class Ball : GameObject, ICollisor
    {
        Sprite Sprite { get; set; }
        public Collisor Collisor { get; set; }
        public bool Dead { get; set; }

        readonly Vector2 _initialPosition = new Vector2(Window.VirtualWidth / 2, Window.VirtualHeight / 2);

        Rectangle Position;

        float deltaY, deltaX;

        SoundManager _soundManager;

        public Ball(Sprite sprite, SoundManager soundManager) 
        {
            Sprite = sprite;
            Dead = false;
            _soundManager = soundManager;
        }

        public override void Start()
        {
            deltaX = 0;
            deltaY = 0;
            Position = new (Window.VirtualWidth / 2 - 1, Window.VirtualHeight / 2 - 1, Sprite.Width, Sprite.Height);
            Collisor = new((int)Position.x, (int)Position.y, Sprite.Width, Sprite.Height, "Ball");

            base.Start();
        }

        public override void Update()
        {
            var deltatime = Raylib.GetFrameTime();
            Position.x += deltaX * deltatime;
            Position.y += deltaY * deltatime;

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
            Dead = false;
            deltaX = Raylib.GetRandomValue(-200, 200);
            deltaY = Raylib.GetRandomValue(-50, -60);
        }

        public void Stop()
        {
            Dead = true;
            Position.y = _initialPosition.Y;
            Position.x = _initialPosition.X;
            deltaX = 0;
            deltaY = 0;
        }

        private void WallCollision()
        {
            if (Position.x <= 0)
            {
                Position.x = 0;
                deltaX = -deltaX;
                _soundManager.PlaySound("Wall");

            }
            else if (Position.x >= Window.VirtualWidth - Sprite.Width)
            {
                Position.x = Window.VirtualWidth - Sprite.Width;
                deltaX = -deltaX;
                _soundManager.PlaySound("Wall");
            }

            if (Position.y <= 0)
            {
                Position.y = 0;
                deltaY = -deltaY;
                _soundManager.PlaySound("Wall");

            }
            else if (Position.y >= Window.VirtualHeight - Sprite.Height)
            {
                _soundManager.PlaySound("Death");
                Stop();
            }
        }

        public void OnCollisionEnter(Collisor collider)
        {
            if (collider.Layer == "Paddle")
            {
                deltaY = -deltaY;
                var diference = Position.x + Position.width / 2 - (collider.Position.X + collider.Area.X / 2);
                deltaX = diference * 12;
                deltaY *= 1.02f;

                _soundManager.PlaySound("Paddle", 0.5f);
            }

            var side = Collisor.CollisionSide(collider);

            if (collider.Layer == "Brick")
            {
                if (side == Side.Top || side == Side.Bottom)
                {
                    deltaY = -deltaY;
                }
                else
                {
                    deltaX = -deltaX;
                }

            }

        }

        public void OnCollisionExit(Collisor collider)
        {
            
        }
    }
}
