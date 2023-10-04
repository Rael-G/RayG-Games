using RayG;
using Raylib_cs;
using System.Numerics;

namespace EvilBird.Entities.Obstacles
{
    internal class ScarecrowScore : ScarecrowBase
    {
        public int Score { get; private set; }

        public ScarecrowScore(float initialPosition) : base(initialPosition) { }

        public override void Start()
        {
            Size = new Vector2(32, 128);
            Collisor = new(Position, Size, "Score");
            ResetPos = new(Window.VirtualWidth + Size.X * 1.5f, Window.VirtualHeight / 2 - Size.Y * 0.75f);
        }
        public override void Update()
        {
            Collisor.Position = Position;
            Collisor.Position += new Vector2(Size.X / 2 + Collisor.Area.X / 2);
            base.Update();
        }
        public override void Render()
        {
            //Draw Collisor
            Raylib.DrawRectangle((int)Collisor.Position.X, (int)Collisor.Position.Y,
                (int)Collisor.Area.X, (int)Collisor.Area.Y, Color.YELLOW);
        }
    }
}
