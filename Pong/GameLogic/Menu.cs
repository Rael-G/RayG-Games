using RayG;
using Raylib_cs;
using System.Numerics;


namespace Pong.GameLogic
{
    public class Menu : GameObject
    {
        private Font font;
        private int fontSize;
        private int fontSpacing;
        private Color fontColor;

        private Vector2 textPosition;

        public string Message { get; set; }
        public FontManager FontManager { get; set; }

        public Menu(FontManager fontManager)
        {
            FontManager = fontManager;
        }

        public override void Start()
        {
            font = FontManager.GetFont("mecha");
            fontColor = Color.White;
            fontSpacing = (int)(Window.Height * 0.5 / 100);
            fontSize = font.BaseSize * fontSpacing;

            textPosition = new Vector2();
            textPosition.Y = Window.Height * 40 / 100;

            base.Start();
        }

        public override void Update()
        {
            var textSize = Raylib.MeasureTextEx(font, Message.ToString(), fontSize, fontSpacing);

            textPosition.X = Window.Width * 50 / 100 - textSize.X / 2;

            base.Update();
        }

        public override void Canvas()
        {
            Raylib.DrawTextEx(font, Message, textPosition, fontSize, fontSpacing, fontColor);
            base.Canvas();
        }
    }
}
