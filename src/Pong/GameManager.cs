using Pong.Entities;
using Pong.GameLogic;
using RayG;
using Raylib_cs;

namespace Pong
{
    internal class GameManager : GameObject
    {
        private Ball ball;
        private Paddle leftPaddle;
        private Paddle rightPaddle;
        private Score score;
        private Menu menu;
        private Match match;
        private StateMachine stateMachine;
        private SoundManager audioManager;
        private FontManager fontManager;

        private Background background;
        private GameObject defaultLayer;
        private GameObject resourceLayer;
        private GameObject canvasLayer;
        private GameObject logicLayer;

        public override void Config()
        {
            Window.Name = "Pong";
            Window.Width = 800;
            Window.Height = 450;
            Raylib.SetTargetFPS(144);

            base.Config();
        }

        public override void Awake()
        {
            audioManager = new SoundManager(@"\Data\Pong\Audio\Sfx\");
            fontManager = new FontManager(@"\Data\Pong\Fonts\");

            resourceLayer = new GameObject() { Children = { audioManager, fontManager } };
            Children.Add(resourceLayer);

            base.Awake();
        }

        public override void Start()
        {
            leftPaddle = new Paddle(true);
            rightPaddle = new Paddle(false);
            ball = new Ball(audioManager);
            score = new Score(fontManager);
            menu = new Menu(fontManager);
            match = new(ball, score, audioManager);
            stateMachine = new StateMachine(score, ball, leftPaddle, rightPaddle, menu);

            background = new Background(Color.Black);
            
            defaultLayer = new GameObject() { Children = { leftPaddle, rightPaddle, ball } };
            canvasLayer = new GameObject() { Children = { score, menu } };
            logicLayer = new GameObject() { Children = { match, stateMachine } };

            Children.Add(background);
            Children.Add(defaultLayer);
            Children.Add(logicLayer);
            Children.Add(canvasLayer);

            base.Start();
        }

        public override void Update()
        {
            defaultLayer.StartCollision();

            base.Update();
        }
    }
}
