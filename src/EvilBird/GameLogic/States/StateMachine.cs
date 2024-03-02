using EvilBird.Entities;
using EvilBird.Entities.Obstacles;
using EvilBird.Enums;
using RayG;

namespace EvilBird.GameLogic.States
{
    internal class StateMachine : GameObject
    {
        GameState GameStateActual;
        GameStateRef GameStateRef;
        StartState StartState;
        CountDownState CountDownState;
        PlayState PlayState;
        ScoreState ScoreState;

        TextureManager _textureManager;
        SoundManager _audioManager;

        GameObject States { get; set; }

        public StateMachine(TextureManager textureManager, SoundManager audioManager) 
        {
            _textureManager = textureManager;
            _audioManager = audioManager;
            States = new GameObject();
            GameStateRef = new(GameState.Start);
            Children.Add(States);
        }

        public override void Update()
        {
            if (GameStateActual != GameStateRef.State)
            {
                GameStateActual = GameStateRef.State;

                switch (GameStateActual)
                {
                    case GameState.Start:
                        StartGame();
                        break;
                    case GameState.CountDown:
                         CountDown();
                        break;
                    case GameState.Play:
                        Play();
                        break;
                    case GameState.Score:
                        Stop();
                        break;
                }
            }
            base.Update();
        }

        public void StartGame()
        {
            StartState = new(GameStateRef);
            States.Children.Add(StartState);
            StartState.Start();
        }

        public void CountDown()
        {
            if (States.Children.Contains(StartState))
            {
                States.Children.Remove(StartState);
                StartState.Dispose();
            }
            else if (States.Children.Contains(ScoreState))
            {
                States.Children.Remove(ScoreState);
                ScoreState.Dispose();
            }

            CountDownState = new(GameStateRef, _audioManager);
            States.Children.Add(CountDownState);
            CountDownState.Start();
        }

        public void Play()
        {
            if (States.Children.Contains(CountDownState))
            {
                States.Children.Remove(CountDownState);
                CountDownState.Dispose();
            }

            PlayState = new(GameStateRef, new Bird(_textureManager, _audioManager), new ObstacleManager(_textureManager));
            States.Children.Add(PlayState);
            PlayState.Start();
        }

        public void Stop()
        {
            var corns = PlayState.Corns;

            if (States.Children.Contains(PlayState))
            {
                States.Children.Remove(PlayState);
                PlayState.Dispose();
            }

            ScoreState = new ScoreState(GameStateRef, corns.ToString());
            States.Children.Add(ScoreState);
            ScoreState.Start();
        }
    }
}