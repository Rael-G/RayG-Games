using Pong.Entities;
using Pong.GameLogic;
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
        private readonly SoundManager audioManager;
        private readonly FontManager fontManager;

        private readonly Background background;
        private readonly GameObject defaultLayer;
        private readonly GameObject resourceLayer;
        private readonly GameObject canvasLayer;
        private readonly GameObject logicLayer;

        public GameManager()
        {
            audioManager = new SoundManager(@"\Data\Pong\Audio\Sfx\", new string[]
            {
                "Pong.wav", "Wall.wav", "Score.wav"
            });
            fontManager = new FontManager(@"\Data\Pong\Fonts\", new string[]
            {
                "mecha.png"
            });

            leftPaddle = new Paddle(true);
            rightPaddle = new Paddle(false);
            ball = new Ball(audioManager);
            score = new Score(fontManager);
            menu = new Menu(fontManager);
            match = new(ball, score, audioManager);
            stateMachine = new StateMachine(score, ball, leftPaddle, rightPaddle, menu);

            background = new Background(Color.BLACK);
            resourceLayer = new GameObject() { Childs = { audioManager } };
            defaultLayer = new GameObject() { Childs = { leftPaddle, rightPaddle, ball } };
            canvasLayer = new GameObject() { Childs = { score, menu } };
            logicLayer = new GameObject() { Childs = { match, stateMachine, fontManager } };
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
            Childs.Add(resourceLayer);
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
