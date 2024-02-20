using RayG;
using Raylib_cs;
using System.Numerics;

namespace Pong.Entities
{
    public class Paddle : GameObject, ICollisor
    {
        private static float speed = Window.Height * 40/100;

        private static readonly Vector2 paddleSize = 
            new(Window.Height * 2/100, Window.Height * 6/100);
        private static readonly int topWall = Window.Height * 0 / 100;
        private static readonly int bottomWall = Window.Height * 100 / 100 - (int)paddleSize.Y;

        private KeyboardKey keyUp;
        private KeyboardKey keyDown;

        private Vector2 paddlePosition;

        public bool Freeze { get; set; }
        public bool IsLeft { get; set; }
        public Collisor Collisor { get; set; }

        public Paddle(bool isLeft)
        {
            IsLeft = isLeft;
        }

        public override void Start()
        {
            float positionX;
            
            if (IsLeft)
            {
                keyUp = KeyboardKey.KEY_W;
                keyDown = KeyboardKey.KEY_S;
                positionX = 10;
            }
            else
            {
                keyUp = KeyboardKey.KEY_UP;
                keyDown = KeyboardKey.KEY_DOWN;
                positionX = 90;
            }

            paddlePosition = new(Window.Width * positionX / 100 
                - paddleSize.X / 2, Window.Height * 50 / 100);
            Collisor = new(paddlePosition, paddleSize, "Paddle");

            base.Start();
        }
        public override void Update()
        {
            var deltaTime = Raylib.GetFrameTime();
            if (!Freeze)
            {
                if (Raylib.IsKeyDown(keyUp) && paddlePosition.Y > topWall)
                {
                    paddlePosition.Y += 2.0f * deltaTime * -speed;
                }
                if (Raylib.IsKeyDown(keyDown) && paddlePosition.Y < bottomWall)
                {
                    paddlePosition.Y += 2.0f * deltaTime * speed;
                }
                Collisor.Position = paddlePosition;
            }
            
            base.Update();
        }

        public override void Render()
        {
            Raylib.DrawRectangleV(paddlePosition, paddleSize, Color.WHITE);

            base.Render();
        }

        public void OnCollisionEnter(Collisor collider)
        {
            
        }

        public void OnCollisionExit(Collisor collisor)
        {
            
        }

        public void OnCollision(Collisor collisor)
        {
            
        }
    }
}
