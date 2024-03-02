using Mario;
using RayG;
using Raylib_cs;
using System.Numerics;

namespace Mario
{
    internal class Camera : GameObject
    {
        public Camera2D Camera2d;

        Player Player;
        Vector2 Offset;
        Vector2 Target;
        const float min = 184;
        const float max = 3916;

        static float minSpeed = 30;
        static float minEffectLength = 10;
        static float fractionSpeed = 2f;

        public Camera(Player player)
        {
            Player = player;
            Camera2d = new Camera2D();
        }

        public override void Start()
        {
            Offset = new Vector2(Window.Width / 2, Window.Height / 2);
            Target = new Vector2(Player.Collisor.Position.X, Player.Collisor.Position.Y * 0.7f);
            Camera2d.Target = Target;
            base.Start();
        }

        public override void Update()
        {
            Target = new Vector2(Player.Collisor.Position.X, Target.Y);

            var delta = Raylib.GetFrameTime();
            Vector2 diff = Vector2.Subtract(new Vector2(Target.X, Target.Y), Camera2d.Target);
            float length = diff.Length();

            if (length > minEffectLength)
            {
                float speed = Math.Max(fractionSpeed * length, minSpeed);
                Target = Vector2.Add(Camera2d.Target, Vector2.Multiply(diff, speed * delta / length));
                Target.X = Math.Min(Target.X, max - Window.VirtualWidth / 2 / 2);
                Target.X = Math.Max(Target.X, min + Window.VirtualWidth / 2 / 2);
                Camera2d.Target = Target;
            }

            Camera2d.Offset = Offset;
            Camera2d.Zoom = Window.Scale;
            Camera2d.Rotation = 0;

            base.Update();
        }

    }

}
