using EvilBird.Resources;
using RayG;
using Raylib_cs;
using System.Numerics;

namespace EvilBird.Entities.Obstacles
{
    internal class ScarecrowDown : ScarecrowBase
    {
        public ScarecrowDown(float initialSpawn, Texture2D texture) 
            : base(initialSpawn, texture) { }

        public override void Start()
        {
            base.Start();
            ResetPos = new(Window.VirtualWidth, Texture.height * 1.2f);
        }

        public override void Update()
        {
            Collisor.Position = Position;
            Collisor.Position += new Vector2(Texture.width / 2 + Collisor.Area.X / 2, 5);
            base.Update();
        }
        public override void Render()
        {
            base.Render();
            Raylib.DrawTextureEx(Texture, Position, 0, 2, Color.WHITE);
        }
    }
}
