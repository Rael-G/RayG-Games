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
            audioManager = new SoundManager(@"\Data\Pong\Audio\Sfx\", new string[]
            {
                "Pong.wav", "Wall.wav", "Score.wav"
            });
            fontManager = new FontManager(@"\Data\Pong\Fonts\", new string[]
            {
                "mecha.png"
            });

            resourceLayer = new GameObject() { Childs = { audioManager, fontManager } };
            Childs.Add(resourceLayer);

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

            background = new Background(Color.BLACK);
            
            defaultLayer = new GameObject() { Childs = { leftPaddle, rightPaddle, ball } };
            canvasLayer = new GameObject() { Childs = { score, menu } };
            logicLayer = new GameObject() { Childs = { match, stateMachine } };

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
