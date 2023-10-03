using EvilBird.Resources;
using RayG;
using Raylib_cs;

namespace EvilBird.Entities.Obstacles
{
    internal class ScarecrowUp : ScarecrowBase
    {
        public ScarecrowUp(float initialSpawn, Texture2D texture)
            : base(initialSpawn, texture) { }

        public override void Start()
        {
            base.Start();
            ResetPos = new(Window.VirtualWidth + Texture.width * 2, Window.VirtualHeight - Texture.height * 1.2f);
        }
        public override void Render()
        {
            Raylib.DrawTextureEx(Texture, Position, 180, 2, Color.WHITE);
            base.Render();
        }
    }
}
