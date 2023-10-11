using RayG;

namespace Breakout.GameLogic.States
{
    internal class StateMachine : GameObject
    {
        GameState State { get; set; }
        GameStateRef StateRef { get; set; }

        StartState StartState;
        HighScoreState HighScoreState;

        SoundManager _soundManager;

        public StateMachine(SoundManager soundManager) 
        {
            _soundManager = soundManager;
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

        }

        private void Serve()
        {

        }

        private void Play()
        {

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
