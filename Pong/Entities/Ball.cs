using RayG;
using RayG.Interfaces;
using Raylib_cs;
using System.Numerics;

namespace Pong.Entities
{
    public class Ball : GameObject, ICollisor
    {
        private static float initialBallSpeed = Window.Height * 6 / 100;
        private static readonly Vector2 initialPosition = 
            new (Window.Width * 50 / 100, Window.Height * 50 / 100);
        private static readonly Vector2 ballSize = 
            new (Window.Height * 2/100, Window.Height * 2/100);
        private static readonly int topWall = Window.Height * 0 / 100;
        private static readonly int bottomWall = Window.Height * 100 / 100;

        private int x, y;
        private float ballSpeed;

        public bool Freeze { get; set; }
        public Vector2 BallPosition { get; set; }
        public Collisor Collisor { get; set; }
        public SoundManager AudioManager { get; set; }

        public Ball (SoundManager audioManager)
        {
            AudioManager = audioManager;
        }

        public override void Start()
        {
            Freeze = true;
            ballSpeed = initialBallSpeed;
            BallPosition = initialPosition;
            Collisor = new(BallPosition, ballSize, "Ball");

            Side();
            Direction();

            base.Start();
        }

        public override void Update()
        {
            var deltaTime = Raylib.GetFrameTime();
            if (!Freeze)
            {
                BallPosition += ballSpeed * deltaTime * new Vector2(x, y);
                Collisor.Position = BallPosition;
            }
            
            if (BallPosition.Y <= topWall 
                || BallPosition.Y + ballSize.Y >= bottomWall) 
            {
                Invert(ref y);
                AudioManager.PlaySound("Wall");
            }
            
            base.Update();
        }

        public override void Render()
        {
            Raylib.DrawRectangleV(BallPosition, ballSize, Color.WHITE);

            base.Render();
        }

        public void OnCollisionEnter(Collisor collider)
        {
            var max = 10;
            var min = 1;

            if (y > 0)
            {
                Direction(min, max);
            }
            else if(y < 0)
            {
                Direction(-max, -min);
            }

            Invert(ref x);
            ballSpeed *= 1.10f;
            AudioManager.PlaySound("Pong");
        }

        public void OnCollisionExit(Collisor collider)
        {
        }

        private static void Invert(ref int xy)
        {
            xy *= -1;
        }

        public void Side(int min = 0, int max = 1)
        {
            x = Raylib.GetRandomValue(min, max) == 0 ? -10 : 10;
        }

        public void Direction(int min = -10, int max = 10)
        {
            y = Raylib.GetRandomValue(min, max);
            if (y == 0)
            {
                y = Raylib.GetRandomValue(min, max);
            }
        }

        public void ResetBall()
        {
            BallPosition = initialPosition;
            ballSpeed = initialBallSpeed;
        }
    }
}
