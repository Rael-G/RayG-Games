using Breakout.GameLogic.States.Enums;
using Breakout.Resources;
using RayG;
using Raylib_cs;
using System.Numerics;
using System.Text;

namespace Breakout.GameLogic.States
{
    internal class EnterHighScoreState : StateBase
    {
        GameController _controller;
        SaveManager<List<Score>> _saveManager;

        int highlated = 0;
        byte[] letters = new byte[] { 65, 65, 65 };
        Color[] colors = new Color[]{ Color.WHITE, Color.WHITE, Color.WHITE};
        string asciiLetters;

        const int messageHeigth = 100;
        int messageWidth;
        Vector2 messagePos;

        const int lettersHeight = 200;
        int lettersWidth;
        Vector2 lettersPos;

        public EnterHighScoreState(GameStateRef state, GameController controller, 
            SaveManager<List<Score>> saveManager) : base(state)
        {
            _controller = controller;
            _saveManager = saveManager;
        }

        public override void Start()
        {
            messageWidth = Raylib.MeasureText(_controller.Score.ToString(), messageHeigth);
            messagePos = new Vector2(Window.Width / 2 - messageWidth / 2, Window.Height / 5);

            lettersWidth = Raylib.MeasureText("W", lettersHeight);
            lettersPos = new Vector2(Window.Width / 2, Window.Height / 2);
            base.Start();
        }

        public override void Update()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
            {
                List<Score> scores;
                try
                {
                    scores = _saveManager.LoadDataAsync("Scores").Result;
                }
                catch
                {
                    scores = new List<Score>();
                }

                scores.Add(new Score(asciiLetters, _controller.Score));

                scores = scores.OrderByDescending(s => s.HighScore).ToList();

                _saveManager.SaveDataAsync("Scores", scores);
                StateRef.State = GameState.HighScore;
            }

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_RIGHT) && highlated < 2)
            {
                highlated++;
            }
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT) && highlated > 0)
            {
                highlated--;
            }

            LetterDown();
            LetterUp();
            ColorChange();

            base.Update();

        }

        public override void Canvas()
        {
            Raylib.DrawText(_controller.Score.ToString(), (int)messagePos.X, (int)messagePos.Y, messageHeigth, Color.WHITE);

            ASCIIEncoding asciiEncoding = new ASCIIEncoding();
            asciiLetters = asciiEncoding.GetString(letters);

            int posX = (int)(lettersPos.X - lettersWidth * 1.50f);
            for (int i = 0; i < asciiLetters.Length; i++)
            {
                Raylib.DrawText(asciiLetters[i].ToString(), posX, (int)lettersPos.Y, lettersHeight, colors[i]);
                posX += lettersWidth;
            }

            base.Canvas();
        }

        private void LetterDown()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_DOWN))
            {
                letters[highlated]--;
                if (letters[highlated] < 65)
                {
                    letters[highlated] = 90;
                }
            }
           
        }

        private void LetterUp()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_UP))
            {
                letters[highlated]++;
                if (letters[highlated] > 90)
                {
                    letters[highlated] = 65;
                }
            }
        }

        private void ColorChange()
        {
            for (int i = 0; i < letters.Length; i++)
            {
                if (i == highlated)
                {
                    colors[i] = Color.BLUE;
                }
                else
                {
                    colors[i] = Color.WHITE;

                }
            }
        }
    }
}
