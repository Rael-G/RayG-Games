using RayG;
using Raylib_cs;
using System.Numerics;

namespace EvilBird.Entities.Obstacles
{
    internal class ScarecrowDown : ScarecrowBase
    {
        private Texture2D Texture;

        public ScarecrowDown(float initialSpawn, Texture2D texture) 
            : base(initialSpawn) 
        { 
            Texture = texture;
        }

        public override void Start()
        {
            base.Start();
            ResetPos = new(Window.VirtualWidth, Size.Y * 1.2f);
        }

        public override void Update()
        {
            Collisor.Position = Position;
            Collisor.Position += new Vector2(Size.X / 2 + Collisor.Area.X / 2, 5);
            base.Update();
        }
        public override void Render()
        {
            base.Render();
            Raylib.DrawTextureEx(Texture, Position, 0, 2, Color.WHITE);
        }
    }
}
