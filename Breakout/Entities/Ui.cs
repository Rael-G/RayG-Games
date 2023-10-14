using Breakout.GameLogic;
using Breakout.Resources;
using RayG;
using Raylib_cs;

namespace Breakout.Entities
{
    internal class Ui : GameObject
    {
        Rectangle Position;
        Sprite Sprite;
        public int Hearts { get; set; }
        public int Level;
        public int Score;
        float scoreWidth, levelWidth, height;
        int fontSize = 50;
        string levelMsg;

        float size = Window.Width * 0.025f;
        public Ui(Sprite sprite, int hearts) 
        { 
            Hearts = hearts;
            Sprite = sprite;
            Position = new Rectangle(Window.Width * 0.05f, Window.Height * 0.05f, size, size);
        }

        public override void Update()
        {
            levelMsg = $"Level {Level}";
            levelWidth = Window.Width * 0.50f - Raylib.MeasureText(levelMsg, fontSize) / 2;
            scoreWidth = Window.Width * 0.90f - Raylib.MeasureText(Score.ToString(), fontSize);
            height = Window.Height * 0.05f;

            base.Update();
        }

        public override void Canvas()
        {
            var position = Position;
            for (int i = 0; i < Hearts; i++)
            {
                Raylib.DrawTexturePro(Sprite.Texture, Sprite.Source, position, Sprite.Axis, 0, Color.WHITE);
                position.x += size + Window.Width * 0.005f;
            }

            Raylib.DrawText(levelMsg, (int)levelWidth, (int)height, fontSize, Color.WHITE);
            Raylib.DrawText(Score.ToString(), (int)scoreWidth, (int)height, fontSize, Color.WHITE);

            base.Render();
        }
    }
}
