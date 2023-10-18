using Breakout.GameLogic.States.Enums;
using Breakout.Resources;
using RayG;

namespace Breakout.GameLogic.States
{
    internal class StateMachine : GameObject
    {
        GameState State { get; set; }
        GameStateRef StateRef { get; set; }

        StartState StartState;
        HighScoreState HighScoreState;
        ServeState ServeState;
        PlayState PlayState;
        GameOverState GameOverState;
        EnterHighScoreState EnterHighScoreState;

        GameController _gameController;
        readonly SoundManager _soundManager;
        readonly SpriteSheet _spriteSheet;
        readonly SaveManager<List<Score>> _saveManager;

        public StateMachine(SoundManager soundManager, SpriteSheet spriteSheet) 
        {
            _soundManager = soundManager;
            _spriteSheet = spriteSheet;
            _saveManager = new(Path.Combine(Environment.GetFolderPath
                (Environment.SpecialFolder.MyDocuments), "My Games", "Breakout"));
        }

        public override void Start()
        {
            State = new GameState();
            StateRef = new GameStateRef(State);
            StartGame();

            base.Start();
        }

        public override void Update()
        {
            if (State != StateRef.State)
            {
                State = StateRef.State;

                switch (State)
                {
                    case GameState.Start:
                        StartGame();
                        break;
                    case GameState.Serve:
                        Serve();
                        break;
                    case GameState.Play:
                        Play();
                        break;
                    case GameState.GameOver:
                        GameOver();
                        break;
                    case GameState.EnterHighScore:
                        EnterHighScore();
                        break;
                    case GameState.HighScore:
                        HighScore();
                        break;
                }
            }
            base.Update();
        }

        private void StartGame()
        {
            if (Children.Contains(HighScoreState))
            {
                Dispose(HighScoreState);
            }

            _gameController = new(_spriteSheet, _soundManager);
            Children.AddStart(_gameController);
            StartState = new(StateRef, _soundManager);
            Children.AddStart(StartState);
        }

        private void Serve()
        {
            if (Children.Contains(StartState))
            {
                Dispose(StartState);
            }
            if (Children.Contains(PlayState))
            {
                Dispose(PlayState);
            }

            ServeState = new(StateRef);
            Children.AddStart(ServeState);
        }

        private void Play()
        {
            if (Children.Contains(ServeState))
            {
                Dispose(ServeState);
            }

            PlayState = new(StateRef, _gameController);
            Children.AddStart(PlayState);
        }

        private void GameOver()
        {
            if (Children.Contains(PlayState))
            {
                Dispose(PlayState);
            }

            GameOverState = new(StateRef, _gameController);
            Children.AddStart(GameOverState);
        }

        private void EnterHighScore()
        {
            if (Children.Contains(GameOverState))
            {
                Dispose(GameOverState);
            }

            EnterHighScoreState = new(StateRef, _gameController, _saveManager);
            Children.AddStart(EnterHighScoreState);
        }

        private void HighScore()
        {
            if (Children.Contains(EnterHighScoreState))
            {
                Dispose(EnterHighScoreState);
            }
            if (Children.Contains(StartState))
            {
                Dispose(StartState);
            }

            HighScoreState = new(StateRef, _saveManager);
            Children.AddStart(HighScoreState);
        }
    }
}
