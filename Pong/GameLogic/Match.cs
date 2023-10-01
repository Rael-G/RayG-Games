using Pong.Entities;
using Pong.Resources;
using RayG;

namespace Pong.GameLogic
{
    public class Match : GameObject
    {
        private static readonly int leftWall = Window.Width * 5 / 100;
        private static readonly int rightWall = Window.Width * 95 / 100;

        private Ball Ball { get; set; }
        public Score Score { get; set; }
        private AudioManager AudioManager { get; set; }
        public Match(Ball ball, Score score, AudioManager audioManager)
        {
            Ball = ball;
            Score = score;
            AudioManager = audioManager;
        }

        public override void Update()
        {
            if (Ball.BallPosition.X <= leftWall)
            {
                Ball.ResetBall();
                Ball.Direction();
                Ball.Side(1, 1);
                Score.RightScoreValue++;
                AudioManager.Play("score");
            }
            else if (Ball.BallPosition.X >= rightWall)
            {
                Ball.ResetBall();
                Ball.Direction();
                Ball.Side(0, 0);
                Score.LeftScoreValue++;
                AudioManager.Play("score");
            }


            base.Update();
        }
    }
}
