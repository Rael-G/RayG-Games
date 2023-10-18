using Breakout.GameLogic.States.Enums;
using Breakout.Resources;
using RayG;
using Raylib_cs;

namespace Breakout.GameLogic.States
{
    internal class HighScoreState : StateBase
    {
        List<Score> Scores;

        const int fontSize = 40;
        int posX = Window.Width / 4;
        int posY = Window.Height / 2;
        const int spacing = 40;

        const string highScoresMsg = "High Scores";
        const int highScoresFontSize = 150;
        int highScoresSize;

        readonly SaveManager<List<Score>> _saveManager;

        public HighScoreState(GameStateRef state, SaveManager<List<Score>> saveManager) : base(state) 
        {
            _saveManager = saveManager;
        }

        public override void Start()
        {
            highScoresSize = Raylib.MeasureText(highScoresMsg, highScoresFontSize);
            Load();
            base.Start();
        }

        public override void Update()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE))
            {
                StateRef.State = GameState.Start;
            }
            base.Update();
        }

        public override void Canvas()
        {
            Raylib.DrawText(highScoresMsg, Window.Width / 2 - highScoresSize / 2, Window.Height / 5, highScoresFontSize, Color.WHITE);

            var pos = posY;
            var lenght = Math.Min(Scores.Count, 10);
            for(int i = 0; i < lenght; i++)
            {
                var scoreTextSize = Raylib.MeasureText(Scores[i].HighScore.ToString(), fontSize);

                Raylib.DrawText($"{i + 1}.", posX, pos, fontSize, Color.WHITE);
                Raylib.DrawText(Scores[i].PlayerName, posX * 2 - spacing / 2, pos, fontSize, Color.WHITE);
                Raylib.DrawText(Scores[i].HighScore.ToString(), posX * 3 - scoreTextSize, pos, fontSize, Color.WHITE);
                pos += fontSize;
            }
            base.Canvas();
        }

        private void Load()
        {
            try
            {
                Scores = _saveManager.LoadDataAsync("Scores").Result;
            }
            catch
            {
                Scores = new List<Score>();
            }
        }
    }
}
