using Breakout.GameLogic.States.Enums;
using RayG;
using Raylib_cs;
using System.Numerics;

namespace Breakout.GameLogic.States
{
    internal class StartState : StateBase
    {
        const string breakoutMsg = "Breakout";
        const string startMsg = "Start";
        const string highScoreMsg = "High Score";
        const int breakoutHeight = 150;
        const int optionsHeight = 50;

        int highlated;
        int breakoutWidth;
        int startWidth;
        int highScoreWidth;
        Vector2 breakoutPosition;
        Vector2 startPosition;
        Vector2 highScorePosition;
        Color startColor = Color.Blue;
        Color highScoreColor = Color.White;

        readonly SoundManager _soundManager;

        public StartState(GameStateRef state, SoundManager soundManager) : base(state)
        {
            _soundManager = soundManager;
            highlated = 1;
        }

        public override void Start()
        {
            breakoutWidth = Raylib.MeasureText(breakoutMsg, breakoutHeight);
            startWidth = Raylib.MeasureText(startMsg, optionsHeight);
            highScoreWidth = Raylib.MeasureText(highScoreMsg, optionsHeight);

            breakoutPosition = new(Window.Width / 2 - breakoutWidth / 2, Window.Height / 2 - breakoutHeight);
            startPosition = new(Window.Width / 2 - startWidth / 2, Window.Height - optionsHeight * 4);
            highScorePosition = new(Window.Width / 2 - highScoreWidth / 2, Window.Height - optionsHeight * 2);
            base.Start();
        }

        public override void Update()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.Escape))
            {
                Window.Running = false;
            }
            if (Raylib.IsKeyPressed(KeyboardKey.Enter))
            {
                if (highlated == 1)
                {
                    StateRef.State = GameState.Serve;
                }
                else
                {
                    StateRef.State = GameState.HighScore;
                }
            }
            if(Raylib.IsKeyPressed(KeyboardKey.Up) && highlated < 1)
            {
                startColor = Color.Blue;
                highScoreColor = Color.White;
                _soundManager.PlaySound("Select");
                highlated++;
            }
            else if(Raylib.IsKeyPressed(KeyboardKey.Down) && highlated > 0)
            {
                startColor = Color.White;
                highScoreColor = Color.Blue;
                _soundManager.PlaySound("Select");
                highlated--;
            }
            base.Update();
        }

        public override void Canvas()
        {
            Raylib.DrawText(breakoutMsg, (int)breakoutPosition.X, (int)breakoutPosition.Y, breakoutHeight, Color.White);
            Raylib.DrawText(startMsg, (int)startPosition.X, (int)startPosition.Y, optionsHeight, startColor);
            Raylib.DrawText(highScoreMsg, (int)highScorePosition.X, (int)highScorePosition.Y, optionsHeight, highScoreColor);
            base.Canvas();
        }
    }
}
