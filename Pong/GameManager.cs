using Pong.Entities;
using Pong.GameLogic;
using Pong.Resources;
using RayG;
using Raylib_cs;

namespace Pong
{
    internal class GameManager : GameObject
    {
        private readonly Ball ball;
        private readonly Paddle leftPaddle;
        private readonly Paddle rightPaddle;
        private readonly Score score;
        private readonly Menu menu;
        private readonly Match match;
        private readonly StateMachine stateMachine;
        private readonly AudioManager audioManager;
        private readonly FontManager fontManager;

        private readonly Background background;
        private readonly GameObject defaultLayer;
        private readonly GameObject canvasLayer;
        private readonly GameObject logicLayer;

        public GameManager()
        {
            audioManager = new AudioManager();
            fontManager = new FontManager();
            leftPaddle = new Paddle(true);
            rightPaddle = new Paddle(false);
            ball = new Ball(audioManager);
            score = new Score(fontManager);
            menu = new Menu(fontManager);
            match = new(ball, score, audioManager);
            stateMachine = new StateMachine(score, ball, leftPaddle, rightPaddle, menu);

            background = new Background(Color.BLACK);
            defaultLayer = new GameObject() { Childs = { leftPaddle, rightPaddle, ball } };
            canvasLayer = new GameObject() { Childs = { score, menu } };
            logicLayer = new GameObject() { Childs = { match, stateMachine, audioManager, fontManager } };
        }

        public override void Config()
        {
            Window.Name = "Pong";
            Window.Width = 800;
            Window.Height = 450;
            Raylib.SetTargetFPS(144);

            base.Config();
        }

        public override void Start()
        {
            Childs.Add(background);
            Childs.Add(defaultLayer);
            Childs.Add(logicLayer);
            Childs.Add(canvasLayer);

            base.Start();
        }

        public override void Update()
        {
            defaultLayer.Collision();

            base.Update();
        }
    }
}
