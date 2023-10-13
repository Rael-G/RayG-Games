using Breakout.GameLogic;
using Breakout.Resources;
using RayG;
using Raylib_cs;

namespace Breakout.Entities
{
    internal class Health : GameObject
    {
        Rectangle Position;
        Sprite Sprite;
        public int Hearts { get; set; }

        float size = Window.Width * 0.025f;
        public Health(Sprite sprite, int hearts) 
        { 
            Hearts = hearts;
            Sprite = sprite;
            Position = new Rectangle(Window.Width * 0.05f, Window.Height * 0.05f, size, size);
        }

        public override void Canvas()
        {
            var position = Position;
            for (int i = 0; i < Hearts; i++)
            {
                Raylib.DrawTexturePro(Sprite.Texture, Sprite.Source, position, Sprite.Axis, 0, Color.WHITE);
                position.x += size + Window.Width * 0.005f;
            }

            base.Render();
        }
    }
}
