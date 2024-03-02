using RayG;
using Raylib_cs;
using System.Numerics;

namespace Breakout.GameLogic
{
    internal class Camera : GameObject
    {
        public Camera2D Camera2d;

        Vector2 Target;
        Vector2 Offset;

        public Camera()
        {
            Camera2d = new Camera2D();
        }

        public override void Start()
        {
            Offset = new Vector2(Window.Width / 2, Window.Height / 2);
            Target = new Vector2(Window.VirtualWidth / 2, Window.VirtualHeight / 2);
            base.Start();
        }

        public override void Update()
        {
            Camera2d.Target =Target;
            Camera2d.Offset = Offset;
            Camera2d.Zoom = Window.Scale;
            Camera2d.Rotation = 0;

            base.Update();
        }

    }
}
