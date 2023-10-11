using Breakout.Resources;
using RayG;
using RayG.Interfaces;
using Raylib_cs;
using System.Numerics;

namespace Breakout.Entities
{
    internal class Ball : GameObject, ICollisor
    {
        Sprite Sprite { get; set; }
        public Collisor Collisor { get; set; }

        Rectangle Position;

        float deltaY, deltaX;

        SoundManager _soundManager;

        public Ball(Sprite sprite, SoundManager soundManager) 
        {
            Sprite = sprite;
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
            deltaX = Raylib.GetRandomValue(-200, 200);
            deltaY = Raylib.GetRandomValue(-50, -60);
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
                Position.x = Window.VirtualWidth - 3;
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
                Position.y = Window.VirtualHeight - 3;
                deltaY = -deltaY;
                _soundManager.PlaySound("Wall");
            }
        }

        public void OnCollisionEnter(Collisor collisor)
        {
            if (collisor.Layer == "Paddle")
            {
                deltaY = -deltaY;
            }
        }

        public void OnCollisionExit(Collisor collisor)
        {
            
        }
    }
}
