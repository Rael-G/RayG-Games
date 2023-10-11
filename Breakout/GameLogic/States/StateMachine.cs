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
        PaddleSelectState PaddleSelectState;
        ServeState ServeState;
        PlayState PlayState;

        SoundManager _soundManager;
        SpriteSheet _spriteSheet;

        public StateMachine(SoundManager soundManager, SpriteSheet spriteSheet) 
        {
            _soundManager = soundManager;
            _spriteSheet = spriteSheet;
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
                    case GameState.PaddleSelect:
                        PaddleSelect();
                        break;
                    case GameState.Serve:
                        Serve();
                        break;
                    case GameState.Play:
                        Play();
                        break;
                    case GameState.Victory:
                        Victory();
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
            if (Childs.Contains(HighScoreState))
            {
                Childs.Remove(HighScoreState);
                HighScoreState.Dispose();
            }

            StartState = new(StateRef, _soundManager);
            Childs.Add(StartState);
            StartState.Start();
        }

        private void PaddleSelect()
        {
            if (Childs.Contains(StartState))
            {
                Childs.Remove(StartState);
                StartState.Dispose();
            }

            PaddleSelectState = new(StateRef);
            Childs.Add(PaddleSelectState);
            PaddleSelectState.Start();
        }

        private void Serve()
        {
            if (Childs.Contains(PaddleSelectState))
            {
                Childs.Remove(PaddleSelectState);
                PaddleSelectState.Dispose();
            }

            ServeState = new(StateRef);
            Childs.Add(ServeState);
            ServeState.Start();
        }

        private void Play()
        {
            if (Childs.Contains(ServeState))
            {
                Childs.Remove(ServeState);
                ServeState.Dispose();
            }

            PlayState = new(StateRef, _spriteSheet, _soundManager);
            Childs.Add(PlayState);
            PlayState.Start();
        }

        private void Victory()
        {

        }

        private void GameOver()
        {

        }

        private void EnterHighScore()
        {

        }

        private void HighScore()
        {

        }
    }
}
