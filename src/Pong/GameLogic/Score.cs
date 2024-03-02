using RayG;
using Raylib_cs;
using System.Numerics;

namespace Pong.GameLogic
{
    public class Score : GameObject
    {
        private Font font;
        private int fontSize;
        private int fontSpacing;
        private Color fontColor;

        private Vector2 leftScorePosition;
        private Vector2 rightScorePosition;

        public int LeftScoreValue { get; set; }
        public int RightScoreValue { get; set; }
        public FontManager FontManager { get; set; }

        public Score(FontManager fontManager)
        {
            FontManager = fontManager;
        }

        public override void Start()
        {
            font = FontManager.GetFont("mecha");
            fontSpacing = Window.Height * 1 / 100;
            fontColor = Color.White;
            fontSize = font.BaseSize * fontSpacing;

            leftScorePosition = new Vector2(Window.Width * 20 / 100,
                Window.Height * 10 / 100);
            rightScorePosition = new Vector2(Window.Width * 80 / 100,
                Window.Height * 10 / 100);

            base.Start();
        }

        public override void Update()
        {
            var leftScoreSize = Raylib.MeasureTextEx(font, LeftScoreValue.ToString(), fontSize, fontSpacing);
            var rightScoreSize = Raylib.MeasureTextEx(font, RightScoreValue.ToString(), fontSize, fontSpacing);

            leftScorePosition.X = Window.Width * 20 / 100 - leftScoreSize.X / 2;
            rightScorePosition.X = Window.Width * 80 / 100 - rightScoreSize.X / 2;

            base.Update();
        }

        public override void Canvas()
        {
            Raylib.DrawTextEx(font, LeftScoreValue.ToString(), leftScorePosition, fontSize, fontSpacing, fontColor);
            Raylib.DrawTextEx(font, RightScoreValue.ToString(), rightScorePosition, fontSize, fontSpacing, fontColor);

            base.Canvas();
        }

        public void ResetScore()
        {
            LeftScoreValue = 0;
            RightScoreValue = 0;
        }
    }
}
