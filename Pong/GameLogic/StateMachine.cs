using Pong.Entities;
using Pong.GameLogic.Enums;
using RayG;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Pong.GameLogic
{
    internal class StateMachine : GameObject
    {

        private GameState gameState;

        private Score Score { get; set; }
        private Ball Ball { get; set; }
        private Paddle LeftPaddle { get; set; }
        private Paddle RightPaddle { get; set; }
        private Menu Menu { get; set; }

        public StateMachine(Score score, Ball ball, Paddle leftPaddle, Paddle rightPaddle, Menu menu)
        {
            Score = score;
            Ball = ball;
            LeftPaddle = leftPaddle;
            RightPaddle = rightPaddle;
            Menu = menu;
        }

        public override void Start()
        {
            StartGame();

            base.Start();
        }

        public override void Update()
        {
            if (gameState == GameState.Start && Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                BeginGame();
            }
            else if (gameState == GameState.Play && Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                PauseGame();
            }
            else if (gameState == GameState.Pause && Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                ContinueGame();
            }

            if (gameState != GameState.Start && Raylib.IsKeyPressed(KeyboardKey.KEY_TAB))
            {
                StartGame();
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE))
            {
                QuitGame();
            }

            base.Update();
        }
        private void BeginGame()
        {
            gameState = GameState.Play;
            Score.ResetScore();
            Menu.Message = "";

            Ball.Side();
            Ball.Direction();
            Ball.Freeze = false;
        }

        private void StartGame()
        {
            gameState = GameState.Start;
            Menu.Message = "Press Space to Start";
            Ball.ResetBall();
            Ball.Freeze = true;
            LeftPaddle.Freeze = false;
            RightPaddle.Freeze = false;
        }

        private void PauseGame()
        {
            gameState = GameState.Pause;
            Menu.Message = "Paused";
            Ball.Freeze = true;
            LeftPaddle.Freeze = true;
            RightPaddle.Freeze = true;
        }

        private void ContinueGame()
        {
            gameState = GameState.Play;
            Menu.Message = "";
            Ball.Freeze = false;
            LeftPaddle.Freeze = false;
            RightPaddle.Freeze = false;
        }

        public void QuitGame()
        {
            //
        }
    }
}
