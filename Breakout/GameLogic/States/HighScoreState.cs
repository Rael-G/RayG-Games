using Breakout.GameLogic.States.Enums;
using Breakout.Resources;
using RayG;
using Raylib_cs;

namespace Breakout.GameLogic.States
{
    internal class HighScoreState : StateBase
    {
        readonly SaveManager<List<Score>> _saveManager;
        List<Score> scores;

        const int fontSize = 40;
        int posX = Window.Width / 4;
        int posY = Window.Height / 2;
        const int spacing = 40;

        const string highScoresMsg = "High Scores";
        const int highScoresFontSize = 150;
        int highScoresSize;



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
            var lenght = Math.Min(scores.Count, 10);
            for(int i = 0; i < lenght; i++)
            {
                var scoreTextSize = Raylib.MeasureText(scores[i].HighScore.ToString(), fontSize);
                var nameTextSize = Raylib.MeasureText(scores[i].PlayerName, fontSize);

                Raylib.DrawText($"{i + 1}.", posX, pos, fontSize, Color.WHITE);
                Raylib.DrawText(scores[i].PlayerName, posX * 2 - spacing / 2, pos, fontSize, Color.WHITE);
                Raylib.DrawText(scores[i].HighScore.ToString(), posX * 3 - scoreTextSize, pos, fontSize, Color.WHITE);
                pos += fontSize;
            }
            base.Canvas();
        }

        private void Load()
        {
            try
            {
                scores = _saveManager.LoadDataAsync("Scores").Result;
            }
            catch
            {
                scores = new List<Score>();
            }
        }
    }
}
