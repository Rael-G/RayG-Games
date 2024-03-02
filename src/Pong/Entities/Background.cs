using RayG;
using Raylib_cs;

namespace Pong.Entities
{
    public class Background : GameObject
    {
        public Color Color { get; set; }
        public Background(Color color) : base()
        {
            Color = color;
        }

        public override void Render()
        {
            Raylib.ClearBackground(Color);

            base.Render();
        }
    }
}
