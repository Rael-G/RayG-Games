using Breakout.Resources;
using RayG;
using Raylib_cs;

namespace Breakout.Entities
{
    internal class Ui : GameObject
    {
        public int Hearts { get; set; }
        public int Level { get; set; }
        public int Score { get; set; }
        public int Timer { get; set; }

        Rectangle Position;
        Sprite HearthSprite;

        const int fontSize = 50;
        readonly float size = Window.Width * 0.025f;

        float scoreWidth, levelWidth, height;
        string levelMsg;

        public Ui(Sprite sprite, int hearts) 
        { 
            Hearts = hearts;
            HearthSprite = sprite;
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
                Raylib.DrawTexturePro(HearthSprite.Texture, HearthSprite.Source, position, HearthSprite.Axis, 0, Color.White);
                position.X += size + Window.Width * 0.005f;
            }

            Raylib.DrawText(Timer.ToString(), (int)(Window.Width * 0.20f), (int)height, fontSize, Color.White);
            Raylib.DrawText(levelMsg, (int)levelWidth, (int)height, fontSize, Color.White);
            Raylib.DrawText(Score.ToString(), (int)scoreWidth, (int)height, fontSize, Color.White);

            base.Render();
        }
    }
}
